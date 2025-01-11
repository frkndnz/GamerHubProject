using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Game
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageURL { get; set; }
        public string? Description { get; set; } = string.Empty;
        public DateTime Released { get; set; }
        public float Rating { get; set; }
        
        public ICollection<Genre>? Genres { get; set; } = new List<Genre>();

        public ICollection<Comment> Comments { get; set; }= new List<Comment>();
    }
}