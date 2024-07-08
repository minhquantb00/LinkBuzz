using LinkBuzz.Domain.Entities.PostEntities;
using LinkBuzz.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.GroupEntities
{
    public class GroupPost : BaseEntity
    {
        public long PostId { get; set; }
        public virtual Post? Post { get; set; }
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public long GroupId { get; set; }
        public virtual Group? Group { get; set; }
        public bool IsPined { get; set; } = false;
    }
}
