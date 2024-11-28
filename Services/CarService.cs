using CarRentalSystem.Models;
using CarRentalSystem.Repositories;
using System;
using System.Threading.Tasks;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;
    private readonly IUserRepository _userRepository;

    public CarService(ICarRepository carRepository, IUserRepository userRepository)
    {
        _carRepository = carRepository;
        _userRepository = userRepository;
    }

    public async Task<bool> RentCar(int carId, int userId, int rentalDays)
    {
        var car = await _carRepository.GetCarById(carId);
        if (car == null || !car.IsAvailable)
        {
            return false; 
        }

        var user = await _userRepository.GetUserById(userId);
        if (user == null)
        {
            return false; 
        }

        await _carRepository.UpdateCarAvailability(carId, false);

        Console.WriteLine($"Car {car.Make} {car.Model} rented by {user.Name} for {rentalDays} days.");

        return true;
    }

    public async Task<bool> CheckCarAvailability(int carId)
    {
        var car = await _carRepository.GetCarById(carId);
        return car != null && car.IsAvailable;
    }
    public async Task<bool> AddCar(Car car)
    {
        try
        {
            await _carRepository.AddCar(car);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public async Task<List<Car>> GetAvailableCars()
    {
        return await _carRepository.GetAvailableCars();
    }
    public async Task<bool> UpdateCar(int id, Car updatedCar)
    {
        var car = await _carRepository.GetCarById(id);
        if (car == null)
            return false;

        car.Make = updatedCar.Make;
        car.Model = updatedCar.Model;
        car.Year = updatedCar.Year;
        car.PricePerDay = updatedCar.PricePerDay;
        car.IsAvailable = updatedCar.IsAvailable;

        await _carRepository.UpdateCar(car);
        return true;
    }
    public async Task<bool> DeleteCar(int id)
    {
        return await _carRepository.DeleteCar(id);
    }
}
