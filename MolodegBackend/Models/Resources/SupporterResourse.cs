using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Models.Resources
{
    public class SupporterResourse
    {
        public int CardId { get; set; }
        public string UserId { get; set; }
        public bool Liked { get; set; }
    }
}
