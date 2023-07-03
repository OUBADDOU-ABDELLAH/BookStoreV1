using BookStoreV1.Models;
using BookStoreV1.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BookStoreV1.Controllers
{
    public class BookController : Controller
    {
        private IBookStoreRepository<Book> _books;
        private IBookStoreRepository<Author> _authors;
        private readonly IHostingEnvironment hosting;

        public BookController(IBookStoreRepository<Book> bookRepo, 
            IBookStoreRepository<Author> AuthRepo,
         IHostingEnvironment hosting
            )
        {
            _books= bookRepo;
            _authors= AuthRepo;
            this.hosting = hosting;
        }
        // GET: BookController
        public ActionResult Index()
        {
           var books= _books.List();
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
           var book=_books.Find(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            var model = new BookAuthViewModel()
            {
                Authors=_authors.List().ToList(),
            };
            return View(model);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthViewModel bookAuth)
        {
            string fileName = string.Empty;
            try
            {
                if (bookAuth.File != null)
                {
                    var uploads = Path.Combine(hosting.WebRootPath , "images");
                    fileName = bookAuth.File.FileName;
                    string FullPath = Path.Combine(uploads, fileName);
                    bookAuth.File.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
            

                var author= _authors.Find(bookAuth.AuthorId);
                var book = new Book()
                {
                    Id = bookAuth.BookId,
                    Description= bookAuth.Description,  
                    ImageUrl=fileName,
                    Title=bookAuth.Title,
                    Author = author,
                };

                _books.Add(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            { 
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {

            var book=_books.Find(id);
            var authorId=book.Author==null ? book.Author.Id=0 : book.Author.Id;
            var bookViewModel = new BookAuthViewModel()
            {
                ImageUrlBVM = book.ImageUrl,
                BookId = book.Id,
                Title = book.Title,
              //  ImageUrl = book.ImageUrl,
                Description = book.Description,
                AuthorId = authorId,
                Authors=_authors.List().ToList(),

            };
            return View(bookViewModel);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookAuthViewModel Newbook)
        {
            string fileName = string.Empty;
            try
            {
                if (Newbook.File != null)
                {
                    var uploads = Path.Combine(hosting.WebRootPath, "images");
                    fileName = Newbook.File.FileName;
                    string FullPath = Path.Combine(uploads, fileName);
                    string OldPath = _books.Find(Newbook.BookId).ImageUrl;
                    string FullOldPath=Path.Combine(uploads, OldPath);

                    if(FullOldPath != FullPath)
                    {
                        System.IO.File.Delete(FullOldPath);
                        Newbook.File.CopyTo(new FileStream(FullPath, FileMode.Create));

                    }
                }

                var author = _authors.Find(Newbook.AuthorId);

             
                var book = new Book()
                {
                    Id = Newbook.BookId,
                    Description = Newbook.Description,
                    ImageUrl = fileName,
                    Title = Newbook.Title,
                    Author = author,
                
                };

                _books.Update(Newbook.AuthorId, book);



                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {

            var book = _books.Find(id);
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
              
                _books.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
