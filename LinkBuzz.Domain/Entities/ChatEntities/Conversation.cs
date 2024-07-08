using LinkBuzz.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.ChatEntities
{
    public class Conversation : BaseEntity
    {
        public string Title { get; set; }
        public long CreatorId { get; set; }
        public virtual User? Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDeleted { get; set; } = false;
        public virtual ICollection<ChatMessage>? ChatMessages { get; set; }
    }
}
