using CarRentalSystem.Models;
using System.Threading.Tasks;

public interface ICarService
{
    public Task<bool> RentCar(int carId, int userId, int rentalDays);
    public Task<bool> CheckCarAvailability(int carId);
    public Task<bool> AddCar(Car car);
    public Task<List<Car>> GetAvailableCars();
    Task<bool> UpdateCar(int id, Car updatedCar);
    Task<bool> DeleteCar(int id);
}
