using HW23.Data;
using HW23.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HW23.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarController(AppDbContext context) : ControllerBase
	{
		private readonly AppDbContext _context = context;

		[HttpGet]
		public async Task<IEnumerable<Car>> GetAllAsync()
		{
			return await _context.Cars.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<Car?> GetByIdAsync(int id)
		{
			return await _context.Cars.FirstOrDefaultAsync(c => c.Id.Equals(id));
		}

		[HttpPost]
		public async Task Add([FromForm] Car car)
		{
			if (ModelState.IsValid)
			{
				_context.Cars.Add(car);
				await _context.SaveChangesAsync();
			}
		}

		[HttpPut]
		public async Task UpdateById(int id)
		{
			var carToUpdate = await _context.Cars.FirstOrDefaultAsync(c => c.Id.Equals(id));

			if (carToUpdate != null)
			{
				if (ModelState.IsValid)
				{
					carToUpdate.Model += "UPGRADED!";

					_context.Cars.Update(carToUpdate);
					await _context.SaveChangesAsync();
				}
			}
		}

		[HttpDelete]
		public async Task DeleteById(int id)
		{
			var carToRemove = await _context.Cars.FirstOrDefaultAsync(c => c.Id.Equals(id));

			if (carToRemove != null)
			{
				_context.Cars.Remove(carToRemove);
				await _context.SaveChangesAsync();
			}
		}
	}
}
