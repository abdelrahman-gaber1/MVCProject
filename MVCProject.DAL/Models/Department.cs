using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.DAL.Models
{
    public class Department
    {
        public int Id { get; set; } // PK Identity

        //error massage come from back end and send to view
        [Required(ErrorMessage ="Code is Required")]
        public string Code { get; set; } // .Net 5 Allow Null

        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }
        public DateTime DateOfCertion { get; set; }
    }
}
