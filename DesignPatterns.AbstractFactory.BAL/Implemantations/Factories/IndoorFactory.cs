using DesignPatterns.AbstractFactory.BAL.Implemantations.Department;
using DesignPatterns.AbstractFactory.BAL.Interfaces;

namespace DesignPatterns.AbstractFactory.BAL.Implemantations.Factories
{
	internal class IndoorFactory : IFactory
	{
		public IDepartment GetDepartment(string typeOfDepartment)
		{
			switch (typeOfDepartment)
			{
				case "HR":
					return new HRDepartment();

				case "Admin":
					return new AdminDepartment();

				case "IT":
					return new ITDepartment();

				default:
					throw new ArgumentException("Plese enter valid Department type");
			}
		}
	}
}