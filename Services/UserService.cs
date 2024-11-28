using CarRentalSystem.Models;
using CarRentalSystem.Repositories;
using CarRentalSystem.Services;
using System;
using System.Threading.Tasks;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly JwtService _jwtService;

    public UserService(IUserRepository userRepository, JwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<bool> RegisterUser(User user)
    {
        var existingUser = await _userRepository.GetUserByEmail(user.Email);
        if (existingUser != null)
        {
            return false; 
        }

        user.Password = user.Password; 

        await _userRepository.AddUser(user);
        return true;
    }

    public async Task<string> AuthenticateUser(string email, string password)
    {
        var user = await _userRepository.GetUserByEmail(email);
        if (user == null || user.Password != password)
        {
            return null; 
        }

        return _jwtService.GenerateToken(user.Email, user.Role);
    }
}
