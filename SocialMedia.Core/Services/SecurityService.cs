using SocialMedia.Core.Entities;
using SocialMedia.Core.Exceptions;
using SocialMedia.Core.Interfaces;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SecurityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> GetLoginByCredentials(UserLogin userLogin)
        {
            var user = await _unitOfWork.SecurityRepository.GetLoginByCredentials(userLogin);
            if (user == null)
            {
                throw new BusinessException("El usuario no existe");
            }
            return user;
        }

        public async Task RegisterUser(User user)
        {
            await _unitOfWork.SecurityRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
