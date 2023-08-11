using DesignPattern.API.Messages;
using DesignPatterns.CQRS.DAL.Interface;
using DesignPatterns.CQRS.DAL.Model.Command;
using DesignPatterns.CQRS.DAL.Model.Query;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

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
					return Ok(ResponseMessage.NoEmployeeDataFound);
				}
				return Ok(employees);
			}
			EmployeeDetails employee = await _queryRepository.GetEmployeeDetails(id ?? 1);
			if (employee == null)
			{
				return Ok(ResponseMessage.EmployeeIsNotFound);
			}
			return Ok(employee);
		}


		[HttpPost]
		public async Task<IActionResult> Create(CreateOrUpdateEmployeeModel employeeDetails)
		{
			if (employeeDetails == null)
			{
				return BadRequest(ResponseMessage.InvalidData);
			}

			bool created;
			try
			{
				created = await _commandRepository.CreateEmployee(employeeDetails);
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
		public async Task<IActionResult> Update([FromQuery] int id, [FromBody] CreateOrUpdateEmployeeModel employeeDetails)
		{
			if (id == null || id <= 0)
			{
				return BadRequest(ResponseMessage.InvalidData);
			}

			bool updated;

			try
			{
				updated = await _commandRepository.UpdateEmployee(id, employeeDetails);
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

			bool deleted = await _commandRepository.DeleteEmployee(empId);

			if (deleted)
			{
				return Ok(ResponseMessage.EmployeeIsDeleted);
			}

			return BadRequest(ResponseMessage.EmployeeIsNotFound);
		}

	}
}
