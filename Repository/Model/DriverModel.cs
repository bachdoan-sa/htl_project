using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class DriverModel
    {
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? ExpectedEndTime { get; set; }
        public string? Type { get; set; }
        public string? DriverStatus { get; set; }
        public string? RoadmapId { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public DateTimeOffset DeleteTime { get; set; }
    }
}
