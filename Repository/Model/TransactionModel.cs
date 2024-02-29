using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class TransactionModel
    {
        public string? PaymentMethod { get; set; }
        public float? Amount { get; set; }
        public string? TransactionStatus { get; set; }
        public string? Message { get; set; }
        public long? ReponseTime { get; set; }
    }
}
