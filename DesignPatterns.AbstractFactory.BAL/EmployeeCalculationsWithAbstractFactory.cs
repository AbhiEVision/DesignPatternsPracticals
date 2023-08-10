using DesignPatterns.AbstractFactory.BAL.Database;
using DesignPatterns.AbstractFactory.BAL.Interfaces;

namespace DesignPatterns.AbstractFactory.BAL
{
	public class EmployeeCalculationsWithAbstractFactory
	{
		private readonly IAbstractFactory _abstractFactory;
		private readonly ManageDatabaseForAbstractFactory _manageDatabaseForAbstractFactory;

		public EmployeeCalculationsWithAbstractFactory(IAbstractFactory abstractFactory, ManageDatabaseForAbstractFactory manageDatabaseForAbstractFactory)
		{
			_abstractFactory = abstractFactory;
			_manageDatabaseForAbstractFactory = manageDatabaseForAbstractFactory;
		}

		public async Task<double> CountTheOverTimePayByHoursAsync(int empId, int Hours)
		{
			int depId = await _manageDatabaseForAbstractFactory.GetEmployeeDepartment(empId);
			string typeOfFactory = GetTypeOfFactory(depId);
			string typeOfDepartment = GetTypeOfDepartment(depId);

			IFactory _factory = _abstractFactory.GetFactory(typeOfFactory);
			IDepartment _department = _factory.GetDepartment(typeOfDepartment);

			double pay = _department.CalculateOverTimePay(Hours);

			return pay;
		}

		private string GetTypeOfFactory(int depId)
		{
			if (depId <= 0)
			{
				throw new ArgumentException("Employee not found!");
			}
			else if (depId < 4)
			{
				return "Indoor";

			}
			else if (depId < 6)
			{
				return "Outdoor";

			}
			else
			{
				throw new ArgumentException("Requested employee is not found!");
			}
		}

		private string GetTypeOfDepartment(int depId)
		{
			switch (depId)
			{
				case 1:
					return "IT";

				case 2:
					return "Admin";

				case 3:
					return "HR";

				case 4:
					return "Sales";

				case 5:
					return "OnSite";

				default:
					throw new ArgumentException("Employee if not found!");
			}
		}

	}

}
