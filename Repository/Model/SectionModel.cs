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
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? RoadmapId { get; set; }
        public string? CourseId { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public DateTimeOffset DeleteTime { get; set; }
        public CourseModel? CourseModel { get; set; }
    }
}
