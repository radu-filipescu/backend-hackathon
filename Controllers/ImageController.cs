using backend.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        readonly private string ImagesPath = "./ImageStorage";

        // GET api/<ImageController>/5
        [HttpGet("{name}")]
        public ImageDTO GetWithName(string name)
        {
            string[] images = Directory.GetFiles(ImagesPath);
            var image = new ImageDTO();

            for (int i = 0; i < images.Length; i++)
            {
                string processedPath = images[i].Split("\\").Last();  
                if (processedPath == name)
                {
                    image.ImageAsBase64 = System.IO.File.ReadAllText(ImagesPath + '/' + name);
                    image.ImageName = processedPath;

                    return image;
                }
                    
            }

            return image;
        }

        // POST api/<ImageController>
        [HttpPost]
        public SingleStringResponse Post([FromBody] ImageDTO imageDTO)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(ImagesPath, imageDTO.ImageName)))
            {
                outputFile.WriteLine(imageDTO.ImageAsBase64);
            }

            return new SingleStringResponse("Image uploaded");
        }
    }
}
