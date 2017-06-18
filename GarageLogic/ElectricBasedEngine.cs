using System;
using System.Text;

namespace GarageLogic
{
	public class ElectricBasedEngine : Engine
	{
		/*** Data Members ***/

		private float m_RemainingTimeOnBattery;
		private float m_MaxBatteryLife;

        /*** Getters and Setters ***/

        public float RemainingTimeOnBattery
		{
			get { return this.m_RemainingTimeOnBattery; }
			set
            {
                this.m_RemainingTimeOnBattery = value;
                RemainingEnergyPercentage = value / MaxBatteryLife;
            }
		}

		public float MaxBatteryLife
		{
			get { return this.m_MaxBatteryLife; }
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

        public void Recharge(float i_HoursToRecharge)
		{
            if(i_HoursToRecharge + RemainingTimeOnBattery > MaxBatteryLife)
            {
                throw new ValueOutOfRangeException("Hours To Recharge", 0.0f, MaxBatteryLife - RemainingTimeOnBattery);
            }

            RemainingTimeOnBattery += i_HoursToRecharge;
            RemainingEnergyPercentage = (RemainingTimeOnBattery / MaxBatteryLife);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            string electricOutput = string.Format(@"Remaining Time On Battery: {0}
Max Battery Life: {1}", RemainingTimeOnBattery, MaxBatteryLife);

            output.Append(base.ToString());
            output.Append(electricOutput);

            return output.ToString();
        }
    }
}
