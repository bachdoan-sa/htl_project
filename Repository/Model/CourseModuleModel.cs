﻿using Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class CourseModuleModel
    {
        public string? Id { get; set; }
        public int? Position { get; set; }
        public string? ModuleName { get; set; }
        public string? ModuleTarget { get; set; }
        public string? CourseId { get; set; }
        public DateTimeOffset? CreatedTime { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
        public DateTimeOffset? DeleteTime { get; set; }

        public  ICollection<CourseLesson>? CourseLessons { get; set; }

    }
}
