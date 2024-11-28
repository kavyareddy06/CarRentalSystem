using CarRentalSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CarRentalSystem.Repositories
{
    public interface ICarRepository
    {
        public Task<List<Car>> GetAvailableCars();
        public Task<Car> GetCarById(int id);
        public Task AddCar(Car car);
        public Task UpdateCarAvailability(int id, bool isAvailable);
        Task UpdateCar(Car car);
        Task<bool> DeleteCar(int id);
    }

}
