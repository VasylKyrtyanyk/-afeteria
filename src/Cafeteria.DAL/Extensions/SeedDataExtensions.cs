using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Сafeteria.DataModels.Entities;
using Сafeteria.DataModels.Entities.ValueObjects;

namespace Cafeteria.DAL.Extensions
{
    public static class SeedDataExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var product1 = new Product
            {
                Id = 1,
                Name = "Borscht",
                Description = "bla bla bla",
                Price = 30.0m,
                ProductCategory = ProductCategory.Lunch,
                Weight = 300.0,
                FinalDate = DateTime.Now.AddDays(2)
            };

            var product2 = new Product
            {
                Id = 2,
                Name = "Varenyky",
                Description = "bla bla bla",
                Price = 25.0m,
                ProductCategory = ProductCategory.Lunch,
                Weight = 200.0,
                FinalDate = DateTime.Now.AddDays(5)
            };

            var menu1 = new Menu
            {
                Id = 1,
                MenuDate = DateTime.Now.AddDays(1)
            };

            var menu2 = new Menu
            {
                Id = 2,
                MenuDate = DateTime.Now.AddDays(2)
            };

            var user1 = new User
            {
                Id = 1,
                Email = "Andrii.virt@lnu.edu.ua",
                Password = "pass1234",
                UserType = UserType.Student
            };

            var user2 = new User
            {
                Id = 2,
                Email = "Vasyl.Samuliak@lnu.edu.ua",
                Password = "5678word2",
                UserType = UserType.Student
            };

            modelBuilder.Entity<User>(entity => entity
           .HasData(new List<User> { user1, user2 }));

            var userProfile1 = new UserProfile {
                Id = 1,
                DateOfBirth = new DateTime(1999, 11, 5),
                FirstName = "Andrii",
                LastName = "Virt",
                Balance = 1110.0m,
                UserId = user1.Id 
            };
            var userProfile2 = new UserProfile {
                Id = 2,
                DateOfBirth = new DateTime(1998, 3, 21),
                FirstName = "Vasyl",
                LastName = "Samuliak",
                Balance = 1110.0m,
                UserId = user2.Id };

            modelBuilder.Entity<Product>(entity => entity
           .HasData(new List<Product> { product1, product2 }));

            modelBuilder.Entity<Menu>(entity => entity
           .HasData(new List<Menu> { menu1, menu2 }));

            modelBuilder.Entity<ProductMenu>(entity => entity
            .HasData(new List<ProductMenu> {
              new ProductMenu {
              MenuId = menu1.Id, ProductId = product1.Id},
              new ProductMenu {
              MenuId = menu1.Id, ProductId = product2.Id},
              new ProductMenu {
              MenuId = menu2.Id, ProductId = product1.Id},
              new ProductMenu {
              MenuId = menu2.Id, ProductId = product2.Id}
              }));

            modelBuilder.Entity<UserProfile>(entity => entity
          .HasData(new List<UserProfile> { userProfile1, userProfile2 }));

            modelBuilder.Entity<Order>(entity =>
               entity.HasData(
                    new Order
                    {
                        Id = 1,
                        UserId = user1.Id,
                        CreatedDate = DateTime.Now,
                        IsTakeAway = false,
                        PaymentType = PaymentType.Cash,
                        OrderStatus = OrderStatus.Created,
                        TotalSum = 105.5m,
                        CompletedDate = null          
                    },
                    new Order
                    {
                        Id = 2,
                        UserId = user2.Id,
                        CreatedDate = DateTime.Now,
                        IsTakeAway = true,
                        PaymentType = PaymentType.DebitCard,
                        OrderStatus = OrderStatus.Created,
                        TotalSum = 155.5m,
                        CompletedDate = null                       
                    },
                     new Order
                     {
                         Id = 3,
                         UserId = user2.Id,
                         CreatedDate = DateTime.Now,
                         IsTakeAway = true,
                         PaymentType = PaymentType.CreditCard,
                         OrderStatus = OrderStatus.Created,
                         TotalSum = 155.5m,
                         CompletedDate = null
                     }
                )
            );

            modelBuilder.Entity<ProductOrder>(entity => entity
            .HasData(new List<ProductOrder> {
              new ProductOrder {
              OrderId = 1, ProductId = product1.Id},
              new ProductOrder {
              OrderId = 1, ProductId = product2.Id},
              new ProductOrder {
              OrderId = 2, ProductId = product1.Id}
              }));
        }
    }
}
