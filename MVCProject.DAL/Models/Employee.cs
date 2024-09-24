using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.DAL.Models
{
    //default internal
    public enum Gender
    {
        [EnumMember(Value ="Male")]
        Male = 1,
        [EnumMember(Value ="Female")]
        Female = 2,
    }
    public enum EmployeeType
    {
        [EnumMember(Value = "FullTime")]
        FullTime = 1,
        [EnumMember(Value = "PartTime")]
        PartTime = 2,
    }
    public class Employee : ModelBase
    {
        // i didn't need any error message here we write it in viewModel =>poco class(only Property in Database)
        public string Name { get; set; }
        public int? Age { get; set; }

        public string Address { get; set; }
        public decimal Salary { get; set; }

        public bool IsActive {get; set;}
        
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set;}

        //Soft Delete : change statue to delete but still in data base
        //Hard Delete : Deleted form Data Base
        public bool IsDelete { get; set; } = false; //Default Value

        public Gender Gender { get; set; }

        public EmployeeType EmployeeType { get; set; }

        //navigation property (One)
        //[InverseProperty(nameof(Models.Department.Employees))] // if i have more than one relation each relation have it's inverseProperty
        //we don't need to use it because we have only one property
        
        public Department Department { get; set; }

        //if i want FK to use it for any reason so i must represent it here
        //null-able integer because we have data in table didn't have value for this column
        //so if it not null-able we will delete all data 

        //[ForeignKey("Hamada")] // i use it if the name here is deferent from data base
        //null-able integer : action with delete for this column is no action (can't delete it)
        //Required integer : action with delete for this column is Cascade (delete it and it's employee)
        public int? DepartmentId { get; set; } //FK Column
    }
}
