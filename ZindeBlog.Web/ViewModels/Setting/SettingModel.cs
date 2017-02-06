using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.ViewModels.Setting
{
    public class SettingModel
    {
        internal Dictionary<string, string> Settings { get; set; }

        public SettingModel(Dictionary<string, string> settings)
        {
            Settings = settings;
        }

        /// <summary>
        /// Host adress
        /// </summary>
        public string Host
        {
            get
            {
                return GetStringValue(nameof(Host), "http://");
            }
            set
            {
                SetValue(nameof(Host), value);
            }
        }

        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get
            {
                return GetStringValue(nameof(Title), "DotNetBlog");
            }
            set
            {
                SetValue(nameof(Title), value);
            }
        }

        /// <summary> 
        ///  Description
        /// </summary>
        public string Description
        {
            get
            {
                return GetStringValue(nameof(Description), "");
            }
            set
            {
                SetValue(nameof(Description), value);
            }
        }

        /// <summary>
        ///  TopicsPerPage
        /// </summary>
        public int TopicsPerPage
        {
            get
            {
                return GetIntValue(nameof(TopicsPerPage), 10);
            }
            set
            {
                SetValue(nameof(TopicsPerPage), value.ToString());
            }
        }

        /// <summary>
        /// OnlyShowSummary
        /// </summary>
        public bool OnlyShowSummary
        {
            get
            {
                return GetBooleanValue(nameof(OnlyShowSummary), false);
            }
            set
            {
                SetValue(nameof(OnlyShowSummary), value.ToString());
            }
        }

        /// <summary>
        /// SmtpEmailAddress
        /// </summary>
        public string SmtpEmailAddress
        {
            get
            {
                return GetStringValue(nameof(SmtpEmailAddress), "name@example.com");
            }
            set
            {
                SetValue(nameof(SmtpEmailAddress), value);
            }
        }

        /// <summary>
        /// SmtpServer
        /// </summary>
        public string SmtpServer
        {
            get
            {
                return GetStringValue(nameof(SmtpServer), "mail.example.com");
            }
            set
            {
                SetValue(nameof(SmtpServer), value);
            }
        }

        /// <summary>
        /// SmtpUser
        /// </summary>
        public string SmtpUser
        {
            get
            {
                return GetStringValue(nameof(SmtpUser), "username");
            }
            set
            {
                SetValue(nameof(SmtpUser), value);
            }
        }

        /// <summary>
        /// SmtpPassword
        /// </summary>
        public string SmtpPassword
        {
            get
            {
                return GetStringValue(nameof(SmtpPassword), "password");
            }
            set
            {
                SetValue(nameof(SmtpPassword), value);
            }
        }

        /// <summary>
        /// SmtpPort
        /// </summary>
        public int SmtpPort
        {
            get
            {
                return GetIntValue(nameof(SmtpPort), 25);
            }
            set
            {
                SetValue(nameof(SmtpPort), value.ToString());
            }
        }

        /// <summary>
        /// SmtpEnableSSL
        /// </summary>
        public bool SmtpEnableSSL
        {
            get
            {
                return GetBooleanValue(nameof(SmtpEnableSSL), false);
            }
            set
            {
                SetValue(nameof(SmtpEnableSSL), value.ToString());
            }
        }

        /// <summary>
        /// SendEmailWhenComment
        /// </summary>
        public bool SendEmailWhenComment
        {
            get
            {
                return GetBooleanValue(nameof(SendEmailWhenComment), true);
            }
            set
            {
                SetValue(nameof(SendEmailWhenComment), value.ToString());
            }
        }

        /// <summary>
        /// AllowComment
        /// </summary>
        public bool AllowComment
        {
            get
            {
                return GetBooleanValue(nameof(AllowComment), true);
            }
            set
            {
                SetValue(nameof(AllowComment), value.ToString());
            }
        }

        /// <summary>
        /// VerifyComment
        /// </summary>
        public bool VerifyComment
        {
            get
            {
                return GetBooleanValue(nameof(VerifyComment), true);
            }
            set
            {
                SetValue(nameof(VerifyComment), value.ToString());
            }
        }

        /// <summary>
        /// TrustAuthenticatedCommentUser
        /// </summary>
        public bool TrustAuthenticatedCommentUser
        {
            get
            {
                return GetBooleanValue(nameof(TrustAuthenticatedCommentUser), true);
            }
            set
            {
                SetValue(nameof(TrustAuthenticatedCommentUser), value.ToString());
            }
        }

        /// <summary>
        /// EnableCommentWebSite
        /// </summary>
        public bool EnableCommentWebSite
        {
            get
            {
                return GetBooleanValue(nameof(EnableCommentWebSite), true);
            }
            set
            {
                SetValue(nameof(EnableCommentWebSite), value.ToString());
            }
        }

        /// <summary>
        /// CloseCommentDays
        /// </summary>
        public int CloseCommentDays
        {
            get
            {
                return GetIntValue(nameof(CloseCommentDays), 0);
            }
            set
            {
                SetValue(nameof(CloseCommentDays), value.ToString());
            }
        }

        /// <summary>
        /// ErrorPageTitle
        /// </summary>
        public string ErrorPageTitle
        {
            get
            {
                return GetStringValue(nameof(ErrorPageTitle), "ErrorPageTitle");
            }
            set
            {
                SetValue(nameof(ErrorPageTitle), value.ToString());
            }
        }

        /// <summary>
        /// 错误页面内容
        /// </summary>
        public string ErrorPageContent
        {
            get
            {
                return GetStringValue(nameof(ErrorPageContent), "ErrorPageContent...");
            }
            set
            {
                SetValue(nameof(ErrorPageContent), value.ToString());
            }
        }

        /// <summary>
        /// HeaderScript
        /// </summary>
        public string HeaderScript
        {
            get
            {
                return GetStringValue(nameof(HeaderScript), string.Empty);
            }
            set
            {
                SetValue(nameof(HeaderScript), value.ToString());
            }
        }

        /// <summary>
        /// FooterScript
        /// </summary>
        public string FooterScript
        {
            get
            {
                return GetStringValue(nameof(FooterScript), string.Empty);
            }
            set
            {
                SetValue(nameof(FooterScript), value.ToString());
            }
        }

        #region Private Methods

        private string GetStringValue(string key, string defaultValue)
        {
            if (Settings.ContainsKey(key))
            {
                return Settings[key];
            }
            else
            {
                return defaultValue;
            }
        }

        private int GetIntValue(string key, int defaultValue)
        {
            int result;

            if (Settings.ContainsKey(key))
            {
                if (!int.TryParse(Settings[key], out result))
                {
                    result = defaultValue;
                }
            }
            else
            {
                result = defaultValue;
            }

            return result;
        }

        private bool GetBooleanValue(string key, bool defaultValue)
        {
            bool result;

            if (Settings.ContainsKey(key))
            {
                if (!bool.TryParse(Settings[key], out result))
                {
                    result = defaultValue;
                }
            }
            else
            {
                result = defaultValue;
            }

            return result;
        }

        private void SetValue(string key, string value)
        {
            Settings[key] = value;
        }

        #endregion
    }
}
