using MadoModels.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadoModels.ViewModels
{
    public class PVM
    {
        public Product product { get; set; }
        public IEnumerable<SelectListItem> categoryList { get; set; }
    }
}
