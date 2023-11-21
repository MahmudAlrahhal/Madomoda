using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadoDataAccess.Repository.IRepository
{
    public interface IunitofWork
    {
        ICategoryRepository CategoryRepository { get; }
        public void save();
    }
}
