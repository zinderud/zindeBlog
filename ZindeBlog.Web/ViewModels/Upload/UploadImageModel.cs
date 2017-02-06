using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZindeBlog.Web.ViewModels.Upload
{
    public class UploadImageModel
    {
        [Required]
        public IFormFile File { get; set; }
    }
}
