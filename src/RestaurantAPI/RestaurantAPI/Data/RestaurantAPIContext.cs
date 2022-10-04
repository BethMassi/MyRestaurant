using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PointOfSale.Models;

namespace RestaurantAPI.Data
{
    public class RestaurantAPIContext : DbContext
    {
        public RestaurantAPIContext(DbContextOptions<RestaurantAPIContext> options)
            : base(options)
        {
        }

        public DbSet<PointOfSale.Models.Item> Item { get; set; } = default!;

        public static List<Item> Items = new List<Item>
        {
            new Item(){ Id = 1, Title = "Japchae", Price    = 13.99, Quantity = 1, Image = "japchae.png", Category = ItemCategory.Noodles},
            new Item(){ Id = 2, Title = "Jajangmyeon", Price = 14.99, Quantity = 1, Image = "jajangmyeon.png", Category = ItemCategory.Noodles},
            new Item(){ Id = 3, Title = "Janchi Guksu", Price = 12.99, Quantity = 1, Image = "janchi_guksu.png", Category = ItemCategory.Noodles},
            new Item(){ Id = 4, Title = "Budae Jjigae", Price = 14.99, Quantity = 1, Image = "budae_jjigae.png", Category = ItemCategory.Noodles},
            new Item(){ Id = 5, Title = "Naengmyeon", Price = 12.99, Quantity = 1, Image = "naengmyeon.png", Category = ItemCategory.Noodles},
            new Item(){ Id = 6, Title = "Soda", Price = 2.50, Quantity = 1, Category = ItemCategory.Beverages, Image = "soda.png"},
            new Item(){ Id = 7, Title = "Iced Tea", Price = 3.50, Quantity = 1, Category = ItemCategory.Beverages, Image = "iced_tea.png"},
            new Item(){ Id = 8, Title = "Hot Tea", Price = 4.00, Quantity = 1, Category = ItemCategory.Beverages, Image = "tea.png"},
            new Item(){ Id = 9, Title = "Coffee", Price = 4.00, Quantity = 1, Category = ItemCategory.Beverages, Image = "coffee.png"},
            new Item(){ Id = 10, Title = "Milk", Price = 5.00, Quantity = 1, Category = ItemCategory.Beverages, Image = "milk.png"},
        };

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Items.ForEach(i =>
            modelBuilder.Entity<Item>().HasData(i)
            );
        }
    }
}
