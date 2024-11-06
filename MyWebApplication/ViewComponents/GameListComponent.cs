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
        GameManager gameManager= new GameManager(new EfGameDal(),new GameApiService(new HttpClient()));
        // private readonly IApiService _apiService;

        // public GameListComponent(IApiService apiService)
        // {
        //     _apiService = apiService;
        // }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var games=await gameManager.ApiService.GetGamesFromApiAsync();
            return View(games);
        }
    }
}