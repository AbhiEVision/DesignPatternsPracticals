using DesignPatterns.Factory.BAL.Interfaces;

namespace DesignPatterns.Factory.BAL.Departments
{
	internal class HRDepartment : IDepartment
	{
		private readonly double _overTimePayPerHour = 251.99;

		public double CalculateOverTimePay(int hour)
		{
			return _overTimePayPerHour * hour;
		}
	}
}
