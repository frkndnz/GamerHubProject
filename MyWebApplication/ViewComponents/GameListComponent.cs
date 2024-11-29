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
        GameManager gameManager= new GameManager(new EfGameDal());
        

        public  IViewComponentResult Invoke(string search)
        {
            var games= gameManager.TGetList();
            if(!string.IsNullOrEmpty(search))
            {
                games=games.Where(g=>g.Name!.Contains(search,StringComparison.OrdinalIgnoreCase)).ToList();
            }
            return View(games);
        }
    }
}