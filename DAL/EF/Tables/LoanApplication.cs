using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class LoanApplication
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Lt")]
        public int LoanTypeId { get; set; }
        public virtual LoanTypes Lt { get; set; }


        [Column(TypeName ="FLOAT")]
        public float PrincipalAmmount { get; set; }


        [Column(TypeName = "FLOAT")]
        public float InterestRate { get; set; }

        [ForeignKey("Sta")]
        public int StatusId { get; set; }
        public virtual Statuses Sta { get; set; }


        [ForeignKey("Cus")]
        public int CustomerId { get; set; }
        public virtual Customer Cus { get; set; }


        [Column(TypeName = "DATE")]
        public DateTime StartDate { get; set; }  

        [Column(TypeName = "DATE")]
        public DateTime DueDate { get; set; }   


    }
}
