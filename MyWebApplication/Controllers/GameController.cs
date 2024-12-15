using AutoMapper;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using MyWebApplication.ViewModel.Game;

namespace MyWebApplication.Controllers
{
    public class GameController:Controller
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;
        public GameController(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        public IActionResult Details(int id)
        {
            var detailGameDTO=_gameService.GetGameDetailDTO(id);

            var detailGameViewModel=_mapper.Map<GameDetailViewModel>(detailGameDTO);

            return View(detailGameViewModel);
        }
    }
}
