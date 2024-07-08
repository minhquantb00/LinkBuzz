using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.UserEntities
{
    public class UserViolate : BaseEntity
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public string Reason { get; set; }
        public bool? IsViolated { get; set; } = false;
    }
}
