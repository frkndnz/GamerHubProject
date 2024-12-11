using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebApplication.Areas.Admin.ViewModel;

namespace MyWebApplication.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class GameController : Controller
    {
       private readonly ILogger<GameController> _logger;
        private readonly GenreManager _genreManager;
        private readonly GameManager _gameManager;

        public GameController(ILogger<GameController> logger, GenreManager genreManager, GameManager gameManager)
        {
            _logger = logger;
            _genreManager = genreManager;
            _gameManager = gameManager;
        }

        public IActionResult Index()
        {
            var games = _gameManager.GetAllWithInclude(g => g.Genres);
            return View(games);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Genres = _genreManager.TGetList();

            var game= _gameManager.GetAllWithInclude(g=>g.Genres).FirstOrDefault(g=>g.Id==id);
            

            EditGameViewModel model = new EditGameViewModel()
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                Released = game.Released,
                SelectedGenreIds = game.Genres.Select(g => g.Id).ToList()
            };
            return View(model);
        }

        [HttpPost]

        public IActionResult Edit(EditGameViewModel model)
        {
            if (ModelState.IsValid)
            {

                var game = _gameManager.GetAllWithInclude(g => g.Genres).FirstOrDefault(g => g.Id == model.Id);
                game.Name = model.Name;
                game.Description = model.Description;
                game.Released = model.Released;
                game.Genres = new List<Genre>();
               
                foreach (var genreId in model.SelectedGenreIds)
                {
                    var genre = _genreManager.GetById(genreId);
                    if (genre != null)
                    {
                        game.Genres.Add(genre);
                    }
                }
                _gameManager.TUpdate(game);
                return RedirectToAction("Index", "Game", new { area = "Admin" });
            }

            var values = _genreManager.TGetList();
            ViewBag.Genres = values;
            return View(model);
        }


        [HttpGet]
        public IActionResult AddGame()
        {
            var values = _genreManager.TGetList();
            ViewBag.Genres = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddGame(AddGameViewModel model)
        {

            if (ModelState.IsValid )
            {
                
                Game game = new Game()
                {
                    Description = model.Description,
                    Name = model.Name,
                    Released = model.Released,
                    Rating = 0,
                    
                };
                
                _gameManager.TAdd(game);
                foreach (var genreId in model.SelectedGenreIds)
                {
                    var genre = _genreManager.GetById(genreId);
                    if (genre != null) 
                    {
                        game.Genres.Add(genre);
                    }
                }
                _gameManager.TUpdate(game);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            var values = _genreManager.TGetList();
            ViewBag.Genres = values;
            return View(model);
        }
        
    }
}