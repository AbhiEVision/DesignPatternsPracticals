using DesignPatterns.Factory.BAL.Interfaces;

namespace DesignPatterns.Factory.BAL.Departments
{
	internal class ITDepartment : IDepartment
	{
		private readonly double _overTimePayPerHour = 400;

		public double CalculateOverTimePay(int hour)
		{
			return _overTimePayPerHour * hour;
		}
	}
}
