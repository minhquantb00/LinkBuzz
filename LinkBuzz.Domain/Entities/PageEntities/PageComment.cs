using LinkBuzz.Domain.Entities.PostEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.PageEntities
{
    public class PageComment : BaseEntity
    {
        public long PagePostId { get; set; }
        public virtual PagePost? PagePost { get; set; }
        public long CommentId { get; set; }
        public virtual UserCommentPost? Comment { get; set; }
        public long? AdminId { get; set; }
        public long? ModId { get; set; }
    }
}
