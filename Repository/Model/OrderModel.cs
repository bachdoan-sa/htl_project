using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class OrderModel
    {
        public string? Id { get; set; }
        public decimal? Total { get; set; }
        public string? OrderStatus { get; set; }
        public string? AccountId { get; set; }
        public AccountModel Account { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public DateTimeOffset DeleteTime { get; set; }

    }
}
