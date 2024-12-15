using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApplication.ViewComponents
{
    public class GameListComponent : ViewComponent
    {
        private readonly IGameService _gameService;

        public GameListComponent(IGameService gameService)
        {
            _gameService = gameService;
        }

        public  IViewComponentResult Invoke(string search)
        {
            var games= _gameService.GetAllWithGenres();
            
            if(!string.IsNullOrEmpty(search))
            {
                games=games.Where(g=>g.Name!.Contains(search,StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return View(games);
        }
    }
}