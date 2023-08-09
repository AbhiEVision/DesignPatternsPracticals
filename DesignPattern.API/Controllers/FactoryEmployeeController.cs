using DesignPattern.Factory.BAL;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.API.Controllers
{
	public record OverTimeData(int empID, int hours);

	[Route("api/[controller]")]
	[ApiController]
	public class FactoryEmployeeController : ControllerBase
	{
		private EmployeeCalculations _employeeCalculations;

		public FactoryEmployeeController(EmployeeCalculations employeeCalculations)
		{
			_employeeCalculations = employeeCalculations;
		}

		[HttpPost]
		public async Task<IActionResult> GetOvertimePay(OverTimeData data)
		{
			if (data == null || data.empID <= 0 || data.hours <= 0)
			{
				return BadRequest("Please enter the valid data");
			}

			try
			{
				double hourlyPay = await _employeeCalculations.DoOvertimeCalculation(data.empID, data.hours);
				return Ok($"Hourly Pay is {hourlyPay}$");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}
}
