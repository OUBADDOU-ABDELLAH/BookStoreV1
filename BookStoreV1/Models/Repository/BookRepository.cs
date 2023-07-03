namespace BookStoreV1.Models.Repository
{
    public class BookRepository : IBookStoreRepository<Book>
    {
        List<Book> books;

        public BookRepository() {
            books= new List<Book>() {
                new Book {  Id = 1, Title = "C#", Description = "Learn programing using C#",Author=new Author(){Id=1,FullName="ahmed el ghali"},ImageUrl="book1.jpg" },
                new Book {  Id = 2, Title = "Java", Description = "Learn programing using Java",Author=new Author(){Id=2},ImageUrl="book1.jpg" },
                new Book {  Id = 3, Title = "Angular", Description = "Learn programing using Angular",Author=new Author(){Id=1},ImageUrl="book2.jpg"},
            };
         

        }
        public void Add(Book entity)
        {
           var id =books.Max(book => book.Id);
           entity.Id = id+1;
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

        public void Update(int id, Book newBook)
        {
            var book=Find(id);
      
      
            book.Title = newBook.Title;
            book.Description = newBook.Description;
            book.Author = newBook.Author;//book.Author.FullName = entity.Author.FullName;
            book.ImageUrl = newBook.ImageUrl;


        }
    }
}
