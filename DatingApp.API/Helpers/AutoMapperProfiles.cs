using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        { //ForMember(dist => dist.PhotoUrl , opt =>{   opt.MapFrom( src => src.Photos.FirstOrDefault(x => x.IsMain ).Url)
            CreateMap<User,UserForListDtos>().ForMember(
                dist => dist.PhotoUrl , opt => 
                { opt.MapFrom(src => src.Photos.FirstOrDefault(p=>p.IsMain).Url); 
                }
                ).ForMember(dist => dist.Age, 
                opt => {
                    opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());

                } )
                ;
            CreateMap<User,UserForDetailsDtos>()
            .ForMember(
                dist => dist.PhotoUrl , opt => 
                { opt.MapFrom(src => src.Photos.FirstOrDefault(p=>p.IsMain).Url); 
                }
                ).ForMember(dist => dist.Age, 
                opt => {
                    opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());

                } )
                ;
            
            CreateMap<Photo,PhotoForDetailDtos>();
        }
        
    }
}