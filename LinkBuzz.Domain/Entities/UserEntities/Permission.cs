﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Entities.UserEntities
{
    public class Permission : BaseEntity
    {
        public long UserId { get; set; }
        public virtual User? User { get; set; }
        public long RoleId { get; set; }
        public virtual Role? Role { get; set; }
    }
}
