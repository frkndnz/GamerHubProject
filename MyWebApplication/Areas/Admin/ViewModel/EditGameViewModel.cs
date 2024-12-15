using System.ComponentModel.DataAnnotations;
using EntityLayer.Concrete;

namespace MyWebApplication.Areas.Admin.ViewModel
{
    public class EditGameViewModel
    {
        
        public int Id { get; set; }
        [Required]
        public required string? Name { get; set; }
        
        public IFormFile? ImageFile { get; set; }
        
        public string? ImageURL { get; set; }
        public string? Description { get; set; } = string.Empty;
        public DateTime Released { get; set; }
        [Required]
        public required List<int> SelectedGenreIds { get; set; }
    }
}
