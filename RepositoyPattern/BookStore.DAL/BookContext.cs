using BookStore.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DAL
{
    public class BookContext:DbContext
    {
        public BookContext() : base("BookStoreConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Book> Books { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
        }
    }
}
