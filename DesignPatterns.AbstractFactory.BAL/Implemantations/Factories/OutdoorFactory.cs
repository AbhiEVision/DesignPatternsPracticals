using DesignPatterns.AbstractFactory.BAL.Implemantations.Department;
using DesignPatterns.AbstractFactory.BAL.Interfaces;

namespace DesignPatterns.AbstractFactory.BAL.Implemantations.Factories
{
	internal class OutdoorFactory : IFactory
	{
		public IDepartment GetDepartment(string typeOfDepartment)
		{
			switch (typeOfDepartment)
			{
				case "Sales":
					return new SalesDepartment();

				case "OnSite":
					return new OnSiteDepartment();

				default:
					throw new ArgumentException("Plese enter valid Department type");
			}
		}
	}
}
