using System;
using System.Text;

namespace GarageLogic
{
    public abstract class Truck : Vehicle
    {

        /*** Data Members ***/
        private const float k_MaxAirPressureTruck = 32.0f;
        private const int k_NumberOfWheelsForTruck = 12;
        private float m_MaxWeightAllowed;
        private bool m_HasHazardousMaterials;

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

        public Truck()
        {
            this.Wheels = CreateWheels(k_NumberOfWheelsForTruck, k_MaxAirPressureTruck);
        }

        private string toStringHasHazardousMaterial()
        {
            string answer;

            if (HasHazardousMaterials)
            {
                answer = "Yes";
            }
            else
            {
                answer = "No";
            }

            return answer;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            string truckOutput = string.Format(@"Is Carrying Hazardous Material?: {0}
Max Allowed Weight Load: {1}", toStringHasHazardousMaterial(), MaxWeightAllowed);

            output.Append(base.ToString());
            output.Append(truckOutput);

            return output.ToString();
        }
    }
}
