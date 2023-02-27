using CRUDCoreAPI.DataAccessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUDCoreAPI.Repository
{
    public interface IProduct
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(int id, Product pro);
        Task DeleteProduct(int id);
    }
}
