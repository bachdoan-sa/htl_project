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
    public class Driver : BaseEntity
    {
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset ExpectedEndTime { get; set;}
        public string Type { get; set; }
        public string DriverStatus { get; set; }
        [Required]
        public string RoadmapId { get; set; }
        [ForeignKey(nameof(RoadmapId))]
        public virtual Roadmap Roadmap { get; set; }

        public virtual ICollection<Checkpoint>? Checkpoints { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
    }
}
