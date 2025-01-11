using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.UtcNow;

        public string? Content { get; set; }

        
        public int GameId {  get; set; }

        public Game Game { get; set; }


        
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
