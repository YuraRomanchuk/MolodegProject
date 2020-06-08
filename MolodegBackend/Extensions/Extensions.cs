using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Extensions
{
    public static class Extensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(m => m.Value.Errors)
                             .Select(m => m.ErrorMessage)
                             .ToList();
        }

        public static byte[] ConvertToByteArray(this IFormFile formFile)
        {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(formFile.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)formFile.Length);
                }
                return imageData;
        }
    }
}
