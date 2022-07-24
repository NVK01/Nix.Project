using AutoMapper;
using Business.Layer.DTO;
using Nix.Project.Models;
using Presentation.Layer.Models;

namespace Nix.Site.Mapping
{
    public class PLAutoMapperProfile : Profile
    {
        public PLAutoMapperProfile()
        {

            CreateMap<PaintingDTO, PaintingVM>().ReverseMap();
            CreateMap<ApplicationUserDTO, ApplicationUserVM>().ReverseMap();
            CreateMap<ApplicationUserDTO, RegistrationVM>().ReverseMap();
            CreateMap<ApplicationUserInfoDTO, ApplicationUserInfoVM>().ReverseMap();
        }
    }
}
