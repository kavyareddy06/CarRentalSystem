using CarRentalSystem.Data;
using CarRentalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSystem.Repositories
{
    public class CarRepository:ICarRepository
    {
        private readonly AddDBContext context;
        public CarRepository(AddDBContext context)
        {
            this.context = context;
        }
        public async Task<List<Car>> GetAvailableCars()
        {
            return await context.Cars.Where(c => c.IsAvailable).ToListAsync();
        }
        public async Task AddCar(Car car)
        {
            context.Cars.Add(car);
            await context.SaveChangesAsync();
        }
        public async Task<Car> GetCarById(int id)
        {
            return await context.Cars.FindAsync(id);
        }
        public async Task UpdateCarAvailability(int id, bool isAvailable)
        {
            var car = await GetCarById(id);
            if (car != null)
            {
                car.IsAvailable = isAvailable;
                await context.SaveChangesAsync();
            }
        }
        public async Task UpdateCar(Car car)
        {
            context.Cars.Update(car);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCar(int id)
        {
            var car = await GetCarById(id);
            if (car == null)
                return false;

            context.Cars.Remove(car);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
