using System;
namespace GarageLogic
{
	public class FuelBasedEngine
	{

		/*** Data Members ***/
		private float m_CurrentAmountOfFuel;
		private float m_MaxAmountOfFuel;
        private eFuelType m_FuelType;

        public FuelBasedEngine(float i_CurrentAmountOfFuel, float i_MaxAmountOfFuel, eFuelType i_FuelType)
        {
            if ((i_CurrentAmountOfFuel > i_MaxAmountOfFuel) || (i_CurrentAmountOfFuel < 0))
            {
                throw new ValueOutOfRangeException("Fuel Based Engine", 0.0f, i_MaxAmountOfFuel);
            }

            m_CurrentAmountOfFuel = i_CurrentAmountOfFuel;
            m_MaxAmountOfFuel = i_MaxAmountOfFuel;
            m_FuelType = i_FuelType;
        }

        /*** Getters and Setters ***/
        
        public float MaxAmountOfFuel
		{
			get { return this.m_MaxAmountOfFuel; }
			set { this.m_MaxAmountOfFuel = value; }
		}

		public eFuelType FuelType
		{
			get { return this.m_FuelType; }
			set { this.m_FuelType = value; }
		}

		public enum eFuelType
		{
			Soler,
			Octance95,
			Octance96,
			Octane98
		};

        /*** Class Logic ***/


        public void Refuel(float i_FuelToAdd, eFuelType i_FuelType, ref Vehicle io_Vehicle)
        {

            if (((m_CurrentAmountOfFuel + i_FuelToAdd) > MaxAmountOfFuel) || i_FuelToAdd < 0)
			{
                throw new ValueOutOfRangeException("Fuel based engine", 0f, MaxAmountOfFuel - m_CurrentAmountOfFuel);
			}

            if(i_FuelType != this.FuelType)
            {
                string givenFuelType = string.Format("{0}", i_FuelType);
                throw new System.ArgumentException("Fuel Based Engine", givenFuelType);
            }

            m_CurrentAmountOfFuel += i_FuelToAdd;
            io_Vehicle.RemainingEnergyPercentage = ((m_CurrentAmountOfFuel / MaxAmountOfFuel) * 100);
		}

        public override string ToString()
        {
            string output = string.Format(@"Current Amount Of Fuel In Liters: {0}
Max Amount Of Fuel In Liters: {1}
Fuel Type: {2}", m_CurrentAmountOfFuel, MaxAmountOfFuel, FuelType);

            return output;
        }
    }
}
