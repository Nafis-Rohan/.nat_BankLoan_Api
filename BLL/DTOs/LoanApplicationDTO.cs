using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class LoanApplicationDTO
    {
   
        public int Id { get; set; }

        public int LoanTypeId { get; set; }

       
        public float PrincipalAmmount { get; set; }


        public float InterestRate { get; set; }

        
        public int StatusId { get; set; }

        public int CustomerId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }


    }
}
