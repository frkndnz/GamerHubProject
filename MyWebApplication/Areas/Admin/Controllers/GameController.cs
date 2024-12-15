using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.GameDTOs;
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
        private readonly IGenreService _genreService;
        private readonly IGameService _gameService;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public GameController(ILogger<GameController> logger, IGenreService genreManager, IGameService gameManager, IFileService fileService, IMapper     mapper)
        {
            _logger = logger;
            _genreService = genreManager;
            _gameService = gameManager;
            _fileService = fileService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var games = _gameService.GetAllWithGenres();
            return View(games);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Genres = _genreService.TGetList();
            var editGameDto = _gameService.GetEditGameDTO(id);
            var editGameViewModel=_mapper.Map<EditGameViewModel>(editGameDto);
            return View(editGameViewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(EditGameViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingGameDTO=_gameService.GetEditGameDTO(model.Id);
                var newEditGameDTO = _mapper.Map<EditGameDTO>(model);

                if (model.ImageFile!=null)
                {
                    if (model.ImageURL != null)
                    {
                        _fileService.DeleteFile(existingGameDTO.ImageURL, "images");
                    }
                    newEditGameDTO.ImageURL = await _fileService.SaveFile(model.ImageFile, "images", new string[] { ".jpg", ".png", ".jpeg" });
                }
                else
                {
                    newEditGameDTO.ImageURL=existingGameDTO.ImageURL;
                }
                _gameService.UpdateGame(newEditGameDTO);

                return RedirectToAction("Index", "Game", new { area = "Admin" });
            }

            var values = _genreService.TGetList();
            ViewBag.Genres = values;
            return View(model);
        }


        [HttpGet]
        public IActionResult AddGame()
        {
            var values = _genreService.TGetList();
            ViewBag.Genres = values;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(AddGameViewModel model)
        {
            if (ModelState.IsValid)
            {
                var gameDto = _mapper.Map<AddGameDTO>(model);
                gameDto.ImageURL= await _fileService.SaveFile(model.ImageFile, "images", new string[] { ".jpg", ".png", ".jpeg" });
                _gameService.AddGameDTO(gameDto);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }

            var values = _genreService.TGetList();
            ViewBag.Genres = values;
            return View(model);
        }





        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var game = _gameService.GetById(id);
            if (game != null)
            {
                _fileService.DeleteFile(game.ImageURL, "images");
                _gameService.TDelete(game);
                return Ok();
            }
            else
            {
                return BadRequest("oyun bulunamadý !");
            }
        }


    }
}