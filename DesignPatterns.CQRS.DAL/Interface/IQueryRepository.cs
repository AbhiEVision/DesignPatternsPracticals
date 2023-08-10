using DesignPatterns.CQRS.DAL.Model.Query;

namespace DesignPatterns.CQRS.DAL.Interface
{
	public interface IQueryRepository
	{
		Task<IEnumerable<EmployeeDetails>> GetEmployeeDetails();

		Task<EmployeeDetails> GetEmployeeDetails(int id);
	}
}
