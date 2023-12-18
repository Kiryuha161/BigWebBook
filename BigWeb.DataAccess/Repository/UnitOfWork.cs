using BigWeb.DataAccess.Data;
using BigWeb.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigWeb.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        
        private readonly ApplicationDbContext _database;

        public UnitOfWork(ApplicationDbContext database)
        {
            _database = database;
            Category = new CategoryRepository(database);
            Product = new ProductRepository(database);
        }

        public void Save()
        {
            _database.SaveChanges();
        }
    }
}
