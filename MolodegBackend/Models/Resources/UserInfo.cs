using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Models.Resources
{
    public class UserInfo
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public byte[] ProfilePicture { get; set; }
        public string CreatedDate { get; set; }
        public string Access { get; set; }
        public List<Placard> Placards { get; set; }
    }
}
