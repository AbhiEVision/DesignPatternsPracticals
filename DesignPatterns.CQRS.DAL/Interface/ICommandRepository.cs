using DesignPatterns.CQRS.DAL.Model.Command;

namespace DesignPatterns.CQRS.DAL.Interface
{
	public interface ICommandRepository
	{
		Task<bool> CreateEmployee(CreateOrUpdateEmployeeModel employee);

		Task<bool> UpdateEmployee(int empId, CreateOrUpdateEmployeeModel employee);

		Task<bool> DeleteEmployee(int empId);
	}
}
