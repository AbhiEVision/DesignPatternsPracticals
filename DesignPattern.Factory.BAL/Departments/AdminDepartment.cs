using DesignPatterns.Factory.BAL.Interfaces;

namespace DesignPatterns.Factory.BAL.Departments
{
	internal class AdminDepartment : IDepartment
	{
		private readonly double _overTimePayPerHour = 500.25;

		public double CalculateOverTimePay(int hour)
		{
			return _overTimePayPerHour * hour;
		}
	}
}
