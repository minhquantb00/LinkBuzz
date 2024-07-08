using LinkBuzz.Domain.Entities.PostEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.PageEntities
{
    public class PagePost : BaseEntity
    {
        public long PostId { get; set; }
        public virtual Post? Post { get; set; }
        public long? AdminId { get; set; }
        public long? ModId { get; set; }
        public bool IsPined { get; set; } = false;
        public virtual ICollection<PageComment>? PageComments { get; set; }
    }
}
