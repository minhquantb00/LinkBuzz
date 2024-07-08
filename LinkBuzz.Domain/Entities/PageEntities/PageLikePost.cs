using LinkBuzz.Domain.Entities.PostEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.PageEntities
{
    public class PageLikePost : BaseEntity
    {
        public long UserLikePostId { get; set; }
        public virtual UserReactPost? UserLikePost { get; set; }
        public long? AdminId { get; set; }
        public long? ModId { get; set; }
    }
}
