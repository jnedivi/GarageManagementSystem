using System;
namespace GarageLogic
{
	public class ElectricBasedEngine
	{
		/*** Data Members ***/

		private float m_RemainingTimeOfOperation;
		private float m_MaxTimeOfOperation;

		/*** Getters and Setters ***/

		public float RemainingTimeOfOperation
		{
			get { return this.m_RemainingTimeOfOperation; }
			set { this.m_RemainingTimeOfOperation = value; }
		}
		public float MaxTimeOfOperation
		{
			get { return this.m_MaxTimeOfOperation; }
			set { this.m_MaxTimeOfOperation = value; }
		}



		/*** Class Logic ***/

		public void recharge(float i_HoursToRecharge)
		{
			if ((m_RemainingTimeOfOperation + i_HoursToRecharge) <= m_MaxTimeOfOperation)
			{
				m_RemainingTimeOfOperation += i_HoursToRecharge;
			}
		}
	}

}
