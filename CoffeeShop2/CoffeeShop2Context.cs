using Microsoft.EntityFrameworkCore;
using CoffeeShop2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CoffeeShop2
{
    public class CoffeeShop2Context : DbContext
    {
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=LENOVO_DANIEL;Database=CoffeeShop2;Trusted_Connection=True;");
        }
    }
}
