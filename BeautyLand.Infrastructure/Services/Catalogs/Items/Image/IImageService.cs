using Microsoft.AspNetCore.Http;
using System.Collections.Generic;


namespace BeautyLand.Infrastructure.Services.Catalogs.Items
{
    public  interface IImageService
    {
        List<string> Execute(List<IFormFile> files);
    }
}
