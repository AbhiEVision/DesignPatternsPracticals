using DesignPatterns.AbstractFactory.BAL.Interfaces;

namespace DesignPatterns.AbstractFactory.BAL.Implemantations.Department
{
	public class SalesDepartment : IDepartment
	{
		private readonly double _overTimePayPerHour = 352.12;

		public double CalculateOverTimePay(int hour)
		{
			return _overTimePayPerHour * hour;
		}
	}
}
