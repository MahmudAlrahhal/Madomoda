using MadoModels.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadoDataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void update(Category category);
        void save();
    }
}
