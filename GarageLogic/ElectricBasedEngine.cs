using System;
namespace GarageLogic
{
	public class ElectricBasedEngine
	{
		/*** Data Members ***/

		private float m_RemainingTimeOnBattery;
		private float m_MaxBatteryLife;

		/*** Getters and Setters ***/

		public float RemainingTimeOnBattery
		{
			get { return this.m_RemainingTimeOnBattery; }
			set { this.m_RemainingTimeOnBattery = value; }
		}
		public float MaxBatteryLife
		{
			get { return this.m_MaxBatteryLife; }
			set { this.m_MaxBatteryLife = value; }
		}

		/*** Class Logic ***/

		public void recharge(float i_HoursToRecharge)
		{
			if ((m_RemainingTimeOnBattery + i_HoursToRecharge) <= m_MaxBatteryLife)
			{
				m_RemainingTimeOnBattery += i_HoursToRecharge;
			}
		}
	}
}
