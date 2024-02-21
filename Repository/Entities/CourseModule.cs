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
    public class CourseModule : BaseEntity
    {
        public int Position { get; set; }
        public string ModuleName { get; set; }
        public string ModuleTarget { get; set; }
        [Required]
        public string CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; }

        public virtual ICollection<CourseLesson>? CourseLessons { get; set; }

    }
}
