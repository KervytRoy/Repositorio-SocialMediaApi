using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Entities;
using SocialMedia.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        Task<bool> DeletePost(int id);
        Task<Post> GetPost(int id);
        PagedList<Post> GetPosts(PostQueryFilters filters);
        Task InsertPost(Post post);
        Task<bool> UpdatePost(Post post);
    }
}