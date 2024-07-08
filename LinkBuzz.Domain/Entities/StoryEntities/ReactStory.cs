using LinkBuzz.Domain.Entities.UserEntities;
using LinkBuzz.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.StoryEntities
{
    public class ReactStory : BaseEntity
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public long StoryId { get; set; }
        public virtual ICollection<Story>? Stories { get; set; }
        public ConstantEnumerates.ReactType? ReactType { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
