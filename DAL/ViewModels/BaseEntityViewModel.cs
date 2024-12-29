using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class BaseEntityViewModel
    {
        public int Id { get; set; }
        public short? Status { get; set; }
        public string? StatusText { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
