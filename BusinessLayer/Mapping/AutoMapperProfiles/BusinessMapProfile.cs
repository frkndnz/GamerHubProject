using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTOLayer.DTOs.GameDTOs;
using EntityLayer.Concrete;

namespace BusinessLayer.Mapping.AutoMapperProfiles
{
    public  class BusinessMapProfile:Profile
    {
        public BusinessMapProfile()
        {
            CreateMap<AddGameDTO, Game>();
            CreateMap<Game, EditGameDTO>()
                .ForMember(dest=>dest.SelectedGenreIds,opt =>opt.MapFrom(src=>src.Genres.Select(x=>x.Id).ToList()));
            CreateMap<EditGameDTO, Game>()
                .ForMember(dest => dest.Genres, opt => opt.Ignore());
        }
    }
}
