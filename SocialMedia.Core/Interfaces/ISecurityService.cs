using SocialMedia.Core.Entities;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<User> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(User security);
    }
}
