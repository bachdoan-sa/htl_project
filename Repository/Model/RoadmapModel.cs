using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class RoadmapModel
    {
        public string? Id { get; set; }
        public string? Title { get; set; }
        public string? RoadmapGoal { get; set; }
        public string? RoadmapType { get; set; }
        public string? Language { get; set; }
        public string? RoadmapImage { get; set; }
        public double? RoadmapPrice { get; set; }
        public string? CareerId { get; set; }
        public string? CareerName { get; set; }
        public int? CountCourse { get; set; }
        //public ICollection<Section>? Sections { get; set; }
        public DateTimeOffset? CreatedTime { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
        public DateTimeOffset? DeleteTime { get; set; }
    }
}
