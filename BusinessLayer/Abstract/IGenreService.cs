using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DTOLayer.DTOs.GenreDTOs;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IGenreService:IGenericService<Genre>
    {

        public GenreDTO GetGenreDTO(int id);
    }
}
