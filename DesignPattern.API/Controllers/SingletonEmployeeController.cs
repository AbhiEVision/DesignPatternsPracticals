using DesignPattern.API.Messages;
using DesignPatterns.API.Attribute;
using DesignPatterns.Singleton.DAL.Database;
using DesignPatterns.Singleton.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

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
					return Ok(ResponseMessage.NoEmployeeDataFound);
				}
				return Ok(employees);
			}
			EmployeeDetails employee = await _manageDatabase.GetEmployeeDetailsAsync(id ?? 1);
			if (employee == null)
			{
				return Ok(ResponseMessage.EmployeeIsNotFound);
			}
			return Ok(employee);
		}


		[HttpPost]
		public async Task<IActionResult> Create(CreateOrUpdateEmployeeDetails employeeDetails)
		{
			if (employeeDetails == null)
			{
				return BadRequest(ResponseMessage.InvalidData);
			}

			bool created;
			try
			{
				created = await _manageDatabase.CreateEmployeeAsync(employeeDetails);

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
		public async Task<IActionResult> Update([FromQuery] int id, [FromBody] CreateOrUpdateEmployeeDetails employeeDetails)
		{
			if (id == null || id <= 0)
			{
				return BadRequest(ResponseMessage.InvalidData);
			}


			bool updated;

			try
			{
				updated = await _manageDatabase.UpdateEmployeeAsync(id, employeeDetails);
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

			bool deleted = await _manageDatabase.DeleteEmployeeAsync(empId);

			if (deleted)
			{
				return Ok(ResponseMessage.EmployeeIsDeleted);
			}

			return BadRequest(ResponseMessage.EmployeeIsNotFound);
		}

	}
}
