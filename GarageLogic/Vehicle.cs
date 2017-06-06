using System;
namespace GarageLogic
{

    public abstract class Vehicle
    {


        private string m_ModelName;
        private string m_LicenseNumber;
        private float m_RemainingEnergyPercentage;

        public class Wheel
        {
            private string m_ManufacturerName;
            private float m_CurrentAirPressure;
            private float m_ReccomendedAirPressure;

            private void inflateAction(float i_AirToAdd)
            {
                if (this.m_CurrentAirPressure + i_AirToAdd <= this.m_ReccomendedAirPressure)
                {
                    this.m_CurrentAirPressure += i_AirToAdd;
                }
            }


        }

        /*** Getters and Setters ***/
        public string ModelName
        {

            get
            {
                return this.m_ModelName;
            }

            set
            {


            }

        }
        /*** Getters and Setters ***/
    }
}
