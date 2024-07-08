using LinkBuzz.Domain.Entities.PostEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.PageEntities
{
    public class PageLikeComment : BaseEntity
    {
        public long UserLikeCommentPostId { get; set; }
        public virtual UserReactComment? UserLikeCommentPost { get; set; }
        public long? AdminId { get; set; }
        public long? ModId { get; set; }
    }
}
