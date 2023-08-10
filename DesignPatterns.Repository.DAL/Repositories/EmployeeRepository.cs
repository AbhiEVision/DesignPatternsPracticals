using DesignPatterns.Repository.DAL.Database;
using DesignPatterns.Repository.DAL.Interface;
using DesignPatterns.Repository.DAL.Models;
using Microsoft.Extensions.Configuration;

namespace DesignPatterns.Repository.DAL.Repositories
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly ManageDatabaseForRepository _databse;

		public EmployeeRepository(IConfiguration configuration)
		{
			_databse = new ManageDatabaseForRepository(configuration.GetConnectionString("Default"));
		}

		public async Task<bool> CreateEmployeeAsync(CreateOrUpdateEmployeeDetailsRepo employeeDetails)
		{
			return await _databse.CreateEmployeeAsync(employeeDetails);
		}

		public async Task<bool> UpdateEmployeeAsync(int empId, CreateOrUpdateEmployeeDetailsRepo employeeDetails)
		{
			return await _databse.UpdateEmployeeAsync(empId, employeeDetails);
		}

		public async Task<bool> DeleteEmployeeAsync(int empId)
		{
			return await _databse.DeleteEmployeeAsync(empId);
		}

		public async Task<IEnumerable<EmployeeDetailsRepo>> GetEmployeeDetailsAsync()
		{
			return await _databse.GetAllEmployeesAsync();
		}

		public async Task<EmployeeDetailsRepo> GetEmployeeDetailAsync(int empId)
		{
			return await _databse.GetEmployeeDetailsAsync(empId);
		}

	}
}
