using System;
namespace GarageLogic
{
	public abstract class FuelBasedEngine
	{


		private enum eFeulType
		{
			Soler,
			Octance95,
			Octance96,
			Octane98
		};

		private float m_CurrentAmountOfFuel;
		private float m_MaxAmountOfFuel;

		private void refuel(float i_FuelToAdd)
		{
			if ((m_CurrentAmountOfFuel + i_FuelToAdd) <= m_MaxAmountOfFuel)
			{
				m_CurrentAmountOfFuel += i_FuelToAdd;
			}
		}
	}
}
