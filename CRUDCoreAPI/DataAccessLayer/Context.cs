using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CRUDCoreAPI.DataAccessLayer
{
    public class Context : DbContext
    {
        //Context Dbcontext = new Context();
        public Context(DbContextOptions<Context>options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
