using SocialMedia.Core.Entities;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface ISecurityRepository : IRepository<User>
    {
        Task<User> GetLoginByCredentials(UserLogin login);
    }
}
