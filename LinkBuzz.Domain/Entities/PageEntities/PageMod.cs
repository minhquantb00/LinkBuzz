using LinkBuzz.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.PageEntities
{
    public class PageMod : BaseEntity
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public long PageId { get; set; }
        public virtual Page? Page { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsAccept { get; set; } = false;
        public DateTime? LeaveTime { get; set; }
        public bool? IsLeave { get; set; }
    }
}
