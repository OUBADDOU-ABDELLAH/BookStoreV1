namespace BookStoreV1.Models.Repository
{
    public class AuthorRepository : IBookStoreRepository<Author>
    {
        IList<Author> _authors;
        public AuthorRepository()
        {
            _authors= new List<Author>()
            {
               new Author {Id=1, FullName="Abdellah OUBADDOU"},
                new Author {Id=2, FullName="YASSINE OUBADDOU"},
                new Author {Id=3, FullName="MOHAMED OUBADDOU"},
                 new Author {Id=4, FullName="KHADIJA OUBADDOU"}
            };
        }
        public void Add(Author entity)
        {
            var id=_authors.Max(a => a.Id)+1; 
            entity.Id = id;
         _authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author=Find(id);
            _authors.Remove(author);    
        }

        public Author Find(int id)
        {

            var author = _authors.SingleOrDefault(a => a.Id == id);

            return author;
        }

        public IList<Author> List()
        {
            return _authors;
        }

        public void Update(int id, Author newAuthor)
        {
            var author = Find(id);

            author.FullName = newAuthor.FullName;
        }
    }
}
