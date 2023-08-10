using DesignPatterns.AbstractFactory.BAL;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class AbstractFactoryEmployeeController : ControllerBase
	{
		private EmployeeCalculationsWithAbstractFactory _employeeCalculations;

		public AbstractFactoryEmployeeController(EmployeeCalculationsWithAbstractFactory employeeCalculations)
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
				double hourlyPay = await _employeeCalculations.CountTheOverTimePayByHoursAsync(data.empID, data.hours);
				return Ok($"Hourly Pay is {hourlyPay}$");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

	}
}
