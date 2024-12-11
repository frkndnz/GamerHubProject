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
        private readonly IGenericRepository<Game> _repository;
        public GameManager(IGenericRepository<Game> repository) : base(repository) 
        {
            _repository = repository;
        }
        
    }
}