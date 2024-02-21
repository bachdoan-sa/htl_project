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
    public class CourseLesson : BaseEntity
    {
        public string LessonName { get; set; }
        public string LessonTarget { get; set; }
        public string LessonURL { get; set; }
        [Required]
        public string CourseModuleId { get; set; }
        [ForeignKey(nameof(CourseModuleId))]
        public virtual CourseModule CourseModule { get; set; }
    }
}
