using System;
namespace GarageLogic
{
    public abstract class Truck : Vehicle
    {

        /*** Data Members ***/

        private float m_MaxWeightAllowed;
        private bool m_HasHazardousMaterials;


        public Truck()
        {
            this.NumberOfWheels = 12;
            this.Tires.MaxAirPressure = 32f;
            this.CreateTires(NumberOfWheels, this.Tires);
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
