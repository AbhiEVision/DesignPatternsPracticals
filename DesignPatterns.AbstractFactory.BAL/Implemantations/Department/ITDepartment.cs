using DesignPatterns.AbstractFactory.BAL.Interfaces;

namespace DesignPatterns.AbstractFactory.BAL.Implemantations.Department
{
	public class ITDepartment : IDepartment
	{
		private readonly double _overTimePayPerHour = 253.12;

		public double CalculateOverTimePay(int hour)
		{
			return _overTimePayPerHour * hour;
		}
	}
}
