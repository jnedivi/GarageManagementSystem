using System;
namespace GarageLogic
{
	public class ElectricBasedEngine
	{
		private float m_RemainingTimeOfOperation;
		private float m_MaxTimeOfOperation;

		private void recharge(float i_HoursToRecharge)
		{
			if ((m_RemainingTimeOfOperation + i_HoursToRecharge) <= m_MaxTimeOfOperation)
			{
				m_RemainingTimeOfOperation += i_HoursToRecharge;
			}
		}
	}

}
