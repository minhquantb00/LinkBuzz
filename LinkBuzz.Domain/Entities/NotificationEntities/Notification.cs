using LinkBuzz.Domain.Entities.UserEntities;
using LinkBuzz.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.NotificationEntities
{
    public class Notification : BaseEntity
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public ConstantEnumerates.NotificationType? NotificationType { get; set; } 
        public string Message { get; set; }
        public bool? IsRead { get; set; } = false;
        public DateTime CreateTime { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
