using AutoMapper;
using Talabat.APIs.Dtos;
using Talabat.Core.Entities;
using static System.Net.WebRequestMethods;

namespace Talabat.APIs.Helpers
{
    public class MappingProfiles:Profile
    {
        

        public MappingProfiles()
        {
           CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand.Name))
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name))
                //.ForMember(d => d.PictureUrl,o => o.MapFrom(S => https://localhost:7108S.PictureUrl));
                .ForMember(d => d.PictureUrl, O => O.MapFrom<ProductPictureUrlResolver>());
        }

    }
}
