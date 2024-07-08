using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.UserEntities
{
    public class UserFollower : BaseEntity
    {
        public long UserFollowerId { get; set; }
        public long UserFollowingId { get; set; }
        public virtual User? UserFollowing { get; set; }
        public DateTime FollowTime { get; set; }
        public bool IsFollowed { get; set; } = false;
    }
}
