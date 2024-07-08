using LinkBuzz.Domain.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.PostEntities
{
    public class Albumn : BaseEntity
    {
        public string Name { get; set; }
        public int NumberOfPost { get; set; } = 0;
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<PostAlbumn>? PostAlbumns { get; set; }
    }
}
