using DesignPatterns.AbstractFactory.BAL.Interfaces;

namespace DesignPatterns.AbstractFactory.BAL.Implemantations.Department
{
	public class OnSiteDepartment : IDepartment
	{
		private readonly double _overTimePayPerHour = 423.84;

		public double CalculateOverTimePay(int hour)
		{
			return _overTimePayPerHour * hour;
		}
	}
}
