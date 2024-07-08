using LinkBuzz.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.ChatEntities
{
    public class ChatMessage : BaseEntity
    {
        public long ConversationId { get; set; }
        public virtual Conversation? Conversation { get; set; }
        public string? Content { get; set; }
        public string? File {  get; set; }
        public string? Photo {  get; set; }
        public long CreatorId { get; set; }
        public virtual User? Creator { get; set; }
        public DateTime CreateTime { get; set; }
        public virtual ICollection<ChatMessageParticipantState>? ChatMessageParticipantStates { get; set; }
        public virtual ICollection<MessageReaction>? MessageReactions { get; set; }
    }
}
