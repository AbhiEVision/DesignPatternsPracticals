using DesignPatterns.Repository.DAL.MapperClasses;
using DesignPatterns.Repository.DAL.Models;
using System.Data.SqlClient;

namespace DesignPatterns.Repository.DAL.Database
{
	public class ManageDatabaseForRepository
	{
		private readonly string _connectionString;

		public ManageDatabaseForRepository(string connectionString)
		{
			_connectionString = connectionString;
		}

		public async Task<List<EmployeeDetailsRepo>> GetAllEmployeesAsync()
		{

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				SqlCommand selectCommand = new SqlCommand(QueriesClass.SelectEmployeeDetails, connection);

				SqlDataReader reader = await selectCommand.ExecuteReaderAsync();

				List<EmployeeDetailsRepo> employees = Mapper.MapEmployeeListFromSqlDataReader(reader);


				connection.Close();
				connection.Dispose();
				return employees;
			}
		}

		public async Task<EmployeeDetailsRepo> GetEmployeeDetailsAsync(int id)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				SqlCommand selectCommand = new SqlCommand(QueriesClass.SelectEmployeeDetail, connection);
				selectCommand.Parameters.AddWithValue("id", id);

				SqlDataReader reader = await selectCommand.ExecuteReaderAsync();

				EmployeeDetailsRepo employee = Mapper.MapEmployeeFromSqlDataReader(reader);

				connection.Close();
				connection.Dispose();
				return employee;
			}
		}

		public async Task<bool> CreateEmployeeAsync(CreateOrUpdateEmployeeDetailsRepo employeeDetails)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				SqlCommand createCommand = new SqlCommand(QueriesClass.CreateEmployee, connection);

				// Parameters
				createCommand.Parameters.AddWithValue("name", employeeDetails.Name);
				createCommand.Parameters.AddWithValue("email", employeeDetails.EmailAddress);
				createCommand.Parameters.AddWithValue("salary", employeeDetails.Salary);
				createCommand.Parameters.AddWithValue("departmentId", employeeDetails.DepartmentId);

				int rowAffected;
				rowAffected = await createCommand.ExecuteNonQueryAsync();


				// Connection Close
				connection.Close();
				connection.Dispose();

				if (rowAffected == 1)
				{
					return true;
				}

				return false;
			}
		}


		public async Task<bool> UpdateEmployeeAsync(int empId, CreateOrUpdateEmployeeDetailsRepo employeeDetails)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				SqlCommand updateCommand = new SqlCommand(QueriesClass.UpdateEmployee, connection);

				// Parameters
				updateCommand.Parameters.AddWithValue("name", employeeDetails.Name);
				updateCommand.Parameters.AddWithValue("email", employeeDetails.EmailAddress);
				updateCommand.Parameters.AddWithValue("salary", employeeDetails.Salary);
				updateCommand.Parameters.AddWithValue("depId", employeeDetails.DepartmentId);
				updateCommand.Parameters.AddWithValue("empId", empId);

				int rowAffected = await updateCommand.ExecuteNonQueryAsync();

				// Connection Close
				connection.Close();
				connection.Dispose();

				if (rowAffected == 1)
				{
					return true;
				}

				return false;
			}
		}

		public async Task<bool> DeleteEmployeeAsync(int empId)
		{
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				SqlCommand deleteCommand = new SqlCommand(QueriesClass.DeleteEmployee, connection);

				deleteCommand.Parameters.AddWithValue("empId", empId);

				int rowAffected = await deleteCommand.ExecuteNonQueryAsync();

				// Connection Close
				connection.Close();
				connection.Dispose();

				if (rowAffected == 1)
				{
					return true;
				}

				return false;
			}
		}

	}

}
