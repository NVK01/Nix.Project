using AutoMapper;
using Business.Layer.DTO;
using Nix.Project.Models;

namespace Nix.Site.Mapping
{
    public class PLAutoMapperProfile : Profile
    {
        public PLAutoMapperProfile()
        {

            CreateMap<PaintingDTO, PaintingVM>().ReverseMap();
        }
    }
}
