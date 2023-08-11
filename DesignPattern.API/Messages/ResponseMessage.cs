namespace DesignPattern.API.Messages
{
	public static class ResponseMessage
	{

		public readonly static string EmployeeCreated = "Employee created successfully!";

		public readonly static string EmployeeIsNotCreated = "While creating employee some error occurred!";

		public readonly static string EmployeeAlreadyExists = "Employee already exists with same email address!";

		public readonly static string SalaryLimitExceed = "Salary limit exceed!";

		public readonly static string DepartmentIsNotFound = "Please enter valid departmentId!";

		public readonly static string EmployeeUpdated = "Employee successfully updated";

		public readonly static string EmployeeIsNotUpdated = "While updating employee some error occurred!";

		public readonly static string InvalidData = "Please enter the valid data";

		public readonly static string EmployeeIsNotFound = "Requested employee data is not found!";

		public readonly static string NoEmployeeDataFound = "No employee registered";

		public readonly static string EmployeeIsDeleted = "Employee deleted Successfully!";

	}
}
