using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class SectionModel
    {
        public string? Type { get; set; } 
        public string? RoadmapId { get; set; }
        public string? CourseId { get; set; }
    }
}
