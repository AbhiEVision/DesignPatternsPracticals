using DesignPatterns.Factory.BAL.Interfaces;

namespace DesignPatterns.Factory.BAL.Departments
{
	internal class SalesDepartment : IDepartment
	{
		private readonly double _overTimePayPerHour = 123.1;

		public double CalculateOverTimePay(int hour)
		{
			return _overTimePayPerHour * hour;
		}
	}
}
