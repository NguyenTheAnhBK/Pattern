using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL
{
    public class UnitOfWork : IDisposable
    {
        private BookContext context = new BookContext();
        private GenericRepository<BookRepository> bookRepository;
        public GenericRepository<BookRepository> BookRepository{
            get
            {
                if (this.bookRepository == null)
                    this.bookRepository = new GenericRepository<BookRepository>(context);
                return bookRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Disposed(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    context.Dispose();
            this.disposed = true;
        }
        public void Dispose()
        {
            Disposed(true);
            GC.SuppressFinalize(this);
        }
    }
}
