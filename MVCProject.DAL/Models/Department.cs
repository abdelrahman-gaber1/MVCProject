using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.DAL.Models
{
    public class Department : ModelBase
    {

        //error massage come from back end and send to view
        [Required(ErrorMessage ="Code is Required")]
        public string Code { get; set; } // .Net 5 Allow Null

        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }
        //when you use display name for in view he will write DateOfCertion(property must look like this) 
        //to add space or other things we use 
        //this data annotation must write in view model
        //because this class is poco class we can't write any thing other property
        [Display(Name ="Date Of Creation")]
        public DateTime DateOfCreation { get; set; }

        //navigation property (Many)
        //this reference refer to null so we must initialize it
        // i must represent relation many 
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
