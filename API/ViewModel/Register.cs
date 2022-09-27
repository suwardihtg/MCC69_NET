﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModel
{
    public class Register
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }
        //public virtual Job Job { get; set; }
        //[ForeignKey("Job")]
        public int Job_Id { get; set; } // foreign key
        //public virtual Employee Manager { get; set; }
        //[ForeignKey("Manager")]
        public int? Manager_Id { get; set; } // foregin key with self reference, the "?" means its nullable
        //public virtual Department Department { get; set; }
        //[ForeignKey("Department")]
        public int Department_Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
