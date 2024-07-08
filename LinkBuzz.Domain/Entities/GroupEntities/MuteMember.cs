using LinkBuzz.Domain.Entities.UserEntities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.GroupEntities
{
    public class MuteMember : BaseEntity
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public long GroupId { get; set; }
        public virtual Group? Group { get; set; }
        public long? AdminMuteId { get; set; }
        public long? ModMuteId { get; set; }
        public string? Reason { get; set; }
        public DateTime MuteTime { get; set; }
        public int? MuteTimeNumber { get; set; }
        public bool? IsMute { get; set; }
    }
}
