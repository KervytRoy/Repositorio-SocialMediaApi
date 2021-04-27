using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.CustomEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Api.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        public ImageController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> InsertImage([FromForm] ImageUpload upload)
        {
            var fileName = Path.Combine(_environment.ContentRootPath, "uploads", upload.Image.FileName);

            using (var fs = new FileStream(fileName, FileMode.Create))
            {
                await upload.Image.CopyToAsync(fs);
                return Ok(upload.Image.FileName);
            }           
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetImage([FromRoute] string fileName)
        {
            var filePath = Path.Combine(_environment.ContentRootPath, "uploads", fileName);

            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var ms = new MemoryStream())
                {
                    await fs.CopyToAsync(ms);
                    return File(ms.ToArray(), "image/png");
                }
            }
                       
        }


    }
}
