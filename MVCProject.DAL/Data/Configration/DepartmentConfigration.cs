using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.DAL.Data.Configration
{
    internal class DepartmentConfigration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //Fluent API
            builder.Property(D => D.Id).UseIdentityColumn(10, 10);
            // if i want FK to be null-able and cascade we do it by Fluent API
            // i can do it in configuration of department or employee
            // but i must do it in department if i delete the property of one relation in employee
            //if you didn't write with one he will confuse who will be the property department or departmentId
            builder.HasMany(D => D.Employees).WithOne(E=>E.Department)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
