using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class SetTransactionDto
    {
        public TransactionModel? Transaction { get; set; } = new TransactionModel();
        public OrderModel? Order { get; set; } = new OrderModel();
        public OrderDetailModel? OrderDetail { get; set; } = new OrderDetailModel();
        public DriverModel? Driver { get; set; } = new DriverModel(); 

        public string? RoadmapKeyId { get; set; }
       
    }
}
