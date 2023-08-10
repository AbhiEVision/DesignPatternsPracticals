namespace DesignPatterns.CQRS.DAL.Model.Command
{
	public class CreateOrUpdateEmployeeModel
	{
		public string Name { get; set; } = null!;

		public decimal Salary { get; set; }

		public int DepartmentId { get; set; }

		public string EmailAddress { get; set; } = null!;

	}
}
