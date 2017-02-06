using MailKit.Net.Smtp;
using MimeKit;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZindeBlog.Web.ViewModels.Setting;
using ZindeBlog.Web.Infrastructure.Core;
using ZindeBlog.Web.ViewModels.Email;
using ZindeBlog.Web.Entities.Blog;

namespace ZindeBlog.Web.Infrastructure.Services
{
    public class EmailService
    {
        private SettingModel Settings { get; set; }

        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        private ZindeBlogContext BlogContext { get; set; }

        public EmailService(SettingModel settings, ZindeBlogContext blogContext)
        {
            this.Settings = settings;
            this.BlogContext = blogContext;
        }

        public async Task<OperationResult> TestEmailConfig(TestEmailConfigModel model)
        {
            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress(model.EmailAddress, model.EmailAddress));
                    message.To.Add(new MailboxAddress(model.EmailAddress, model.EmailAddress));
                    message.Subject = "Test Email";

                    message.Body = new TextPart("plain")
                    {
                        Text = @"Hello world!"
                    };

                    await client.ConnectAsync(model.Server, model.Port, model.EnableSSL);

                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(model.User, model.Password);

                    await client.SendAsync(message);

                    await client.DisconnectAsync(true);

                    return new OperationResult();
                }
            }
            catch (Exception ex)
            {
                return OperationResult.Failure(ex.Message);
            }
        }

        public async Task<OperationResult> SendCommentEmail(Topic topic, Comment comment)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(this.Settings.SmtpEmailAddress, this.Settings.SmtpEmailAddress));

            var user = await this.BlogContext.Users.SingleOrDefaultAsync(t => t.Id == topic.CreateUserID);
            if (user == null || string.IsNullOrWhiteSpace(user.Email))
            {
                return OperationResult.Failure("No email specified");
            }

            message.To.Add(new MailboxAddress(user.Email, user.Email));
            message.Subject = $"[Subject]Re:{topic.Title}";
            message.Body = new TextPart("html")
            {
                Text = string.Format(@"#Re:{0}
<br/><br/>
{1}
<hr/>
use: <a href=""mailto://{2}"" target=""_blank"">{3}</a>
<br/>
URL: <a href=""{4}"" target=""_blank"">{4}</a>", topic.Title, comment.Content, comment.Email, comment.Name, $"{this.Settings.Host}/topic/{topic.ID}#comment_{comment.ID}")
            };

            return await this.SendEmail(message);
        }

        public  Task<OperationResult> SendReplyEmail(Topic topic, Comment comment, Comment replyTo)
        {
            return null;
        }

        private async Task<OperationResult> SendEmail(MimeMessage message)
        {
            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    await client.ConnectAsync(this.Settings.SmtpServer, this.Settings.SmtpPort, this.Settings.SmtpEnableSSL);

                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(this.Settings.SmtpUser, this.Settings.SmtpPassword);

                    await client.SendAsync(message);

                    await client.DisconnectAsync(true);

                    return new OperationResult();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return OperationResult.Failure(ex.Message);
            }
        }
    }
}
