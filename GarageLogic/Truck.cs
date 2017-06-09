using System;
namespace GarageLogic
{
    public abstract class Truck : Vehicle
    {

        /*** Data Members ***/
        private const float k_MaxAirPressureTruck = 32.0f;
        private const int k_NumberOfWheelsForTruck = 12;

        private float m_MaxWeightAllowed;
        private bool m_HasHazardousMaterials;


        public Truck()
        {
            this.Wheels = CreateWheels(k_NumberOfWheelsForTruck, k_MaxAirPressureTruck);
        }

        /*** Getters and Setters***/

        public float MaxWeightAllowed
        {
            get { return this.m_MaxWeightAllowed; }
            set { this.m_MaxWeightAllowed = value; }
        }
		public bool HasHazardousMaterials
		{
			get { return this.m_HasHazardousMaterials; }
			set { this.m_HasHazardousMaterials = value; }
		}
    }
}
