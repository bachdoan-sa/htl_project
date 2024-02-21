using Repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Transaction : BaseEntity
    {
        
        public string PaymentMethod { get; set; }
        public float Amount { get; set; }
        public string? TransactionStatus { get; set; }
        public string? Message { get; set; }
        public long ReponseTime { get; set; }
        
        [Required]
        public string OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }
    }
}
