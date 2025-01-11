using System.ComponentModel.DataAnnotations;

namespace MyWebApplication.ViewModel.Comment
{
    public class AddCommentViewModel
    {
        [Required(ErrorMessage ="Yorum içeriği boş bırakılamaz !")]
        [DataType(DataType.Text)]
        [StringLength(255,ErrorMessage ="Yorum uzunlugu 255 karakteri geçmemelidir!")]
        public string Content {  get; set; }
        
        public int GameId { get; set; }
        
    }
}
