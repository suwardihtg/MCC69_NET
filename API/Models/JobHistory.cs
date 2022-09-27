using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class JobHistory
    {
        [Key]
        [ForeignKey("Employee")]

        public int Id { get; set; }
        public virtual Employees Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Jobs Job { get; set; }
        [ForeignKey("Job")]
        public int Job_Id { get; set; }

        public virtual Departments Department { get; set; }
        [ForeignKey("Department")]
        public int Department_Id { get; set; }
    }
}
