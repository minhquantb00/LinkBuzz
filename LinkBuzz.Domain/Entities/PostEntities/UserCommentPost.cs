using LinkBuzz.Domain.Entities.PageEntities;
using LinkBuzz.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.PostEntities
{
    public class UserCommentPost : BaseEntity
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public long PostId { get; set; }
        public virtual Post? Post { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int NumberOfLike { get; set; } = 0;
        public int NumberOfRepComment { get; set; } = 0;
        public long? CommentOfParentId { get; set; }
        public string? Image {  get; set; }
        public string? Content { get; set; }
        public bool? IsDeleted { get; set; }
        public virtual ICollection<UserReactComment>? UserReactComments { get; set; }
        public virtual ICollection<PageComment>? PageComments { get; set; }
    }
}
