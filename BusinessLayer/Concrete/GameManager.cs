using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class GameManager : GenericService<Game>
    {
        public  IApiService ApiService=>_apiService;
        private readonly IApiService _apiService;
        public GameManager(IGenericDal<Game> genericDal, IApiService apiService) : base(genericDal)
        {
            _apiService = apiService;
        }

        public async Task FetchAndSaveGamesFromApiAsync()
        {
            var apiGames = await _apiService.GetGamesFromApiAsync();

            foreach (var apiGame in apiGames)
            {
                var game = new Game
                {
                    Id = apiGame.Id,
                    Name = apiGame.Name,
                    

                };

              //  TAdd(game); // Veritabanına kaydediyoruz
            }
        }
    }
}