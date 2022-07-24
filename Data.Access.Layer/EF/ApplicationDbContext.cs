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
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, Guid>
    {
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Painting> Paintings { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUser").HasKey(k => k.ApplicationUserId);
            modelBuilder.Entity<Painting>()
            .HasOne(p => p.ApplicationUser)
            .WithMany(b => b.Paintings)
            .HasForeignKey(p => p.ApplicationUserId)
            .HasPrincipalKey(b => b.Id);

            //modelBuilder.Entity<Painting>()
            //.HasOne(p => p.ApplicationUser)
            //.WithMany(t => t.Paintings)
            //.IsRequired(false);

            _=modelBuilder.Entity<ApplicationUser>().HasData(new List<ApplicationUser>
                {
                    new ApplicationUser
                    {
                        UserName = "Nazar",
                        Id = Guid.NewGuid(),
                        PhoneNumber = "3400001111",
                        About = "adcasffvvbwfqq",
                        Email = "my123email@gmail.com",
                        IconURL = "aca",
                        Paintings = new List<Painting> () 
                        } 


            });
            modelBuilder.Entity<Painting>().HasData(new List<Painting>
                {
                    new Painting
                    {
                        PaintingId = Guid.NewGuid(),
                        ApplicationUserId = null,
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
                        PaintingId = Guid.NewGuid(),
                       
                        ApplicationUserId = null,
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
                        PaintingId = Guid.NewGuid(),

                        ApplicationUserId = null,
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

                }); ; ;



            base.OnModelCreating(modelBuilder);
        }
    }
}
