using DataProcessing.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
        {
            ///text
        }

        public DbSet<ApplicationUser> Accounts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Sole> Soles { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=HUYJUN\\SQLEXPRESS;Initial Catalog=DUANTHUCTAP;Integrated Security=True;Trust Server Certificate=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // SeedData for Account
            var adminRoleId = Guid.NewGuid();
            var customerRoleId = Guid.NewGuid();
            var employeeRoleId = Guid.NewGuid();
            var guestRoleId = Guid.NewGuid();

            modelBuilder.Entity<IdentityRole<Guid>>().HasData
                (
                    new IdentityRole<Guid>
                    {
                        Id = adminRoleId,
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    }
                );
        }

    }
}
