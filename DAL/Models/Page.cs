using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Page:BaseEntity
    {
        public string Name { get; set; }
        public string Link { get; set; }
        [ForeignKey("Users")]
        public int UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Profile>? Profiles { get; set; }

    }
}
