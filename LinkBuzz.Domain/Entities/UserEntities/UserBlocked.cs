using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.UserEntities
{
    public class UserBlocked : BaseEntity
    {
        public long UserId { get; set; }
        public long UserBlockId { get; set; }
        public virtual User? UserBlock { get; set; }
        public DateTime BlockTime { get; set; }
        public bool IsBlocked { get; set; } = false;
    }
}
