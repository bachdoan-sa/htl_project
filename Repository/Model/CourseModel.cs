﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class CourseModel
    {
        public string? Id { get; set; }
        public string? CourseName { get; set; }
        public string? TypeOfLearning { get; set; }
        public string? Type { get; set; }
        public string? CourseInformation { get; set; }
        public string? CourseStatus { get; set; }
        public string? DefaultImage { get; set; }
        public string? Level { get; set; }
        public double Price { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public DateTimeOffset DeleteTime { get; set; }
    }
}
