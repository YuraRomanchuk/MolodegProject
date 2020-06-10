using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Models.Resources
{
    public class UserResourse
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public string Access { get; set; }
        public List<Placard> Placards { get; set; }
    }
}
