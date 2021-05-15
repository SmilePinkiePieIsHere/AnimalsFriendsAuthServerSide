using AnimalsFriends.Models;
using System.Threading.Tasks;

namespace AnimalsFriends.Interfaces.Services
{
    public interface IUserService
    {
        Task<OWinResponseToken> Register(User user);

        Task<OWinResponseToken> Login(User user);

        Task<OWinResponseToken> Refresh(string refreshToken);
    }
}
