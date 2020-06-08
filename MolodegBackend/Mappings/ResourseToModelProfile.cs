using AutoMapper;
using MolodegBackend.Models;
using MolodegBackend.Models.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Mappings
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<PlacardResourse, Placard>().ForMember(x => x.Picture, opt => opt.Ignore());
            CreateMap<UserResourse, Placard>().ForMember(x => x.Picture, opt => opt.Ignore());

        }
    }
}
