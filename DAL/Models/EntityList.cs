using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class EntityList<T>
    {
        public int TotalCount { get; set; }
        public IQueryable<T>? List { get; set; }
    }
}
