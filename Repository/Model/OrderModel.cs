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
        public decimal? Total { get; set; }
        public string? OrderStatus { get; set; }

        [Required]
        public string? OrderDetailId { get; set; }
        [Required]
        public string? AccountId { get; set; }
       
    }
}
