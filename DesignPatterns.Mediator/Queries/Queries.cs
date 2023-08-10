using DesignPatterns.Repository.DAL.Models;
using MediatR;

namespace DesignPatterns.Mediator.Queries
{
	public class GetEmployeeByIdQuery : IRequest<EmployeeDetailsRepo>
	{
		public int Id { get; set; }
	}

	public class GetEmployeeDetailsQuery : IRequest<List<EmployeeDetailsRepo>>
	{

	}
}
