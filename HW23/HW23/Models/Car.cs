using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HW23.Models
{
	public class Car
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Brand must be entered!")]
		[StringLength(30, MinimumLength = 1)]
		public string Brand { get; set; } = string.Empty;

		[Required(ErrorMessage = "Model must be entered!")]
		public string Model { get; set; } = string.Empty;

		[Required(ErrorMessage = "Price must be entered!")]
		public decimal Price { get; set; }
	}
}
