namespace DesignPatterns.AbstractFactory.BAL.Interfaces
{
	public interface IAbstractFactory
	{
		IFactory GetFactory(string typeOfFactory);
	}
}
