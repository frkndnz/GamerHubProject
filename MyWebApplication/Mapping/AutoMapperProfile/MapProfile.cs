using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.CommentDTOs;
using DTOLayer.DTOs.GameDTOs;
using MyWebApplication.Areas.Admin.ViewModel;
using MyWebApplication.ViewModel.Comment;
using MyWebApplication.ViewModel.Game;

namespace MyWebApplication.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        
        public MapProfile() 
        {
            CreateMap<AddGameViewModel, AddGameDTO>().ReverseMap();
            CreateMap<EditGameViewModel, EditGameDTO>().ReverseMap();
            CreateMap<GameDetailViewModel, GameDetailDTO>().ReverseMap();
            CreateMap<CommentDTO, CommentViewModel>();
            CreateMap<AddCommentViewModel, AddCommentDTO>();
        }
    }
}
