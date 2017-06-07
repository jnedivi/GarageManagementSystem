using System;
namespace GarageLogic
{

    public abstract class Vehicle
    {

		/*** Data Members ***/

		private string m_ModelName;
        private string m_LicenseNumber;
        private float m_RemainingEnergyPercentage;
        private Wheels m_VehicleWheels;
        private eVehicleStatus m_VehicleStatus;
        private int m_NumberOfTires;

		/*** Getters and Setters ***/

		public string ModelName
		{
			get { return this.m_ModelName; }
			set { this.m_ModelName = value; }
		}
		public string LicenseNumber
		{
			get { return this.m_LicenseNumber; }
			set { this.m_LicenseNumber = value; }
		}
		public float RemainingEnergyPercentage
		{
			get { return this.m_RemainingEnergyPercentage; }
			set { this.m_RemainingEnergyPercentage = value; }
		}
		public eVehicleStatus VehicleStatus
		{
			get { return this.m_VehicleStatus; }
			set { this.m_VehicleStatus = value; }
		}
		public Wheels VehicleWheels
		{
			get { return this.m_VehicleWheels; }
			set { this.m_VehicleWheels = value; }
		}




		/*** Class Logic ***/


        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            PayedFor
        }





		/*** Nested Class ***/
		public class Wheels
        {

			/*** Data Members ***/

			private string m_ManufacturerName;
            private float m_CurrentAirPressure;
            private float m_ReccomendedAirPressure;
            private byte m_NumberOfTires;
            private int donotin;


			/*** Getters and Setters ***/

			public string ManufacturerName
			{
				get { return this.m_ManufacturerName; }
				set { this.m_ManufacturerName = value; }
			}
            public byte NumberOfTires
			{
				get { return this.m_NumberOfTires; }
				set { this.m_NumberOfTires = value; }
			}
			public float CurrentAirPressure
			{
				get { return this.m_CurrentAirPressure; }
				set { this.m_CurrentAirPressure = value; }
			}
			public float ReccomendedAirPressure
			{
				get { return this.m_ReccomendedAirPressure; }
				set { this.m_ReccomendedAirPressure = value; }
			}


			/*** Class Logic ***/

			public void inflateAction(float i_AirToAdd)
            {
                if (this.m_CurrentAirPressure + i_AirToAdd <= this.m_ReccomendedAirPressure)
                {
                    this.m_CurrentAirPressure += i_AirToAdd;
                }
            }


        }

      
      

    }
}
