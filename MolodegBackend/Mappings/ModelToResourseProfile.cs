using AutoMapper;
using MolodegBackend.Models;
using MolodegBackend.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MolodegBackend.Mappings
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Placard, PlacardInfo>();
        }
    }
}
