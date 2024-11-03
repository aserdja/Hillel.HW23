using HW23.Data;
using HW23.Models;
using Microsoft.EntityFrameworkCore;

namespace HW23.Controllers
{
	public class CarController(AppDbContext context)
	{
		private readonly AppDbContext _context = context;

		public async Task<IEnumerable<Car>> GetAllAsync()
		{
			return await _context.Cars.ToListAsync();
		}

		public async Task<Car?> GetById(int id)
		{
			return await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task Add(Car car)
		{
			_context.Cars.Add(car);
			await _context.SaveChangesAsync();
		}

		public async Task Update(Car car)
		{
			_context.Cars.Update(car);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteById(int id)
		{
			var carToRemove = await _context.Cars.FirstOrDefaultAsync(c => c.Id == id);
			_context.Cars.Remove(carToRemove);
			await _context.SaveChangesAsync();
		}
	}
}
