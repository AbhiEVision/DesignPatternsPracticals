namespace DesignPatterns.AbstractFactory.BAL.Interfaces
{
	public interface IFactory
	{
		IDepartment GetDepartment(string typeOfDepartment);
	}
}
