using DesignPatterns.Repository.DAL.Interface;
using DesignPatterns.Repository.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPatterns.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class RepositoryEmployeeController : ControllerBase
	{
		private readonly IEmployeeRepository _repository;

		public RepositoryEmployeeController(IEmployeeRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> Get(int? id)
		{
			if (id == null || id <= 0)
			{
				List<EmployeeDetailsRepo> employees = (await _repository.GetEmployeeDetailsAsync()).ToList();
				if (employees == null || employees.Count() == 0)
				{
					return Ok("No Employee are Registered");
				}
				return Ok(employees);
			}
			EmployeeDetailsRepo employee = await _repository.GetEmployeeDetailAsync(id ?? 1);
			if (employee == null)
			{
				return Ok("requested Data is not found");
			}
			return Ok(employee);
		}


		[HttpPost]
		public async Task<IActionResult> Create(CreateOrUpdateEmployeeDetailsRepo employeeDetails)
		{
			if (employeeDetails == null)
			{
				return BadRequest("Please enter data");
			}

			bool created = await _repository.CreateEmployeeAsync(employeeDetails);

			if (created)
			{
				return Ok("User Created!");
			}

			return BadRequest("User is not created!");
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromQuery] int id, [FromBody] CreateOrUpdateEmployeeDetailsRepo employeeDetails)
		{
			if (id == null || id <= 0)
			{
				return BadRequest("Please enter valid data!");
			}

			bool updated = await _repository.UpdateEmployeeAsync(id, employeeDetails);

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

			bool deleted = await _repository.DeleteEmployeeAsync(empId);

			if (deleted)
			{
				return Ok("Employee deleted successfully");
			}

			return BadRequest("Employee is not found!");
		}

	}
}
