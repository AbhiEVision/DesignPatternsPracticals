using DesignPatterns.Factory.BAL.Database;
using DesignPatterns.Factory.BAL.Enum;
using DesignPatterns.Factory.BAL.Interfaces;

namespace DesignPatterns.Factory.BAL
{
	public class EmployeeCalculations
	{
		private readonly IDepartmentFactory _departmentFactory;
		private readonly ManageDatabaseForFactory _connectionClass;

		public EmployeeCalculations(IDepartmentFactory departmentFactory, ManageDatabaseForFactory connectionClass)
		{
			_departmentFactory = departmentFactory;
			_connectionClass = connectionClass;
		}

		public async Task<double> DoOvertimeCalculation(int empId, int hours)
		{
			int depId = await _connectionClass.GetEmployeeDepartment(empId);

			IDepartment department = _departmentFactory.GetDepartment((DepartmentEnum)depId);

			double hourlyOverPay = department.CalculateOverTimePay(hours);

			return hourlyOverPay;
		}
	}
}
