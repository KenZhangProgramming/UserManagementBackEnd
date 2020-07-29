using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagementBackEnd.Models;

namespace UserManagementBackEnd.Data
{
    public class DbSeederExtensions
    {
        public DbSeederExtensions(ModelBuilder modelBuilder)
        {
            var provinces = GetProvinces();
            var customers = GetCustomers(provinces);
            var orders = GetOrders();
            var products = GetProducts();

            modelBuilder.Entity<Province>().HasData(provinces);
            modelBuilder.Entity<Customer>().HasData(customers);
            modelBuilder.Entity<Order>().HasData(orders);
            modelBuilder.Entity<Product>().HasData(products);

        }

        private List<Customer> GetCustomers(List<Province> provinces)
        {
            //Customers
            var customerNames = new string[]
            {
                "Marcus,HighTower,Male,acmecorp.com",
                "Jesse,Smith,Female,gmail.com",
                "Albert,Einstein,Male,outlook.com",
                "Dan,Wahlin,Male,yahoo.com",
                "Ward,Bell,Male,gmail.com",
                "Brad,Green,Male,gmail.com",
                "Igor,Minar,Male,gmail.com",
                "Miško,Hevery,Male,gmail.com",
                "Michelle,Avery,Female,acmecorp.com",
                "Heedy,Wahlin,Female,hotmail.com",
                "Thomas,Martin,Male,outlook.com",
                "Jean,Martin,Female,outlook.com",
            };
            var addresses = new string[]
            {
                "1234 Anywhere St.",
                "435 Main St.",
                "1 Atomic St.",
                "85 Cedar Dr.",
                "12 Ocean View St.",
                "1600 Amphitheatre Parkway",
                "1604 Amphitheatre Parkway",
                "1607 Amphitheatre Parkway",
                "346 Cedar Ave.",
                "4576 Main St.",
                "964 Point St.",
                "98756 Center St."
            };

            var zip = 85229;
            var customers = new List<Customer>();

            for (var i = 0; i < customerNames.Length; i++)
            {
                var nameGenderHost = customerNames[i].Split(',');

                var customer = new Customer
                {
                    Id = i + 1,
                    FirstName = nameGenderHost[0],
                    LastName = nameGenderHost[1],
                    Email = nameGenderHost[0] + '.' + nameGenderHost[1] + '@' + nameGenderHost[3],
                    Address = addresses[i],
                    Zip = zip + i,
                    ProvinceId = i + 1,
                    Gender = nameGenderHost[2]
                };
                customers.Add(customer);
            }

            return customers;
        }

        private List<Province> GetProvinces()
        {
            var provinces = new List<Province>
            {
                new Province {Id = 1, Name = "British Columbia", Abbreviation = "BC"},
                new Province {Id = 2, Name = "Ontario", Abbreviation = "ON"},
                new Province {Id = 3, Name = "Quebec", Abbreviation = "QC"},
                new Province {Id = 4, Name = "Alberta", Abbreviation = "AB"},
                new Province {Id = 5, Name = "Manitoba", Abbreviation = "MB"},
                new Province {Id = 6, Name = "Yukon", Abbreviation = "YT"},
                new Province {Id = 7, Name = "Northwest Territories", Abbreviation = "NT"},
                new Province {Id = 8, Name = "New Brunswick", Abbreviation = "NB"},
                new Province {Id = 9, Name = "Nunavut", Abbreviation = "NU"},
                new Province {Id = 10, Name = "Newfoundland and Labrador", Abbreviation = "NJ"},
                new Province {Id = 11, Name = "Nova Scotia", Abbreviation = "NS"},
                new Province {Id = 12, Name = "Prince Edward Island", Abbreviation = "PE"}
            };

            return provinces;
        }

        private List<Order> GetOrders()
        {
            var orders = new List<Order>
            {
                new Order {Id = 1 , Product = "Basket", Price = 29.99M, Quantity = 1, CustomerId = 1},
                new Order {Id = 2 , Product = "Yarn", Price = 9.99M, Quantity = 1, CustomerId = 2},
                new Order {Id = 3 , Product = "Needes", Price = 5.99M, Quantity = 1, CustomerId = 3},
                new Order {Id = 4 , Product = "Speakers", Price = 499.99M, Quantity = 1, CustomerId = 4},
                new Order {Id = 5 , Product = "iPod", Price = 399.99M, Quantity = 1, CustomerId = 5},
                new Order {Id = 6 , Product = "Table", Price = 329.99M, Quantity = 1, CustomerId = 6},
                new Order {Id = 7 , Product = "Chair", Price = 129.99M, Quantity = 4, CustomerId = 7},
                new Order {Id = 8 , Product = "Lamp", Price = 89.99M, Quantity = 5, CustomerId = 8},
                new Order {Id = 9 , Product = "Call of Duty", Price = 59.99M, Quantity = 1, CustomerId = 9},
                new Order {Id = 10, Product = "Controller", Price = 49.99M, Quantity = 1, CustomerId = 10},
                new Order {Id = 11, Product = "Gears of War", Price = 49.99M, Quantity = 1, CustomerId = 11},
                new Order {Id = 12, Product = "Lego City", Price = 49.99M, Quantity = 1, CustomerId = 12},
            };
            return orders;
        }

        private List<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new Product {Id = 1 , Name = "Basket", Quantity = "2lb", Category = "Daily Item", CustomerId = 1},
                new Product {Id = 2 , Name = "Yarn", Quantity ="2lb", Category = "Daily Item", CustomerId = 2},
                new Product {Id = 3 , Name = "Needles", Quantity = "1lb", Category = "Daily Item", CustomerId = 3},
                new Product {Id = 4 , Name = "Perch Meat", Quantity = "3lb", Category = "Meat", CustomerId = 4},
                new Product {Id = 5 , Name = "Bass Meat", Quantity = "5lb", Category = "Meat", CustomerId = 5},
                new Product {Id = 6 , Name = "Walleye Meat", Quantity = "1lb", Category = "Meat", CustomerId = 6},
                new Product {Id = 7 , Name = "Goose Meat", Quantity = "6lb", Category = "Meat", CustomerId = 7},
                new Product {Id = 8 , Name = "Deer Meat", Quantity = "7lb", Category = "Meat", CustomerId = 8},
                new Product {Id = 9 , Name = "Moose Meat", Quantity = "8lb", Category = "Meat", CustomerId = 9},
                new Product {Id = 10, Name = "Chicken Meat", Quantity = "4lb", Category = "Meat", CustomerId = 10},
                new Product {Id = 11, Name = "Cabbage", Quantity = "1lb", Category = "Vegetable", CustomerId = 11},
                new Product {Id = 12, Name = "Apple", Quantity = "1lb", Category = "Fruit", CustomerId = 12},
            };
            return products;
        }
    }
}