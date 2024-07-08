using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.UserEntities
{
    public class UserDevice : BaseEntity
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public string DeviceType { get; set; }
        public string DeviceToken { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
