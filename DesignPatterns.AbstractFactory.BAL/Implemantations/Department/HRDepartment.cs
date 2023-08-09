﻿using DesignPatterns.AbstractFactory.BAL.Interfaces;

namespace DesignPatterns.AbstractFactory.BAL.Implemantations.Department
{
	public class HRDepartment : IDepartment
	{
		private readonly double _overTimePayPerHour = 200.12;

		public double CalculateOverTimePay(int hour)
		{
			return _overTimePayPerHour * hour;
		}
	}
}
