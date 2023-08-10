using DesignPatterns.CQRS.DAL.Database;
using DesignPatterns.CQRS.DAL.Interface;
using DesignPatterns.CQRS.DAL.Model.Query;
using Microsoft.Extensions.Configuration;

namespace DesignPatterns.CQRS.DAL.Implementation.Repository
{
	public class QueryRepository : IQueryRepository
	{
		public readonly ManageDatabaseForCQRS _database;

		public QueryRepository(IConfiguration configuration)
		{
			_database = new ManageDatabaseForCQRS(configuration.GetConnectionString("Default"));
		}
		public async Task<IEnumerable<EmployeeDetails>> GetEmployeeDetails()
		{
			return await _database.GetAllEmployeesAsync();
		}

		public async Task<EmployeeDetails> GetEmployeeDetails(int id)
		{
			return await _database.GetEmployeeDetailsAsync(id);
		}
	}
}
