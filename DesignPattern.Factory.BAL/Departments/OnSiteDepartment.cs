using DesignPatterns.Factory.BAL.Interfaces;

namespace DesignPatterns.Factory.BAL.Departments
{
	internal class OnSiteDepartment : IDepartment
	{
		private readonly double _overTimePayPerHour = 100;

		public double CalculateOverTimePay(int hour)
		{
			return _overTimePayPerHour * hour;
		}
	}
}
