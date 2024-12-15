using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.GameDTOs
{
    public class AddGameDTO
    {
        public  string? Name { get; set; }
        public string ImageURL { get; set; }
        public string? Description { get; set; } = string.Empty;
        public DateTime Released { get; set; }
        public  List<int> SelectedGenreIds { get; set; }
    }
}
