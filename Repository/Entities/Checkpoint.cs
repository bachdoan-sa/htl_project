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
    public class Checkpoint : BaseEntity
    {
        public string Titel { get; set; }
        public int Position { get; set; }
        public DateTimeOffset Date { get; set; }
        public long LearningTime { get; set; }
        [Required]
        public string DriverId { get; set; }
        [ForeignKey(nameof(DriverId))]
        public virtual Driver Driver { get; set; } 
    }
}
