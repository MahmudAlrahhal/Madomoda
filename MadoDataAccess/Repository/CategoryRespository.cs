using MadoDataAccess.Data;
using MadoDataAccess.Repository.IRepository;
using MadoModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadoDataAccess.Repository
{
    public class CategoryRespository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        // Repository Class required a 
        public CategoryRespository(ApplicationDbContext _db) : base(_db)
        {
            this._db = _db;
        }
        public void save()
        {
            _db.SaveChanges();
        }

        public void update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}
