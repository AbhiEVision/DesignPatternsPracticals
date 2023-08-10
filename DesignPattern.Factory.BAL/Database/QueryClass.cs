namespace DesignPatterns.Factory.BAL.Database
{
	public static class QueryClass
	{
		public readonly static string GetDepartmentQuery = "SELECT DepartmentId FROM tblEmployee WHERE EmployeeId = @empId";

	}
}
