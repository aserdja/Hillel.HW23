using HW23.Data;
using HW23.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;

namespace HW23.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarController(AppDbContext context) : ControllerBase
	{
		private readonly AppDbContext _context = context;

		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			try
			{
				return Ok(await _context.Cars.ToListAsync());
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"{ex.Message}");
			}
			
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdAsync(int id)
		{
			var result = await _context.Cars.FirstOrDefaultAsync(c => c.Id.Equals(id));
			if (result != null)
			{
				return Ok(result);
			}
			return NotFound();
			
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromForm] Car car)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_context.Cars.Add(car);
					await _context.SaveChangesAsync();
				}

				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"{ex.Message}");
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
