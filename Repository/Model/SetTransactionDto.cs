using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class SetTransactionDto
    {
        public TransactionModel? Transaction { get; set; }
        public OrderModel? Order { get; set; }
        public OrderDetailModel? OrderDetail { get; set; }
        public DriverModel? Driver { get; set; } 

        public string? RoadmapKeyId { get; set; }
       
    }
}
