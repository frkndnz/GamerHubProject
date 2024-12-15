using DTOLayer.DTOs.GenreDTOs;

namespace MyWebApplication.ViewModel.Game
{
    public class GameDetailViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImageURL { get; set; }
        public string? Description { get; set; } = string.Empty;
        public DateTime Released { get; set; }
        public float Rating { get; set; }

        public ICollection<GenreDTO> GenreDTOs{ get; set; }
    }
}
