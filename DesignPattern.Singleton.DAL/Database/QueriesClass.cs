namespace DesignPattern.Singleton.DAL.Database
{
	internal static class QueriesClass
	{
		public static readonly string SelectEmployeeDetails = "SELECT emp.Name, emp.Salary, dep.DepartmentName, emp.EmailAddress, emp.JoiningDate, sta.StatusName " +
			"FROM tblEmployee emp " +
			"INNER JOIN tblDepartement dep ON dep.DepartmentId = emp.DepartmentId " +
			"INNER JOIN tblStatus sta ON sta.StatusId = emp.StatusId";

		public static readonly string SelectEmployeeDetail = "SELECT emp.Name, emp.Salary, dep.DepartmentName, emp.EmailAddress, emp.JoiningDate, sta.StatusName " +
			"FROM tblEmployee emp " +
			"INNER JOIN tblDepartement dep ON dep.DepartmentId = emp.DepartmentId " +
			"INNER JOIN tblStatus sta ON sta.StatusId = emp.StatusId " +
			"where emp.EmployeeId = @id";

		public static readonly string CreateEmployee = "INSERT INTO tblEmployee(Name,Salary,DepartmentId,EmailAddress) " +
			"VALUES ( @name, @salary, @departmentId, @email)";

		public static readonly string UpdateEmployee = "UPDATE tblEmployee " +
			"SET Name = @name, Salary = @salary, DepartmentId = @depId, EmailAddress = @email WHERE EmployeeId = @empId";

		public static readonly string DeleteEmployee = "UPDATE tblEmployee " +
			"SET isActive = 0 WHERE EmployeeId = @empId";

	}
}
