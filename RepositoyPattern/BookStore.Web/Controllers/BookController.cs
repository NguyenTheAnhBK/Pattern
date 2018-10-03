using BookStore.DAL;
using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Web.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        private IBookRepository _bookRepository;
        private UnitOfWork unitOfWork = new UnitOfWork();
        public BookController()
        {
            this._bookRepository = new BookRepository(new BookContext());
        }
        public ActionResult Index()
        {
            var books = from book in _bookRepository.GetBooks()
                        select book;
            return View(books);
        }
        public ActionResult Details(int bookId)
        {
            Book book = _bookRepository.GetBookById(bookId);
            return View(book);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookRepository.InsertBook(book);
                    _bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Book book = _bookRepository.GetBookById(id);
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookRepository.UpdateBook(book);
                    _bookRepository.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(book);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Book book = _bookRepository.GetBookById(id);
            return View(book);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteComfirm(int id)
        {
            _bookRepository.DeleteBook(id);
            _bookRepository.Save();
            return RedirectToAction("Index");
        }
    }
}