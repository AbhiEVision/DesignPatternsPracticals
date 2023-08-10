using DesignPatterns.API.Attribute;
using DesignPatterns.Singleton.DAL.Database;
using DesignPatterns.Singleton.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.API.Controllers
{
	[Log]
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class SingletonEmployeeController : ControllerBase
	{
		private readonly ManageDatabaseForSingleton _manageDatabase;

		public SingletonEmployeeController(ManageDatabaseForSingleton manageDatabase)
		{
			_manageDatabase = manageDatabase;
		}

		[HttpGet]
		public async Task<IActionResult> Get(int? id)
		{
			if (id == null || id <= 0)
			{
				List<EmployeeDetails> employees = await _manageDatabase.GetAllEmployeesAsync();
				if (employees == null || employees.Count() == 0)
				{
					return Ok("No Employee are Registered");
				}
				return Ok(employees);
			}
			EmployeeDetails employee = await _manageDatabase.GetEmployeeDetailsAsync(id ?? 1);
			if (employee == null)
			{
				return Ok("requested Data is not found");
			}
			return Ok(employee);
		}


		[HttpPost]
		public async Task<IActionResult> Create(CreateOrUpdateEmployeeDetails employeeDetails)
		{
			if (employeeDetails == null)
			{
				return BadRequest("Please enter data");
			}

			bool created = await _manageDatabase.CreateEmployeeAsync(employeeDetails);

			if (created)
			{
				return Ok("User Created!");
			}

			return BadRequest("User is not created!");
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromQuery] int id, [FromBody] CreateOrUpdateEmployeeDetails employeeDetails)
		{
			if (id == null || id <= 0)
			{
				return BadRequest("Please enter valid data!");
			}

			bool updated = await _manageDatabase.UpdateEmployeeAsync(id, employeeDetails);

			if (updated)
			{
				return Ok("Updated successfully!");
			}

			return BadRequest("User is not found!");

		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int empId)
		{
			if (empId == null || empId <= 0)
			{
				return BadRequest("Please enter the valid data!");
			}

			bool deleted = await _manageDatabase.DeleteEmployeeAsync(empId);

			if (deleted)
			{
				return Ok("Employee deleted successfully");
			}

			return BadRequest("Employee is not found!");
		}

	}
}
