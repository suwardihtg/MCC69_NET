using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class User 
    {
        public virtual Employees Employees { get; set; }
        [Key]
        [ForeignKey("Employees")]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
