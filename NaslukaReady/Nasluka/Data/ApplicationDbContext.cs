using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nasluka.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Nasluka.Models;

namespace Nasluka.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Nasluka.Models.OrderCreateBIndingModel> OrderCreateBIndingModel { get; set; }
        public DbSet<Nasluka.Models.OrderListingViewModel> OrderListingViewModel { get; set; }
        //public DbSet<Nasluka.Models.ProductAllViewModel> ProductAllViewModel { get; set; }
        //public DbSet<Nasluka.Models.ProductCreateViewModel> ProductCreateViewModel { get; set; }
        //public DbSet<Nasluka.Models.ProductDetailsViewModel> ProductDetailsViewModel { get; set; }
        //public DbSet<Nasluka.Models.OrderCreateBIndingModel> OrderCreateBIndingModel { get; set; }

        // public DbSet<Nasluka.Models.ProductAllViewModel> ProductBindingAllViewModel { get; set; }

        // public DbSet<Nasluka.Models.ProductCreateViewModel> ProductCreateViewModel { get; set; }
    }
}
