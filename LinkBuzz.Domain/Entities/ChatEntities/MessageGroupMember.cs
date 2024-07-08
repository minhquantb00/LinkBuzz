using LinkBuzz.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.ChatEntities
{
    public class MessageGroupMember : BaseEntity
    {
        public long MessageGroupId { get; set; }
        public virtual MessageGroup? MessageGroup { get; set; }
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public DateTime JoinTime { get; set; }
        public DateTime? LeaveTime { get; set; }
        public bool? IsLeave { get; set; }
    }
}
