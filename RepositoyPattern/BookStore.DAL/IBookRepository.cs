using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL
{
    public interface IBookRepository:IDisposable
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int bookId);
        void InsertBook(Book book);
        void DeleteBook(int bookId);
        void UpdateBook(Book book);
        void Save();
    }
}
