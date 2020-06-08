using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Models.Resources
{
    public class PlacardResourse
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        public IFormFile Picture { get; set; }
        public string FullDescription { get; set; }
        public string TbLink { get; set; }
        public string FbLink { get; set; }
        public string DiscordLink { get; set; }
    }
}
