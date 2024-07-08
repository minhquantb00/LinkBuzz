using LinkBuzz.Domain.Entities.GroupEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.PageEntities
{
    public class Page : BaseEntity
    {
        public long AdminMainId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Avatar { get; set; }
        public int NumberOfLikes { get; set; } = 0;
        public int NumberOfFollows { get; set; } = 0;
        public virtual ICollection<PageAdmin>? PageAdmins { get; set; }
        public virtual ICollection<PageMod>? PageMods { get; set; }
        public virtual ICollection<AdminGroup>? AdminGroups { get; set; }
        public virtual ICollection<JoinGroup>? JoinGroups { get; set; }
        public virtual ICollection<MemberGroup>? MemberGroups { get; set; }
    }
}
