using DesignPattern.API.Messages;
using DesignPatterns.Repository.DAL.Interface;
using DesignPatterns.Repository.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

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
					return Ok(ResponseMessage.NoEmployeeDataFound);
				}
				return Ok(employees);
			}
			EmployeeDetailsRepo employee = await _repository.GetEmployeeDetailAsync(id ?? 1);
			if (employee == null)
			{
				return Ok(ResponseMessage.EmployeeIsNotFound);
			}
			return Ok(employee);
		}


		[HttpPost]
		public async Task<IActionResult> Create(CreateOrUpdateEmployeeDetailsRepo employeeDetails)
		{
			if (employeeDetails == null)
			{
				return BadRequest(ResponseMessage.InvalidData);
			}

			bool created;
			try
			{
				created = await _repository.CreateEmployeeAsync(employeeDetails);
			}
			catch (SqlException ex)
			{
				if (ex.Message == "Arithmetic overflow error converting numeric to data type money.\r\nThe statement has been terminated.")
				{
					return BadRequest(ResponseMessage.SalaryLimitExceed);
				}
				if (ex.Message.Contains("Violation of UNIQUE KEY constraint 'UQ__tblEmplo__49A1474005B85882'"))
				{
					return BadRequest(ResponseMessage.EmployeeAlreadyExists);
				}
				if (ex.Message.Contains("The INSERT statement conflicted with the FOREIGN KEY constraint \"FK__tblEmploy__Depar__4F7CD00D\""))
				{
					return BadRequest(ResponseMessage.DepartmentIsNotFound);
				}
				return BadRequest(ex.Message);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			if (created)
			{
				return Ok(ResponseMessage.EmployeeCreated);
			}

			return BadRequest(ResponseMessage.EmployeeIsNotCreated);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromQuery] int id, [FromBody] CreateOrUpdateEmployeeDetailsRepo employeeDetails)
		{
			if (id == null || id <= 0)
			{
				return BadRequest(ResponseMessage.InvalidData);
			}

			bool updated;

			try
			{
				updated = await _repository.UpdateEmployeeAsync(id, employeeDetails);
			}
			catch (SqlException ex)
			{
				if (ex.Message == "Arithmetic overflow error converting numeric to data type money.\r\nThe statement has been terminated.")
				{
					return BadRequest(ResponseMessage.SalaryLimitExceed);
				}
				if (ex.Message.Contains("Violation of UNIQUE KEY constraint 'UQ__tblEmplo__49A1474005B85882'"))
				{
					return BadRequest(ResponseMessage.EmployeeAlreadyExists);
				}
				if (ex.Message.Contains("The UPDATE statement conflicted with the FOREIGN KEY constraint \"FK__tblEmploy__Depar__4F7CD00D\"."))
				{
					return BadRequest(ResponseMessage.DepartmentIsNotFound);
				}
				return BadRequest(ex.Message);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

			if (updated)
			{
				return Ok(ResponseMessage.EmployeeUpdated);
			}

			return BadRequest(ResponseMessage.EmployeeIsNotUpdated);

		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int empId)
		{
			if (empId == null || empId <= 0)
			{
				return BadRequest(ResponseMessage.InvalidData);
			}

			bool deleted = await _repository.DeleteEmployeeAsync(empId);

			if (deleted)
			{
				return Ok(ResponseMessage.EmployeeIsDeleted);
			}

			return BadRequest(ResponseMessage.EmployeeIsNotFound);
		}

	}
}
