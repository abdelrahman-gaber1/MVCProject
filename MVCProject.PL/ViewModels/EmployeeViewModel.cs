using MVCProject.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System;

namespace MVCProject.PL.ViewModels
{
    public enum Gender
    {
        [EnumMember(Value = "Male")]
        Male = 1,
        [EnumMember(Value = "Female")]
        Female = 2,
    }
    public enum EmployeeType
    {
        [EnumMember(Value = "FullTime")]
        FullTime = 1,
        [EnumMember(Value = "PartTime")]
        PartTime = 2,
    }
    // if i have input not found in view i will delete it from here
    public class EmployeeViewModel 
    {
        public int Id { get; set; }
        //I need all error message because it is display in view
        [Required(ErrorMessage = "Name Is Required!")]
        [MaxLength(50, ErrorMessage = "Max Length For Name Is 50")]
        [MinLength(4, ErrorMessage = "Min Length For Name Is 5")]
        public string Name { get; set; }

        [Range(21, 60)]
        public int? Age { get; set; }

        public string Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        public bool IsDelete { get; set; }

        public Gender Gender { get; set; }

        public EmployeeType EmployeeType { get; set; }

        public Department Department { get; set; }
        public int? DepartmentId { get; set; } 
    }
}