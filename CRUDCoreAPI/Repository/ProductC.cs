using AutoMapper;
using CRUDCoreAPI.DataAccessLayer;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDCoreAPI.Repository
{
    public class ProductC : IProduct
    {
        private readonly Context _context; //_context;
        public ProductC(Context context)
        {
            _context = context;

            //_context = context;
        }

        public async Task<List<Product>> GetProducts()//GetProducts
        {


            var data = await _context.Products.Select(x => new Product()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price
            }).ToListAsync();
            return data;
        }

        public async Task<Product> GetProductById(int id)
        {
            var data = await _context.Products.Where(x => x.Id == id).Select(x => new Product()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price
            }).FirstOrDefaultAsync();
            return data;
        }
        public async Task<Product> AddProduct(Product product)
        {
            var data = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
            _context.Products.Add(data);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProduct(int id, Product product) //product
        {
            var data = new Product()
            {
                Id = id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };
            _context.Products.Update(data);
            await _context.SaveChangesAsync();
            return data;
        }


        public async Task DeleteProduct(int id)
        {
            var data = new Product { Id = id };
            if(data == null)
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
    }
}
