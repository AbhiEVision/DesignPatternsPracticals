namespace DesignPatterns.AbstractFactory.BAL.Database
{
	internal static class QueryClass
	{
		public static readonly string FetchEmployeeDepartment = "SELECT DepartmentId FROM tblEmployee WHERE EmployeeId = @empId";
	}
}
