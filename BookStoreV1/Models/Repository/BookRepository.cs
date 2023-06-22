namespace BookStoreV1.Models.Repository
{
    public class BookRepository : IBookStoreRepository<Book>
    {
        List<Book> books;

        public BookRepository() {
            books= new List<Book>() {
                new Book {  Id = 1, Title = "C#", Description = "Learn programing using C#" },
                new Book {  Id = 2, Title = "Java", Description = "Learn programing using Java" },
                new Book {  Id = 3, Title = "Angular", Description = "Learn programing using Angular" },
            };
         

        }
        public void Add(Book entity)
        {
           books.Add(entity);   
        }

        public void Delete(int id)
        {
            var book=Find(id);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book=books.SingleOrDefault(b=>b.Id==id);
            return book;
        }

        public IList<Book> List()
        {
           return books;
        }

        public void Update(int id, Book entity)
        {
            var book=Find(id);
            book.Title = entity.Title;
            book.Description = entity.Description;
        }
    }
}
