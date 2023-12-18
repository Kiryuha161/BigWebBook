using BigWeb.DataAccess.Data;
using BigWeb.DataAccess.Repository.IRepository;
using BigWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigWeb.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _database;

        public ProductRepository(ApplicationDbContext database) : base(database)
        {
            _database = database;
        }

        public void Update(Product product)
        {
            _database.Products.Update(product);
        }
    }
}
