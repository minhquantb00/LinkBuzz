using LinkBuzz.Domain.Entities.PostEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Application.InterfaceService
{
    public interface IPostService
    {
        Task<IQueryable<Post>> GetAllPost(string? keyword, int pageIndex, int pageSize);
        Task CreatePost(Post post);
    }
}
