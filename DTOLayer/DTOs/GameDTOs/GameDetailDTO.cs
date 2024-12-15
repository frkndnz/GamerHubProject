using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOLayer.DTOs.GenreDTOs;

namespace DTOLayer.DTOs.GameDTOs
{
    public class GameDetailDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageURL { get; set; }
        public string? Description { get; set; } = string.Empty;
        public DateTime Released { get; set; }
        public float Rating { get; set; }

        public List<GenreDTO> GenreDTOs { get; set; }
    }
}
