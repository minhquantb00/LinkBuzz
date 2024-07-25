using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Domain.Paging
{
    public class PagingArgs
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public PagingStrategy PagingStrategy { get; set; }
    }
}
