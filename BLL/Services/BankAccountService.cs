using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BankAccountService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<BankAccount, BankAccountDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static bool Create(BankAccountDTO b)
        {

            var customer = DataAccessFactory.CustomerData().Get(b.CustomerId);


            if (customer == null || b.AccTypeId == 0) { return false; }



            if (b.AccTypeId == 2) //Current
            {
                if (customer.EId == 4) //Student cant open Current ACC
                    return false;

                if (customer.Income < 20000)
                    return false;

                if (b.Balance < 5000)
                    return false;
            }
            else if (b.AccTypeId == 1)//savigs
            {
                if (b.Balance < 500)
                    return false;
            }
            else if (b.AccTypeId == 3) //FD
            {
                if (b.Balance < 10000)
                    return false;
            }
            else if (b.AccTypeId == 4) //Salary
            {
                if (customer.EId != 1) //Salaried
                    return false;
            }
            var data = GetMapper().Map<BankAccount>(b);
            return DataAccessFactory.BankAccountData().Create(data);

            
        }

        public static List<BankAccountDTO> Get()
        {
            var data = DataAccessFactory.BankAccountData().Get();
            return GetMapper().Map<List<BankAccountDTO>>(data);
        }

        public static BankAccountDTO Get(int id)
        {
            var data = DataAccessFactory.BankAccountData().Get(id);
            return GetMapper().Map<BankAccountDTO>(data);
        }
        public static bool Update(BankAccountDTO c)
        {
            var data = GetMapper().Map<BankAccount>(c);
            return DataAccessFactory.BankAccountData().Update(data);
        }

        public static bool Delete(int id)
        {   
            return DataAccessFactory.BankAccountData().Delete(id);
        }

    }
}
