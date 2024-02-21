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
    public class OrderDetail : BaseEntity
    {
        public string OrderDetailStatus { get; set; }
        public decimal Cost { get; set; }
        [Required]
        public string DriverId { get; set; }
        [ForeignKey(nameof(DriverId))]
        public virtual Driver Driver { get; set; }
        
    }
}
