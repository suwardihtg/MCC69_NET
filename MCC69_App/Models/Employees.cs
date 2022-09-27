using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69_App.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }

        public Jobs Job { get; set; }
        [ForeignKey("Job")]
        public int Job_Id { get; set; }
        public int Salary { get; set; }

        public Employees Manager { get; set; }
        [ForeignKey("Manager")]
        public int? Manager_Id { get; set; }

        public Departments Department { get; set; }
        [ForeignKey("Department")]
        public int Department_Id { get; set; }
    }
}
