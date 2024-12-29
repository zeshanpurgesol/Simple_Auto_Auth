using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ProfileViewModel:BaseEntityViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public int PageId { get; set; }
        public virtual Page? Page { get; set; }
    }
}
