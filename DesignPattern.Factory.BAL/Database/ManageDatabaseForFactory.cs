using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DesignPattern.Factory.BAL.Database
{
	public class ManageDatabaseForFactory
	{
		private readonly string _connectionString;

		public ManageDatabaseForFactory(IConfiguration configuration)
		{
			_connectionString = configuration.GetConnectionString("Default");
		}

		public async Task<int> GetEmployeeDepartment(int employeeId)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				SqlCommand fetchDepartment = new SqlCommand(QueryClass.GetDepartmentQuery, connection);

				fetchDepartment.Parameters.AddWithValue("empId", employeeId);

				int depId = (int)await fetchDepartment.ExecuteScalarAsync();

				connection.Close();
				connection.Dispose();

				return depId;
			}
		}
	}
}
