using Microsoft.EntityFrameworkCore;
using Repository_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Layer.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions options) : base(options) { }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<CartEntity> Carts { get; set; }
        public DbSet<CustomerDetailsEntity> CustomerDetails { get; set; }
        public DbSet<OrdersEntity> Orders { get; set; }
        public DbSet<WishlistEntity> Wishlist { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>().HasIndex(u=>u.Email).IsUnique();

            modelBuilder.Entity<CartEntity>()
                .HasOne(c=>c.User)
                .WithMany(c=>c.Carts)
                .HasForeignKey(c=>c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<CartEntity>()
                .HasOne(c => c.Book)
                .WithMany(c => c.Carts)
                .HasForeignKey(c => c.BookId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrdersEntity>()
                .HasOne(c=>c.User)
                .WithMany(c=>c.Orders)
                .HasForeignKey(c=>c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrdersEntity>()
                .HasOne(c => c.CustomerDetail)
                .WithMany(c => c.Orders)
                .HasForeignKey(c => c.CustomerDetailId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WishlistEntity>()
                .HasOne(c => c.User)
                .WithMany(c => c.Wishlist)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
