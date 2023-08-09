using DesignPattern.Factory.BAL.Enum;

namespace DesignPattern.Factory.BAL.Interfaces
{
	public interface IDepartmentFactory
	{
		IDepartment GetDepartment(DepartmentEnum department);
	}
}
