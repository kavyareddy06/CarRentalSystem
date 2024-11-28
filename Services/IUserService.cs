using CarRentalSystem.Models;
using System.Threading.Tasks;

public interface IUserService
{
    public Task<bool> RegisterUser(User user);
    public Task<string> AuthenticateUser(string email, string password);
}
