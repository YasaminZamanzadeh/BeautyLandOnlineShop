using BeautyLand.FileEndPoint.Models.Dtos.ImageDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;

namespace BeautyLand.FileEndPoint.Controllers
{
    [Route("UploadFile/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ImageController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public IActionResult Post()
        {
            // if (apikey != expectedApiKey)
            // {
            //     return BadRequest("Invalid API Key.");
            // }

            try
            {
                var files = Request.Form.Files;

                var resourcesPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
                if (!Directory.Exists(resourcesPath))
                {
                    Directory.CreateDirectory(resourcesPath);
                }

                var imagesPath = Path.Combine(resourcesPath, "Images");
                if (!Directory.Exists(imagesPath))
                {
                    Directory.CreateDirectory(imagesPath);
                }

                if (files != null && files.Count > 0)
                {
                    var uploadImages = UploadImage(files);
                    return Ok(uploadImages);
                }
                else
                {
                    return BadRequest("No files were uploaded.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        private ImageDto UploadImage(IFormFileCollection files)
        {
            string newName = Guid.NewGuid().ToString();
            var date = DateTime.Now;

            string directoryName = $@"Resources\Images\{date.Year}\{date.Month}\";
            var uploadsRootFolder = Path.Combine(_hostingEnvironment.WebRootPath, directoryName);

            if (!Directory.Exists(uploadsRootFolder))
            {
                Directory.CreateDirectory(uploadsRootFolder);
            }

            List<string> images = new List<string>();

            foreach (var file in files)
            {
                if (file != null && file.Length > 0)
                {
                    string fileName = newName + file.FileName;
                    var filePath = Path.Combine(uploadsRootFolder, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    images.Add(directoryName + fileName);
                }
            }

            return new ImageDto()
            {
                Images = images,
            };
        }
    }
}