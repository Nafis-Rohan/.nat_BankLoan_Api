using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICustomerRepo
    {
        bool Create(Customer c);
        List<Customer> Get();
        Customer Get(int id);
        bool Update(Customer c);
        bool Delete(int id);

    }
}
