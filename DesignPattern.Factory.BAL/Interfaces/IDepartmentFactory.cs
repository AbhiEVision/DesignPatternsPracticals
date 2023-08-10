using DesignPatterns.Factory.BAL.Enum;

namespace DesignPatterns.Factory.BAL.Interfaces
{
	public interface IDepartmentFactory
	{
		IDepartment GetDepartment(DepartmentEnum department);
	}
}
