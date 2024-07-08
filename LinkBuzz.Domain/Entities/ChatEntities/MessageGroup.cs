using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.ChatEntities
{
    public class MessageGroup : BaseEntity
    {
        public string Name { get; set; }
        public int NumberOfMember { get; set; } = 0;
        public DateTime CreateTime { get; set; }
        public virtual ICollection<MessageGroupMember>? MessageGroupMembers { get; set; }
        public virtual ICollection<MessagesInGroupMessage>? MessagesInGroupMessages { get; set; }
    }
}
