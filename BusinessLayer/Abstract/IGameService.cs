using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DTOLayer.DTOs.GameDTOs;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IGameService :IGenericService<Game>
    {
        public IEnumerable<Game> GetAllWithGenres();
        

        public void AddGameDTO(AddGameDTO gameDTO);
        public void UpdateGame(EditGameDTO gameDTO);
        public EditGameDTO GetEditGameDTO(int id);
    }
}
