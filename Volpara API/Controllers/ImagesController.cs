using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Api.Gax.ResourceNames;
using Microsoft.AspNetCore.Mvc;

namespace Volpara_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ImagesController : ControllerBase
{
    private readonly string _basePath = "Resources";

    [HttpGet]
    public IEnumerable<string> Get()
    {
        var imagesInFolder = Directory.GetFiles(_basePath, "*.*", SearchOption.AllDirectories)
                .ToList();

        var imageStrings = new List<string>();

        // error handling for non-jpg files
        foreach (var image in imagesInFolder)
        {
            var bytes= System.IO.File.ReadAllBytes(image);
            var base64sString = Convert.ToBase64String(bytes);
            imageStrings.Add(base64sString);
        }

        return imageStrings.AsEnumerable();
    }
}


