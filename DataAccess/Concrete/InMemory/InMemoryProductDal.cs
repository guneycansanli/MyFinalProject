﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {

        List<Product> _products;
        public InMemoryProductDal()
        {

            //Oracle, sql server ,Postgres, MongoDb
            _products = new List<Product> {
                new Product{ ProductId=1, CategoryId=1, ProductName = "Bardak", UnitPrice=15, UnitInStock=15},
                new Product{ ProductId=2, CategoryId=1, ProductName = "Kamera", UnitPrice=500, UnitInStock=3},
                new Product{ ProductId=3, CategoryId=2, ProductName = "Telefon", UnitPrice=1500, UnitInStock=2},
                new Product{ ProductId=4, CategoryId=2, ProductName = "Bardak", UnitPrice=150, UnitInStock=65},
                new Product{ ProductId=5, CategoryId=2, ProductName = "Bardak", UnitPrice=85, UnitInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language INtegrated Query
            //Lambda
            Product productToDelete = null;

                foreach (var p in _products)
            {
                if (product.ProductId == p.ProductId)
                {
                    productToDelete = p;
                }
            }

            productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId); // usttekinin aynısı

            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryID)
        {
            return _products.Where(p => p.CategoryId == categoryID).ToList();
        }

        public void Update(Product product)
        {
           Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
        }
    }
}
