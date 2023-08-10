using DesignPatterns.Mediator.Commands;
using DesignPatterns.Mediator.Queries;
using DesignPatterns.Repository.DAL.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.API.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class MediatorEmployeeController : ControllerBase
	{
		private readonly IMediator _mediator;

		public MediatorEmployeeController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> Get(int? id)
		{
			if (id == null || id <= 0)
			{
				List<EmployeeDetailsRepo> employees = await _mediator.Send(new GetEmployeeDetailsQuery());
				if (employees == null || employees.Count() == 0)
				{
					return Ok("No Employee are Registered");
				}
				return Ok(employees);
			}
			EmployeeDetailsRepo employee = await _mediator.Send(new GetEmployeeByIdQuery() { Id = id ?? 1 });
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

			bool created = await _mediator.Send(new CreateEmployeeCommand(employeeDetails.Name, employeeDetails.Salary, employeeDetails.DepartmentId, employeeDetails.EmailAddress));

			if (created)
			{
				return Ok("User Created!");
			}

			return BadRequest("User is already exists!");
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromQuery] int id, [FromBody] CreateOrUpdateEmployeeDetailsRepo employeeDetails)
		{
			if (id == null || id <= 0)
			{
				return BadRequest("Please enter valid data!");
			}

			bool updated = await _mediator.Send(new UpdateEmployeeDataCommand(id, employeeDetails.Name, employeeDetails.Salary, employeeDetails.DepartmentId, employeeDetails.EmailAddress));

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

			bool deleted = await _mediator.Send(new DeleteEmployeeCommand(empId));

			if (deleted)
			{
				return Ok("Employee deleted successfully");
			}

			return BadRequest("Employee is not found!");
		}
	}
}
