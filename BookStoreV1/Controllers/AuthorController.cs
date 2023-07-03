using BookStoreV1.Models;
using BookStoreV1.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreV1.Controllers
{
    public class AuthorController : Controller
    {
        IBookStoreRepository<Author> _authors;
        public AuthorController(IBookStoreRepository<Author> authors)
        {
            _authors = authors;
        
        }
        // GET: AuthorController
        public ActionResult Index()
        {
            var AllAuth=_authors.List();
            return View(AllAuth);
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
           var auth= _authors.Find(id);
            return View(auth);
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            try
            {
                _authors.Add(author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int id)
        {
          var author= _authors.Find(id);
            return View(author);
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Author auth)
        {
            try
            {
               _authors.Update(id, auth);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int id)
        {
            var author = _authors.Find(id);
           // _authors.Delete(id);
            return View(author);
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Author auth)
        {
            try
            {
                 _authors.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
