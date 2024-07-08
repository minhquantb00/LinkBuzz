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
    public class UserReactPost : BaseEntity
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public long PostId { get; set; }
        public virtual Post? Post { get; set; }
        public bool IsReact {  get; set; } = false;
        public ConstantEnumerates.ReactType? ReactType { get; set; }
        public DateTime ReactTime { get; set; }
        public virtual ICollection<PageLikePost>? PageLikePosts { get; set; }
    }
}
