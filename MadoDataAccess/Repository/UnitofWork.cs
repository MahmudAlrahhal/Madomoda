using MadoDataAccess.Data;
using MadoDataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadoDataAccess.Repository
{
    public class UnitofWork : IunitofWork
    {
        public ICategoryRepository CategoryRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }

        private ApplicationDbContext _db;
        public UnitofWork(ApplicationDbContext db)
        {
            this._db = db;
            CategoryRepository = new CategoryRespository(_db);
            ProductRepository = new ProductRepository(_db);
        }
        public void save()
        {
            _db.SaveChanges();
        }
    }
}
