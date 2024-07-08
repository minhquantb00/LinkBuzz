using LinkBuzz.Domain.Entities.UserEntities;
using LinkBuzz.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.StoryEntities
{
    public class Story : BaseEntity
    {
        public string? Content { get; set; }
        public string? Photo { get; set; }
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public ConstantEnumerates.PrivacySettings? PrivacySettings { get; set; } = ConstantEnumerates.PrivacySettings.Public;
        public DateTime CreateTime { get; set; }
        public int NumberOfViews { get; set; } = 0;
        public int NumberOfReact {  get; set; } = 0;
        public DateTime? StoryTime { get; set; }
        public bool? IsDeleted { get; set; } = false;
        public virtual ICollection<ReactStory>? ReactStories { get; set; }
    }
}
