using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.GameDTOs;
using MyWebApplication.Areas.Admin.ViewModel;

namespace MyWebApplication.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        
        public MapProfile() 
        {
            CreateMap<AddGameViewModel, AddGameDTO>().ReverseMap();
            CreateMap<EditGameViewModel, EditGameDTO>().ReverseMap();
        }
    }
}
