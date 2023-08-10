using DesignPatterns.Repository.DAL.Models;

namespace DesignPatterns.Repository.DAL.Interface
{
	public interface IEmployeeRepository
	{
		Task<bool> CreateEmployeeAsync(CreateOrUpdateEmployeeDetailsRepo employeeDetails);

		Task<bool> UpdateEmployeeAsync(int empId, CreateOrUpdateEmployeeDetailsRepo employeeDetails);

		Task<bool> DeleteEmployeeAsync(int empId);

		Task<IEnumerable<EmployeeDetailsRepo>> GetEmployeeDetailsAsync();

		Task<EmployeeDetailsRepo> GetEmployeeDetailAsync(int empId);
	}
}
