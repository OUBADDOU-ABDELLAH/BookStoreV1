namespace BookStoreV1.Models
{
    public class BookAuthViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string ImageUrlBVM { get; set; }
        public int AuthorId { get; set; }
        public List<Author> Authors { get; set; }

        public IFormFile File { get; set; }


    }
}
