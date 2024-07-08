using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.UserEntities
{
    public class UserSession : BaseEntity
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public string SessionToken { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ExpiryTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
