using CarRentalSystem.Models;
using System.Threading.Tasks;

public interface IUserRepository
{
    public Task AddUser(User user);
    public Task<User> GetUserByEmail(string email);
    public Task<User> GetUserById(int id);
}
