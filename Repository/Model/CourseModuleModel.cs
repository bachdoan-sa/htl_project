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
        public int? Position { get; set; }
        public string? ModuleName { get; set; }
        public string? ModuleTarget { get; set; }
        [Required]
        public string? CourseId { get; set; }
    }
}
