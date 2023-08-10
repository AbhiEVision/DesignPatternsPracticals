using DesignPatterns.Mediator.Commands;
using DesignPatterns.Repository.DAL.Interface;
using DesignPatterns.Repository.DAL.Models;
using MediatR;

namespace DesignPatterns.Mediator.Handlers
{
	public class UpdateEmployeeDataCommandHandler : IRequestHandler<UpdateEmployeeDataCommand, bool>
	{
		private readonly IEmployeeRepository _repository;

		public UpdateEmployeeDataCommandHandler(IEmployeeRepository repository)
		{
			_repository = repository;
		}

		async Task<bool> IRequestHandler<UpdateEmployeeDataCommand, bool>.Handle(UpdateEmployeeDataCommand request, CancellationToken cancellationToken)
		{
			CreateOrUpdateEmployeeDetailsRepo model = new CreateOrUpdateEmployeeDetailsRepo();
			model.EmailAddress = request.EmailAddress;
			model.Salary = request.Salary;
			model.DepartmentId = request.DepartmentId;
			model.Name = request.Name;

			return await _repository.UpdateEmployeeAsync(request.Id, model);
		}
	}
	public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, bool>
	{
		private readonly IEmployeeRepository _repository;

		public CreateEmployeeCommandHandler(IEmployeeRepository repository)
		{
			_repository = repository;
		}

		public async Task<bool> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
		{
			CreateOrUpdateEmployeeDetailsRepo model = new CreateOrUpdateEmployeeDetailsRepo();
			model.EmailAddress = request.EmailAddress;
			model.Salary = request.Salary;
			model.DepartmentId = request.DepartmentId;
			model.Name = request.Name;

			return await _repository.CreateEmployeeAsync(model);
		}
	}

	public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
	{
		private readonly IEmployeeRepository _repository;

		public DeleteEmployeeCommandHandler(IEmployeeRepository repository)
		{
			_repository = repository;
		}

		public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
		{
			return await _repository.DeleteEmployeeAsync(request.Id);
		}
	}
}
