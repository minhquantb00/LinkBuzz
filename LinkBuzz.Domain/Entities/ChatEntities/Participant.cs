using LinkBuzz.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.ChatEntities
{
    public class Participant : BaseEntity
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public DateTime CreateTime { get; set; }
        public virtual ICollection<ChatMessageParticipantState>? ChatMessageParticipantStates { get; set; }
    }
}
