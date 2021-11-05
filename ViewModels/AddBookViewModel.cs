namespace WebApi.ViewModels
{
    public class AddBookViewModel
    {
        public string Title { get; set; } = null!;

        public int AuthorId { get; set; }

        public string Genre { get; set; } = null!;
    }
}
