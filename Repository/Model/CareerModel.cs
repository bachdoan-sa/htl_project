using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model
{
    public class CareerModel
    {
        public string? CareerName { get; set; }
        public string? Major { get; set; }
        public string? CareerStatus { get; set; }
        public DateTimeOffset? CreatedTime { get; set; }
        public DateTimeOffset? LastUpdated { get; set; }
        public DateTimeOffset? DeleteTime { get; set; }
    }
}
