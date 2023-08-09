using DesignPatterns.AbstractFactory.BAL.Interfaces;

namespace DesignPatterns.AbstractFactory.BAL.Implemantations.Department
{
	public class AdminDepartment : IDepartment
	{
		private readonly double _overTimePayPerHour = 500.99;

		public double CalculateOverTimePay(int hour)
		{
			return _overTimePayPerHour * hour;
		}
	}
}
