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
        private readonly GameManager _gameManager;

        public GameListComponent(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public  IViewComponentResult Invoke(string search)
        {
            var games= _gameManager.GetAllWithInclude(g=>g.Genres);
            
            if(!string.IsNullOrEmpty(search))
            {
                games=games.Where(g=>g.Name!.Contains(search,StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return View(games);
        }
    }
}