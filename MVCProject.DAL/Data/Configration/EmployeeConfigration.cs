using Microsoft.Data.SqlClient;
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
    internal class EmployeeConfigration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Salary).HasColumnType("decimal(18,2)");

            //if i want to save label instead of number
            //HasConversion take two lambda first property went send to database to save
            //second when you read it form data base
            builder.Property(E => E.Gender).HasConversion(
                (Gender) => Gender.ToString(),
                (Gender) => (Gender)Enum.Parse(typeof(Gender), Gender)
                );
            builder.Property(E => E.Name).IsRequired(true).HasMaxLength(50);
        }
    }
}
