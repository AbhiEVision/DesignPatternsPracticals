using DesignPatterns.Repository.DAL.Models;
using System.Data.SqlClient;

namespace DesignPatterns.Repository.DAL.MapperClasses
{
	internal static class Mapper
	{
		public static List<EmployeeDetailsRepo> MapEmployeeListFromSqlDataReader(SqlDataReader reader)
		{
			List<EmployeeDetailsRepo> employees = new List<EmployeeDetailsRepo>();

			while (reader.Read())
			{
				//employee.Status = (StatusEnum)System.Enum.Parse(typeof(StatusEnum), reader[5].ToString());
				//employee.Department = (DepartmentEnum)System.Enum.Parse(typeof(DepartmentEnum), reader[2].ToString());

				EmployeeDetailsRepo employee = new EmployeeDetailsRepo();
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

		public static EmployeeDetailsRepo MapEmployeeFromSqlDataReader(SqlDataReader reader)
		{
			var employee = new EmployeeDetailsRepo();
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
