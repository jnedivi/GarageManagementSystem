using System;
using System.Text;

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

        public ElectricBasedEngine(float i_RemainingTimeOnBattery, float i_MaxBatteryLife)
        {
            if (i_RemainingTimeOnBattery > i_MaxBatteryLife || i_RemainingTimeOnBattery < 0)
            {
                throw new ValueOutOfRangeException("Remaining Time On Battery", 0.0f, i_MaxBatteryLife);
            }

            m_RemainingTimeOnBattery = i_RemainingTimeOnBattery;
            m_MaxBatteryLife = i_MaxBatteryLife;
        }

        public void Recharge(float i_HoursToRecharge, ref Vehicle io_Vehicle)
		{
            if(i_HoursToRecharge + RemainingTimeOnBattery > MaxBatteryLife)
            {
                throw new ValueOutOfRangeException("Hours To Recharge", 0.0f, MaxBatteryLife - RemainingTimeOnBattery);
            }

            RemainingTimeOnBattery += i_HoursToRecharge;
		}

        public override string ToString()
        {
            string output = string.Format(@"Remaining Time On Battery: {0}
Max Battery Life: {1}", RemainingTimeOnBattery, MaxBatteryLife);

            return output;
        }
    }
}
