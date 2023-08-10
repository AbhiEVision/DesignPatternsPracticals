using DesignPatterns.CQRS.DAL.Database;
using DesignPatterns.CQRS.DAL.Interface;
using DesignPatterns.CQRS.DAL.Model.Command;
using Microsoft.Extensions.Configuration;

namespace DesignPatterns.CQRS.DAL.Implementation.Repository
{
	public class CommandRepository : ICommandRepository
	{
		public readonly ManageDatabaseForCQRS _database;

		public CommandRepository(IConfiguration configuration)
		{
			_database = new ManageDatabaseForCQRS(configuration.GetConnectionString("Default"));
		}

		public async Task<bool> CreateEmployee(CreateOrUpdateEmployeeModel employee)
		{
			return await _database.CreateEmployeeAsync(employee);
		}

		public async Task<bool> DeleteEmployee(int empId)
		{
			return await _database.DeleteEmployeeAsync(empId);
		}

		public async Task<bool> UpdateEmployee(int empId, CreateOrUpdateEmployeeModel employee)
		{
			return await _database.UpdateEmployeeAsync(empId, employee);
		}
	}
}
