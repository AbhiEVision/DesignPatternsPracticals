using MediatR;

namespace DesignPatterns.Mediator.Commands
{
	public class UpdateEmployeeDataCommand : IRequest<bool>
	{
		public UpdateEmployeeDataCommand(int id, string name, decimal salary, int departmentId, string emailAddress)
		{
			Id = id;
			Name = name;
			Salary = salary;
			DepartmentId = departmentId;
			EmailAddress = emailAddress;
		}

		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public decimal Salary { get; set; }

		public int DepartmentId { get; set; }

		public string EmailAddress { get; set; } = null!;

	}

	public class CreateEmployeeCommand : IRequest<bool>
	{
		public CreateEmployeeCommand(string name, decimal salary, int departmentId, string emailAddress)
		{
			Name = name;
			Salary = salary;
			DepartmentId = departmentId;
			EmailAddress = emailAddress;
		}

		public string Name { get; set; } = null!;

		public decimal Salary { get; set; }

		public int DepartmentId { get; set; }

		public string EmailAddress { get; set; } = null!;

	}

	public class DeleteEmployeeCommand : IRequest<bool>
	{
		public DeleteEmployeeCommand(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
	}
}
