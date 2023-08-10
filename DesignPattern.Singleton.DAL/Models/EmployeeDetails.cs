namespace DesignPatterns.Singleton.DAL.Models
{
	public class EmployeeDetails
	{
		public string Name { get; set; }

		public decimal Salary { get; set; }

		public string Department { get; set; }

		public string EmailAddress { get; set; } = null!;

		public DateOnly JoiningDate { get; set; }

		public string Status { get; set; }
	}
}
