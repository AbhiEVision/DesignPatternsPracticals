using DesignPatterns.AbstractFactory.BAL.Interfaces;

namespace DesignPatterns.AbstractFactory.BAL.Implemantations.Factories
{
	public class AbstractFactory : IAbstractFactory
	{
		public IFactory GetFactory(string typeOfFactory)
		{
			switch (typeOfFactory)
			{
				case "Indoor":
					return new IndoorFactory();

				case "Outdoor":
					return new OutdoorFactory();

				default:
					throw new ArgumentException("Plese enter valid Factory Type");
			}
		}
	}
}
