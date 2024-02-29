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
        public string? Title { get; set; }
        public string? RoadmapGoal { get; set; }
        public string? RoadmapType { get; set; }
        public string? Language { get; set; }
        public string? CareerId { get; set; }
    }
}
