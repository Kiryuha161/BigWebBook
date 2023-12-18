using BigWeb.DataAccess.Data;
using BigWeb.DataAccess.Repository.IRepository;
using BigWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BigWeb.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _database;

        public CategoryRepository(ApplicationDbContext database) : base(database) 
        {
                _database = database;
        }

        public void Update(Category category)
        {
            _database.Categories.Update(category);
        }
    }
}
