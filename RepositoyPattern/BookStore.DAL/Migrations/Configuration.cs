namespace BookStore.DAL.Migrations
{
    using BookStore.Model.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookStore.DAL.BookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookStore.DAL.BookContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Books.AddOrUpdate(new Book { id = 1, title = "C# Tutorial", authers = "Nguyễn Thế Anh", publishYear = "1998", basePrice = 20 },
                new Book { id = 2, title = "Programing C/C++", authers = "Andrew", publishYear = "2000", basePrice = 15},
            new Book { id=3, title="Machine Learning", authers="AD", publishYear="2010", basePrice=30});

        }
    }
}
