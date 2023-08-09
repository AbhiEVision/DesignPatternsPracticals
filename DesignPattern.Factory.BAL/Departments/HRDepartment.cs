using DesignPattern.Factory.BAL.Interfaces;

namespace DesignPattern.Factory.BAL.Departments
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
