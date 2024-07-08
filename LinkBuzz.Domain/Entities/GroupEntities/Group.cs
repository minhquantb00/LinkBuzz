using LinkBuzz.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.GroupEntities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public ConstantEnumerates.PrivacySettings? PrivacySettings { get; set; } = ConstantEnumerates.PrivacySettings.Public;
        public int NumberOfMembers { get; set; } = 0;
        public string ThumbNail { get; set; }
        public string Description { get; set; }
        public virtual ICollection<AdminGroup>? AdminGroups { get; set; }
        public virtual ICollection<JoinGroup>? JoinGroups { get; set; }
        public virtual ICollection<MemberGroup>? MemberGroups { get; set; }
        public virtual ICollection<GroupPost>? GroupPosts { get; set; }
        public virtual ICollection<MuteMember>? MuteMembers { get; set; }
    }
}
