using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.GenreDTOs;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class GenreService : GenericService<Genre>,IGenreService
    {
        private readonly IGenreRepo _genreRepository;
        private readonly IMapper _mapper;
        public GenreService(IGenreRepo genreRepository, IMapper mapper) : base(genreRepository)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public GenreDTO GetGenreDTO(int id)
        {
            var genreEntity=_genreRepository.GetById(id);
            var genreDTO=_mapper.Map<GenreDTO>(genreEntity);

            return genreDTO;
        }
    }
}
