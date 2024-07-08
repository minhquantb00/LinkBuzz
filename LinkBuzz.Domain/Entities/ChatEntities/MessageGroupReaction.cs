using LinkBuzz.Domain.Entities.UserEntities;
using LinkBuzz.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.ChatEntities
{
    public class MessageGroupReaction : BaseEntity
    {
        public long MessagesInGroupMessageId { get; set; }
        public virtual MessagesInGroupMessage? MessagesInGroupMessage { get; set; }
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public ConstantEnumerates.ReactType? ReactType { get; set; }
        public DateTime CreateTime { get; set; }
        public bool? IsReact {  get; set; }
    }
}
