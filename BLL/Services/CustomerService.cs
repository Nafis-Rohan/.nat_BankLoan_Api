using DAL;                        
using DAL.EF.Tables;  
using DAL.Interfaces;
using AutoMapper;     
using BLL.DTOs;    
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CustomerService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Customer, CustomerDTO>().ReverseMap();
            });
            return new Mapper(config);
        }

        public static bool Create(CustomerDTO c)
        {
            var data = GetMapper().Map<Customer>(c);
            return  DataAccessFactory.CustomerData().Create(data);
        }

        public static List<CustomerDTO> Get()
        {
            var data = DataAccessFactory.CustomerData().Get();
            return GetMapper().Map<List<CustomerDTO>>(data);
        }

        public static CustomerDTO Get(int id)
        {
            var data = DataAccessFactory.CustomerData().Get(id);
            return GetMapper().Map<CustomerDTO>(data);
        }

        public static bool Update(CustomerDTO c) {
            var data = GetMapper().Map<Customer>(c);
            return DataAccessFactory.CustomerData().Update(data);
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.CustomerData().Delete(id);
        }


    }
}
