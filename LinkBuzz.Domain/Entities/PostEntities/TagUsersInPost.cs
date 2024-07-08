using LinkBuzz.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.PostEntities
{
    public class TagUsersInPost : BaseEntity
    {
        public long PostId { get; set; }
        public virtual Post? Post { get; set; }
        public long UserId { get; set; }
        public virtual User? User { get; set; }
    }
}
