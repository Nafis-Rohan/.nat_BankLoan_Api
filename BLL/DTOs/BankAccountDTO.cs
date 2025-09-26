using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BankAccountDTO
    {
        public int Id { get; set; }

        
        public int AccTypeId { get; set; }


        public float Balance { get; set; }

        public int CustomerId { get; set; }
        
    }
}
