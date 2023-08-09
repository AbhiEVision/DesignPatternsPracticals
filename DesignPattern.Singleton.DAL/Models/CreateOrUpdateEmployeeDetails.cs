namespace DesignPattern.Singleton.DAL.Models
{
	public class CreateOrUpdateEmployeeDetails
	{
		public string Name { get; set; } = null!;

		public decimal Salary { get; set; }

		public int DepartmentId { get; set; }

		public string EmailAddress { get; set; } = null!;

	}
}
