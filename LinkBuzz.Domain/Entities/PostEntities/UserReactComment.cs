using LinkBuzz.Domain.Entities.PageEntities;
using LinkBuzz.Domain.Entities.UserEntities;
using LinkBuzz.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.PostEntities
{
    public class UserReactComment : BaseEntity
    {
        public long CommentId { get; set; }
        public virtual UserCommentPost? Comment { get; set; }
        public ConstantEnumerates.ReactType? ReactType { get; set; }
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public DateTime ReactTime { get; set; }
        public bool? IsReact { get; set; }
        public virtual ICollection<PageLikeComment>? PageLikeComments { get; set; }
    }
}
