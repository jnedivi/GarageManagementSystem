using System;
namespace GarageLogic
{

	public abstract class Car : Vehicle
	{

        /*** Data Members ***/

        private const float k_MaxAirPressureCar = 30.0f;
        private const int k_NumberOfWheelsForCar = 4;

		private eColor m_Color;
        private eNumOfDoors m_NumberOfDoors;
        
        public Car()
        {
            this.Wheels = CreateWheels(k_NumberOfWheelsForCar, k_MaxAirPressureCar);
        }

        /*public override void CreateVehicleInformation()
        {
            base.CreateVehicleInformation();
            this.m
        }*/

        /*** Getters and Setters***/

        public eColor Color
        {
            get { return this.m_Color; }
            set { this.m_Color = value; }
        }

		public eNumOfDoors NumberOfDoors
		{
			get { return this.m_NumberOfDoors; }
			set { this.m_NumberOfDoors = value; }
		}

		public enum eColor
		{
			Yellow,
			White,
			Black,
			Blue,
		}

		public enum eNumOfDoors
		{
			Two = 2,
			Three,
			Four,
			Five,
		}
	}
}
