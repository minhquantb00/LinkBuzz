using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.PostEntities
{
    public class PostAlbumn : BaseEntity
    {
        public long PostId { get; set; }
        public virtual Post? Post { get; set; }
        public long AlbumId { get; set; }   
        public virtual Albumn? Albumn { get; set; }
    }
}
