using MadoDataAccess.Data;
using MadoDataAccess.Repository.IRepository;
using MadoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadoDataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db): base (db)
        {
            this._db = db;
        }
        public void update(Product product)
        {
            _db.Products.Update(product);
        }
    }
}
