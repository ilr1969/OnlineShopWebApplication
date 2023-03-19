using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;

namespace OnlineShopWebApplication.Helpers
{
    public class FileUploader
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileUploader(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        public string UploadProductImage(string id, IFormFile file)
        {
            var filePath = Path.Combine(webHostEnvironment.WebRootPath + "/images/products/" + id + "/");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            var fileName = Guid.NewGuid() + "." + file.FileName.Split(".").Last();
            using (var fileStream = new FileStream(filePath + fileName, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return "/images/products/" + id + "/" + fileName;
        }

        public string UploadUserImage(string id, IFormFile file)
        {
            var filePath = Path.Combine(webHostEnvironment.WebRootPath + "/images/users/" + id + "/");
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            var fileName = Guid.NewGuid() + "." + file.FileName.Split(".").Last();
            using (var fileStream = new FileStream(filePath + fileName, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return "/images/users/" + id + "/" + fileName;
        }
    }
}
