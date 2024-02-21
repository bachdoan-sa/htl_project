using Repository.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Account : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTimeOffset Birthdate { get; set; }
        public string Role { get; set; }
        public string? Work { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
