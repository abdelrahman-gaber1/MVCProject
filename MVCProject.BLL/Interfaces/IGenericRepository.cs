using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject.BLL.Interfaces
{
    // we have a problem if you send to this interface class(model or view model) or interface
    // because there is no constrain in this interface so that is wrong the method in this interface is model connect with database 
    // we will add constrain to only accept Model(Table in database)
    // the common thing between all Model is they have primary key
    // we will make Model Base contain PK for all model and all model will inherit from him this property
    // our interface don't accept any class that not have PK
    public interface IGenericRepository<T> where T : ModelBase
    {
        //Contain the common action signature between interface of department and employee


        //Signature for property
        //Signature for Method
        //Default implemented method

        // implement against interface not against concrete class

        IEnumerable<T> GetAll();

        //ICollection : if i want to do any operation on this collection(remove - add)
        //ICollection : because have some method will help in this operation
        //IEnemrable  : if you want to iterate on it contain method for it like foreach
        //IQueryable   : if you want to do some filtration(gender == male)
        //IQueryable   : because filtration done in database if i used ICollection he will 
        //IQueryable   : get all data form database and then in app will filter it 
        //ReadOnly    : if you didn't iterate on it

        T GetById(int id);

        // when you update row in SQL he send message like one row affected 
        // if return more than zero so the operation done
        void Add(T item);

        void Update(T item);

        void Delete(T item);

    }
}
