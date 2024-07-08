using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.UserEntities
{
    public class FriendShip : BaseEntity
    {
        public long UserOneId { get; set; }
        public long UserTwoId { get; set; }
        public virtual User? UserTwo { get; set; }
        public long FriendShipStatusId { get; set; }
        public virtual FriendShipStatus? FriendShipStatus { get; set; }
        public DateTime? AcceptTime { get; set; }
        public DateTime? RefuseTime { get; set; }
        public DateTime? CancelTime { get; set; }
    }
}
