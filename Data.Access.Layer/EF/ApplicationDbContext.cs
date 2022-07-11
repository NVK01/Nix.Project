using Data.Access.Layer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Layer.EF
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Painting> Paintings { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser").HasKey(k => k.ApplicationUserId);

            modelBuilder.Entity<Painting>()
            .HasOne(p => p.ApplicationUser)
            .WithMany(t => t.Paintings)
            .IsRequired(false);
            modelBuilder.Entity<ApplicationUser>().HasData(new List<ApplicationUser>
                {
                    new ApplicationUser
                    {
                        ApplicationUserId = "1234",
                        Name = "assss",
                        Password = "adDsxc122",
                        SecondName = "moaaa",
                        PhoneNumber = "3400001111",
                        About = "adcasffvvbwfqq",
                        Email = "my123email@gmail.com",
                        ImgURL = "aca"
                    }

                });
            modelBuilder.Entity<Painting>().HasData(new List<Painting>
                {
                    new Painting
                    {
                        PaintingId = "1",
                        ApplicationUserId = "1234",
                        Name = "acacac",
                        ImgURL = "slide1.jpg",
                        About = "awsdada",
                        Price = 5000,
                        Autor = "fafdavf",
                        Medium = "ink",
                        Size = "M",
                        Style = "anola",
                        Subject = "adaaa"
                    },
                    new Painting
                    {
                        PaintingId = "111",
                        //ApplicationUserId = "1234",
                        Name = "acacac",
                        ImgURL = "slide1.jpg",
                        About = "awsdada",
                        Price = 5000,
                        Autor = "fafdavf",
                        Medium = "ink",
                        Size = "M",
                        Style = "anola",
                        Subject = "adaaa"
                    },
                    new Painting
                    {
                        PaintingId = "1111",
                        //ApplicationUserId = "1234",
                        Name = "acacac",
                        ImgURL = "slide1.jpg",
                        About = "awsdada",
                        Price = 5000,
                        Autor = "fafdavf",
                        Medium = "ink",
                        Size = "M",
                        Style = "anola",
                        Subject = "adaaa"
                    }

                });; ;



            base.OnModelCreating(modelBuilder);
        }
    }
}
