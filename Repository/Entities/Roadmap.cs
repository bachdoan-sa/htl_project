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
    public class Roadmap : BaseEntity
    {
        public string Title { get; set; }
        public string RoadmapGoal { get; set; }
        public string RoadmapType { get; set; }
        public string? Language { get; set; }
        public string? RoadmapImage { get; set; }
        public double RoadmapPrice { get; set; }
        [Required]
        public string CareerId { get; set; }
        [ForeignKey(nameof(CareerId))]
        public virtual Career Career { get; set; }

        public virtual ICollection<Section>? Sections { get; set; }
        public virtual ICollection<Driver>? Drivers { get; set; }

    }
}
