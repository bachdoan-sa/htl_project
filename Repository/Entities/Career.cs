using Repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Career : BaseEntity
    {
        public string CareerName { get; set; }
        public string Major { get; set; }
        public string CareerStatus { get; set; }
        public virtual ICollection<Roadmap>? Roadmaps { get; set; }
    }
}
