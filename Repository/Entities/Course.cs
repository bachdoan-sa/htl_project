using Repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Course : BaseEntity
    {
        public string CourseName { get; set; }
        public string TypeOfLearning { get; set; }
        public string Type { get; set; }
        public string CourseInformation { get; set; }
        public string CourseStatus { get; set; }
        public string DefaultImage { get; set; }
        public string Level { get; set; }
        public double Price { get; set; }

        public virtual ICollection<CourseModule>? CourseModules { get;set; }
        public virtual ICollection<Section>? Sections { get; set; }

    }
}
