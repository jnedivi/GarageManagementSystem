using System;
namespace GarageLogic
{
	public class FuelBasedEngine
	{

		/*** Data Members ***/

		private float m_CurrentAmountOfFuel;
		private float m_MaxAmountOfFuel;
        private bool m_IsFullAmountOfFuel;
        private eFuelType m_FuelType;


		/*** Getters and Setters ***/

		public float CurrentAmountOfFuel
		{
			get { return this.m_CurrentAmountOfFuel; }
			set { this.m_CurrentAmountOfFuel = value; }
		}
		public float MaxAmountOfFuel
		{
			get { return this.m_MaxAmountOfFuel; }
			set { this.m_MaxAmountOfFuel = value; }
		}
		public bool IsFullAmountOfFuel
		{
			get { return this.m_IsFullAmountOfFuel; }
			set { this.m_IsFullAmountOfFuel = value; }
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


		public void refuel(float i_FuelToAdd)
		{
			if ((m_CurrentAmountOfFuel + i_FuelToAdd) <= m_MaxAmountOfFuel)
			{
				m_CurrentAmountOfFuel += i_FuelToAdd;
			}
		}
	}
}
