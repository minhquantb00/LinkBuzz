using LinkBuzz.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.UserEntities
{
    public class UserActivity : BaseEntity
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public string ActivityDetail { get; set; }
        public ConstantEnumerates.ActivityType? ActivityType { get; set; }
        public DateTime ActivityTime { get; set; }
    }
}
