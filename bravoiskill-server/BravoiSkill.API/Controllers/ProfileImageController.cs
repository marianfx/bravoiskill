using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BravoiSkill.API.Controllers
{
    [Route("api/[controller]")]
    public class ProfileImageController : ControllerBase
    {
        public static IHostingEnvironment _environment;
        public ProfileImageController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public class FileUploadAPI
        {
            public IFormFile files { get; set; }
        }
        [HttpPost]
        public async Task<string> Post()
        {
            var files = Request.Form.Files;

            if (files.Count > 0)
            {
                try
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");
                    }

                    var file = files[0];
                    using (FileStream filestream = System.IO.File.Create(_environment.WebRootPath + "\\uploads\\" + file.FileName))
                    {
                        file.CopyTo(filestream);
                        filestream.Flush();
                        return "\\uploads\\" + file.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Unsuccessful";
            }

        }
    }
}
