using System.ComponentModel.DataAnnotations;
using EntityLayer.Concrete;

namespace MyWebApplication.Areas.Admin.ViewModel
{
    public class AddGameViewModel
    {
        [Required]
        public required string? Name { get; set; }
        public string? Description { get; set; } = string.Empty;
        public DateTime Released { get; set; }
        [Required]
        public required List<int> SelectedGenreIds { get; set; }
    }
}
