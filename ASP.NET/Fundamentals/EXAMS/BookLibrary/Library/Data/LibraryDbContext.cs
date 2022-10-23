using Library.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class LibraryDbContext : IdentityDbContext<ApplicationUser>
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationUser> Users { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<ApplicationUserBook> ApplicationUserBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserBook>()
                .HasKey(au => new { au.BookId, au.ApplicationUserId });

            builder.Entity<ApplicationUser>()
                .Property("UserName")
                .HasMaxLength(20);

            builder.Entity<ApplicationUser>()
               .Property("Email")
               .HasMaxLength(60);

            builder
               .Entity<Book>()
               .HasData(new Book()
               {
                   Id = 5,
                   Title = "Lorem Ipsum",
                   Author = "Dolor Sit",
                   ImageUrl = "https://img.freepik.com/free-psd/book-cover-mock-up-arrangement_23-2148622888.jpg?w=826&t=st=1666106877~exp=1666107477~hmac=5dea3e5634804683bccfebeffdbde98371db37bc2d1a208f074292c862775e1b",
                   Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                   CategoryId = 1,
                   Rating = 9.5m
               });

            builder
           .Entity<Category>()
           .HasData(new Category()
           {
               Id = 1,
               Name = "Action"
           },
           new Category()
           {
               Id = 2,
               Name = "Biography"
           },
           new Category()
           {
               Id = 3,
               Name = "Children"
           },
           new Category()
           {
               Id = 4,
               Name = "Crime"
           },
           new Category()
           {
               Id = 5,
               Name = "Fantasy"
           });


           
        }
    }
}