using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Profile:BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        [ForeignKey("Pages")]
        public int PageId { get; set; }
        public virtual Page? Page { get; set; }
    }
}
