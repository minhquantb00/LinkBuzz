using LinkBuzz.Application.InterfaceService;
using LinkBuzz.Domain.Entities.PostEntities;
using LinkBuzz.Domain.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBuzz.Application.ImplementService
{
    public class PostService : IPostService
    {
        private readonly IRepository<Post> _postRepository;
        public PostService(IRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task CreatePost(Post post)
        {
            await _postRepository.CreateAsync(post);
        }

        public async Task<IQueryable<Post>> GetAllPost(string? keyword, int pageIndex, int pageSize)
        {
            return await _postRepository.GetAllAsync();
        }
    }
}
