using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Models
{
    public class Supporter
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public Placard Placard { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public bool Liked { get; set; }
    }
}
