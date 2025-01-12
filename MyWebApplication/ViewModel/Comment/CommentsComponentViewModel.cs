namespace MyWebApplication.ViewModel.Comment
{
    public class CommentsComponentViewModel
    {
        public int GameId { get; set; }
        public List<CommentViewModel> Comments { get; set; }
        public int CurrentCount { get; set; }
        public int TotalCount { get; set; }
    }
}
