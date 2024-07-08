using LinkBuzz.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.PostEntities
{
    public class PostShare : BaseEntity
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public long PostId { get; set; }
        public virtual Post? Post { get; set; }
        public DateTime ShareTime { get; set; }
    }
}
