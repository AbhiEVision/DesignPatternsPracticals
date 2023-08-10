using DesignPatterns.Factory.BAL.Departments;
using DesignPatterns.Factory.BAL.Enum;
using DesignPatterns.Factory.BAL.Interfaces;

namespace DesignPatterns.Factory.BAL.Factory
{
	public class DepartmentFactory : IDepartmentFactory
	{
		public IDepartment GetDepartment(DepartmentEnum department)
		{
			switch (department)
			{
				case DepartmentEnum.IT:
					return new ITDepartment();

				case DepartmentEnum.Admin:
					return new AdminDepartment();

				case DepartmentEnum.HR:
					return new HRDepartment();

				case DepartmentEnum.Sales:
					return new SalesDepartment();

				case DepartmentEnum.On_Site:
					return new OnSiteDepartment();

				default:
					throw new ArgumentException("No Employee Found");

			}
		}
	}
}
