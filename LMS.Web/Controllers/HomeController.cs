using LMS.Business.Extensions;
using LMS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Web.Controllers
{
    [AllowAnonymous]    
    [DisplayName("Home Management")]
    public class HomeController : BaseController
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [DisplayName("Index")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            var dbPath = string.Empty;
            if (files != null && files.Any())
            {
                //check if Attachment folder is not created
                var pathWithFolderName = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "Attachment");
                if (!Directory.Exists(pathWithFolderName))
                {
                    var di = Directory.CreateDirectory(pathWithFolderName);
                }
                foreach (var file in files)
                {
                    //save file in attachment folder
                    if (file.Length > 0)
                    {
                        var extenstion = Path.GetExtension(file.FileName);
                        var myUniqueFileName = Guid.NewGuid().ToString();
                        var dbFilePath = myUniqueFileName + extenstion;
                        dbPath = "/Attachment/" + dbFilePath;
                        var filePath = Path.Combine(pathWithFolderName, dbFilePath);
                        var fileStream = new FileStream(filePath, FileMode.Create);
                        await file.CopyToAsync(fileStream);
                    }
                }
            }
            return Json(dbPath);
        }

        public IActionResult GetLocalStorage()
        {
            var userId = User.Identity.UserId();
            var roleName = User.Identity.RoleName();

            var data = new
            {
                UserId= userId,
                RoleName = roleName,
            };
            return Json(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
