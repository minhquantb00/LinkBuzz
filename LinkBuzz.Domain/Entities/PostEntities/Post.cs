using LinkBuzz.Domain.Entities.GroupEntities;
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
    public class Post : BaseEntity
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public string Content { get; set; }
        public string? Image { get; set; }
        public ConstantEnumerates.PrivacySettings PrivacySettings { get; set; } = ConstantEnumerates.PrivacySettings.Public;
        public int NumberOfLikes { get; set; } = 0;
        public int NumberOfComments { get; set; } = 0;
        public int NumberOfShares { get; set; } = 0;
        public int NumberOfTags { get; set; } = 0;
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool? IsApproval { get; set; }
        public virtual ICollection<PostAlbumn>? PostAlbumns { get; set; }
        public virtual ICollection<UserReactPost>? UserReactPosts { get; set; }
        public virtual ICollection<UserCommentPost>? UserCommentPosts { get; set; }
        public virtual ICollection<PostShare>? PostShares { get; set; }
        public virtual ICollection<TagUsersInPost>? TagUsersInPost { get; set; }
        public virtual ICollection<PagePost>? PagePosts { get; set; }
        public virtual ICollection<GroupPost>? GroupPosts { get; set; }
    }
}
