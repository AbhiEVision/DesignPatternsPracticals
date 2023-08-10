using DesignPatterns.Mediator.Queries;
using DesignPatterns.Repository.DAL.Interface;
using DesignPatterns.Repository.DAL.Models;
using MediatR;

namespace DesignPatterns.Mediator.Handlers
{
	public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDetailsRepo>
	{
		private readonly IEmployeeRepository _repository;

		public GetEmployeeByIdQueryHandler(IEmployeeRepository repository)
		{
			_repository = repository;
		}

		public async Task<EmployeeDetailsRepo> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
		{
			return await _repository.GetEmployeeDetailAsync(request.Id);
		}
	}

	public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, List<EmployeeDetailsRepo>>
	{
		private readonly IEmployeeRepository _repository;

		public GetEmployeeDetailsQueryHandler(IEmployeeRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<EmployeeDetailsRepo>> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
		{
			return (await _repository.GetEmployeeDetailsAsync()).ToList();
		}
	}
}
