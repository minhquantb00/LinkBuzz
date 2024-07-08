using LinkBuzz.Domain.Enumerates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.UserEntities
{
    public class UserRelationship : BaseEntity
    {
        public long UserId { get; set; }
        public long RelatedUserId { get; set; }
        public virtual User? RelatedUser { get; set; }
        public ConstantEnumerates.RelationshipStatus RelationshipType { get; set; } = ConstantEnumerates.RelationshipStatus.DocThan;
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsSetRelationship { get; set; }
    }
}
