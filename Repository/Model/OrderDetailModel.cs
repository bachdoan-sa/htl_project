using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class OrderDetailModel
    {
        public string? OrderDetailStatus { get; set; }
        public decimal? Cost { get; set; }
        public string? DriverId { get; set; }
        public string? OrderId { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public DateTimeOffset DeleteTime { get; set; }
    }
}
