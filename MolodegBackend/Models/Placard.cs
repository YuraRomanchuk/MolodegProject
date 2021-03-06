﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Models
{
    public class Placard
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string CreatedDate { get; set; }
        public byte[] Picture { get; set; }
        public string FullDescription { get; set; }
        public string TbLink { get; set; }
        public string FbLink { get; set; }
        public string DiscordLink { get; set; }
        public List<Supporter> Supporters { get; set; }
    }
}
