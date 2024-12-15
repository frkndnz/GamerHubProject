using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.GameDTOs;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class GameService : GenericService<Game>, IGameService
    {
        private readonly IGameRepo _gameRepository;
        private readonly IGenreRepo _genreRepository;
        private readonly IMapper _mapper;
        public GameService(IGameRepo gameRepository, IGenreRepo genreRepository, IMapper mapper) : base(gameRepository)
        {
            _gameRepository = gameRepository;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public void AddGameDTO(AddGameDTO gameDTO)
        {
            //dto gameentity ye maplenecek.
            var gameEntity=_mapper.Map<Game>(gameDTO);
            var genres=_genreRepository.GetListByFilter(g=> gameDTO.SelectedGenreIds.Contains(g.Id));
            gameEntity.Genres = genres;
            TAdd(gameEntity);
        }
        
        public IEnumerable<Game> GetAllWithGenres()
        {
           return _gameRepository.GetAllWithGenres();
        }

        public EditGameDTO GetEditGameDTO(int id)
        {
            var gameEntity= GetAllWithGenres().FirstOrDefault(g => g.Id == id);
            var editGameDto=_mapper.Map<EditGameDTO>(gameEntity);
            return editGameDto;
        }

        public void UpdateGame(EditGameDTO editGameDto)
        {
            var game= GetAllWithGenres().FirstOrDefault(g => g.Id == editGameDto.Id);

            game =_mapper.Map(editGameDto, game);
            
            var genres = _genreRepository.GetListByFilter(g => editGameDto.SelectedGenreIds.Contains(g.Id));
            game.Genres = new List<Genre>(genres);
            TUpdate(game);
        }
    }
}