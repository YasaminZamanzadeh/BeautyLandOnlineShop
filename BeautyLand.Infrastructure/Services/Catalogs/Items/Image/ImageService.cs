using BeautyLand.Infrastructure.Services.Catalogs.Items.Image.Dtos;
using Microsoft.AspNetCore.Http;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace BeautyLand.Infrastructure.Services.Catalogs.Items
{
    public class ImageService: IImageService
    {
        public List<string> Execute(List<IFormFile> files)
        {

            var client = new RestClient("https://localhost:44320/UploadFile/Image");
            var request = new RestRequest("https://localhost:44320/UploadFile/Image", Method.Post);

            foreach (var file in files)
            {
                byte[] bytes;
                using (var target = new MemoryStream())
                {
                    file.CopyTo(target);
                    bytes = target.ToArray();
                }
                request.AddFile(file.FileName, bytes, file.FileName, file.ContentType);
            }

            RestResponse response = client.Execute<ImageDto>(request);
            var upload = Newtonsoft.Json.JsonConvert.DeserializeObject<ImageDto>(response.Content);
            if (upload == null || upload.Images == null || !upload.Images.Any())
            {
                Console.WriteLine("Deserialization returned null or empty images. Check the JSON structure.");
                Console.WriteLine($"Deserialized Content: {response.Content}");
            }

            return upload?.Images;
        }
    }
}
