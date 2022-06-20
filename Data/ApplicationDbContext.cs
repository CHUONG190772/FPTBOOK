using FPTLibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FPTLibrary.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedCategory(builder);
            SeedBook(builder);
        }

        public void SeedCategory(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Politics", Image = "https://cdn-amz.fadoglobal.io/images/I/81o791tFXeS.jpg" },
                new Category { Id = 2, Name = "Horror", Image = "https://cdn2.f-cdn.com/contestentries/1121968/17989453/59a8471fb17b9_thumb900.jpg" },
                new Category { Id = 3, Name = "Romance", Image = "https://www.inquirer.com/resizer/rJ2GQrjd5GR5ruMdmhLbBdJesCY=/filters:format(webp)/cloudfront-us-east-1.images.arcpublishing.com/pmn/SRCJLCGZVBBPTJSRAFMSX34GOM.jpg" },
                new Category { Id = 4, Name = "Science", Image = "https://cdn0.fahasa.com/media/catalog/product/t/h/the_science_book_big_ideas_simply_explained_1_2021_08_28_12_21_00.jpg" }
                );
        }
        public void SeedBook(ModelBuilder builder)
        {
            builder.Entity<Book>().HasData(
                new Book { Id = 1, Name = "Your Name", Image = "https://upload.wikimedia.org/wikipedia/vi/b/b3/Your_Name_novel.jpg", CategoryId = 3, Author = "Makoto Shinkai", Published_Date = DateTime.Parse("2016-03-07"), Price = 500, Quantity = 30, Description = "A comet appears and mysteriously affects and connects the lives of two teenagers of the same age, a boy in the big, bustling city of Tokyo and a girl in a country village where life is slow but idyllic. They find for unknown reasons, they wake up in each other's bodies for weeks at a time. At first, they both think these experiences are just vivid dreams, but when the reality of their situations sinks in, they learn to adjust and even enjoy it. Soon they start to communicate and try to leave notes about who they are and what they are doing. But as they discover more about each other and the other's life, they uncover some disturbing hints that their distance is more than just physical and tragedy haunts them." },
                new Book { Id = 2, Name = "Dracula", Image = "https://thebookmarketng.com/wp-content/uploads/2020/08/dracula.jpg", CategoryId = 2, Author = "Bram Stoker", Published_Date = DateTime.Parse("1897-09-11"), Price = 700, Quantity = 10, Description = "The novel has no single protagonist, but opens with solicitor Jonathan Harker taking a business trip to stay at the castle of a Transylvanian noble, Count Dracula. Harker escapes the castle after discovering that Dracula is a vampire, and the Count moves to England and plagues the seaside town of Whitby. A small group, led by Abraham Van Helsing, hunt Dracula and, in the end, kill him." }
                );
        }
    }
}
