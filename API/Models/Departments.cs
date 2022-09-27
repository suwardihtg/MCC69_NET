using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Departments
    {
        [Key]
        public int Id { get; set; }
        public string DepartmentName { get; set; }

        public virtual Locations Location { get; set; }
        [ForeignKey("Location")]
        public int Location_Id { get; set; }
    }
}
