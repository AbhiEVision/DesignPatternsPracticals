using DesignPatterns.CQRS.DAL.Interface;
using DesignPatterns.CQRS.DAL.Model.Command;
using DesignPatterns.CQRS.DAL.Model.Query;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class CQRSEmployeeController : ControllerBase
	{
		private readonly IQueryRepository _queryRepository;
		private readonly ICommandRepository _commandRepository;

		public CQRSEmployeeController(IQueryRepository queryRepository, ICommandRepository commandRepository)
		{
			_queryRepository = queryRepository;
			_commandRepository = commandRepository;
		}

		[HttpGet]
		public async Task<IActionResult> Get(int? id)
		{
			if (id == null || id <= 0)
			{
				IEnumerable<EmployeeDetails> employees = await _queryRepository.GetEmployeeDetails();
				if (employees == null || employees.Count() == 0)
				{
					return Ok("No Employee are Registered");
				}
				return Ok(employees);
			}
			EmployeeDetails employee = await _queryRepository.GetEmployeeDetails(id ?? 1);
			if (employee == null)
			{
				return Ok("requested Data is not found");
			}
			return Ok(employee);
		}


		[HttpPost]
		public async Task<IActionResult> Create(CreateOrUpdateEmployeeModel employeeDetails)
		{
			if (employeeDetails == null)
			{
				return BadRequest("Please enter data");
			}

			bool created = await _commandRepository.CreateEmployee(employeeDetails);

			if (created)
			{
				return Ok("User Created!");
			}

			return BadRequest("User is not created!");
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromQuery] int id, [FromBody] CreateOrUpdateEmployeeModel employeeDetails)
		{
			if (id == null || id <= 0)
			{
				return BadRequest("Please enter valid data!");
			}

			bool updated = await _commandRepository.UpdateEmployee(id, employeeDetails);

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

			bool deleted = await _commandRepository.DeleteEmployee(empId);

			if (deleted)
			{
				return Ok("Employee deleted successfully");
			}

			return BadRequest("Employee is not found!");
		}



	}
}
