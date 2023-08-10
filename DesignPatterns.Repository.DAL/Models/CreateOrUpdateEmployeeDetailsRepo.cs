namespace DesignPatterns.Repository.DAL.Models
{
	public class CreateOrUpdateEmployeeDetailsRepo
	{
		public string Name { get; set; } = null!;

		public decimal Salary { get; set; }

		public int DepartmentId { get; set; }

		public string EmailAddress { get; set; } = null!;

	}
}
