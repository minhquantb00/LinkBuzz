using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.ChatEntities
{
    public class ChatMessageParticipantState : BaseEntity
    {
        public long ChatMessageId { get; set; }
        public virtual ChatMessage? ChatMessage { get; set; }
        public bool IsSeen { get; set; } = false;
        public DateTime SeenTime { get; set; }
        public long ParticipantId { get; set; }
        public virtual Participant? Participant { get; set; }
    }
}
