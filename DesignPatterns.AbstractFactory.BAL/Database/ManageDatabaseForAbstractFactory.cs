using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DesignPatterns.AbstractFactory.BAL.Database
{
	public class ManageDatabaseForAbstractFactory
	{
		private readonly string _connectionString;

		public ManageDatabaseForAbstractFactory(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("Default");
		}

		public async Task<int> GetEmployeeDepartment(int employeeId)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				SqlCommand fetchDepartment = new SqlCommand(QueryClass.FetchEmployeeDepartment, connection);

				fetchDepartment.Parameters.AddWithValue("empId", employeeId);

				var depId = await fetchDepartment.ExecuteScalarAsync();

				connection.Close();
				connection.Dispose();

				return depId == null ? 0 : (int)depId;
			}
		}
	}
}
