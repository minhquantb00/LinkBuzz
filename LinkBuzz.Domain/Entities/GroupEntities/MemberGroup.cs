using LinkBuzz.Domain.Entities.PageEntities;
using LinkBuzz.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.GroupEntities
{
    public class MemberGroup : BaseEntity
    {
        public long GroupId { get; set; }
        public virtual Group? Group { get; set; }
        public long? PageId { get; set; }
        public virtual Page? Page { get; set; }
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public DateTime JoinTime { get; set; }
    }
}
