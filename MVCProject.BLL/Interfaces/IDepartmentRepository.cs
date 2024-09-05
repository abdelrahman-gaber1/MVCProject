using MVCProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.BLL.Interfaces
{
    public interface IDepartmentRepository
    {
        //Signature for property
        //Signature for Method
        //Default implemented method

        // implement against interface not against concrete class

        IEnumerable<Department> GetAll();

        //ICollection : if i want to do any operation on this collection(remove - add)
        //ICollection : because have some method will help in this operation
        //IEnemrable  : if you want to iterate on it contain method for it like foreach
        //ICoarable   : if you want to do some filtration(gender == male)
        //ICoarable   : because filtration done in database if i used ICollection he will 
        //ICoarable   : get all data form database and then in app will filter it 
        //ReadOnly    : if you didn't iterate on it

        Department GetById(int id);

        // when you update row in SQL he send message like one row affected 
        // if return more than zero so the operation done
        int Add(Department department);
            
        int Update(Department department);

        int Delete(Department department);

    }
}
