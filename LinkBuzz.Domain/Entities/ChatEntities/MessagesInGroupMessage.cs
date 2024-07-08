using LinkBuzz.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.ChatEntities
{
    public class MessagesInGroupMessage : BaseEntity
    {
        public long MessageGroupId { get; set; }
        public virtual MessageGroup? MessageGroup { get; set; }
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public string Content { get; set; }
        public string File {  get; set; }
        public DateTime CreateTime { get; set; }
        public virtual ICollection<MessageGroupReaction>? MessageGroupReactions { get; set; }
    }
}
