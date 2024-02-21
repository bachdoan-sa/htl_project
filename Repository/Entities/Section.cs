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
    public class Section : BaseEntity
    {
        public string Type { get; set; } //not use yet
        [Required]
        public string RoadmapId { get; set; }
        
        [Required]
        public string CourseId { get; set; }
        

        [ForeignKey(nameof(RoadmapId))]
        public virtual Roadmap Roadmap { get; set; }
        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set;}
        
    }
}
