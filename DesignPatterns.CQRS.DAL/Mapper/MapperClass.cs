using DesignPatterns.CQRS.DAL.Model.Query;
using System.Data.SqlClient;

namespace DesignPatterns.CQRS.DAL.Mapper
{
	public class MapperClass
	{
		public static List<EmployeeDetails> MapEmployeeListFromSqlDataReader(SqlDataReader reader)
		{
			List<EmployeeDetails> employees = new List<EmployeeDetails>();

			while (reader.Read())
			{
				EmployeeDetails employee = new EmployeeDetails();
				employee.Name = reader.GetString(0);
				employee.Salary = reader.GetDecimal(1);
				employee.Department = reader.GetString(2);
				employee.EmailAddress = reader.GetString(3);
				var datedTime = reader.GetDateTime(4);
				employee.JoiningDate = new DateOnly(datedTime.Year, datedTime.Month, datedTime.Day);
				employee.Status = reader.GetString(5);
				employees.Add(employee);
			}
			return employees;
		}

		public static EmployeeDetails MapEmployeeFromSqlDataReader(SqlDataReader reader)
		{
			var employee = new EmployeeDetails();
			if (!reader.Read())
			{
				return null;
			}
			employee.Name = reader.GetString(0);
			employee.Salary = reader.GetDecimal(1);
			employee.Department = reader.GetString(2);
			employee.EmailAddress = reader.GetString(3);
			var datedTime = reader.GetDateTime(4);
			employee.JoiningDate = new DateOnly(datedTime.Year, datedTime.Month, datedTime.Day);
			employee.Status = reader.GetString(5);
			return employee;
		}
	}
}
