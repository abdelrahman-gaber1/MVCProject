using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Name Is Required!")]
        [MaxLength(50, ErrorMessage = "Max Length For Name Is 50")]
        [MinLength(4, ErrorMessage = "Min Length For Name Is 5")]
        public string Name { get; set; }

        [Range(21, 60)]
        public int? Age { get; set; }

        public string Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public bool IsActive {get; set;}
        
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [Display(Name="Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name ="Hire Date")]
        public DateTime HireDate { get; set;}

        //Soft Delete : change statue to delete but still in data base
        //Hard Delete : Deleted form Data Base
        public bool IsDelete { get; set; }

        public Gender Gender { get; set; }

        public EmployeeType EmployeeType { get; set; }
    }
}
