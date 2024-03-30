using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class CheckpointModel
    {
        public string? Titel { get; set; }
        public int?   Position { get; set; }
        public DateTimeOffset? Date { get; set; }
        public long? LearningTime { get; set; }
        public string? DriverId { get; set; }
        public DateTimeOffset? CreatedTime { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
        public DateTimeOffset? DeleteTime { get; set; }
    }
}
