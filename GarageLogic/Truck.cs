﻿using System;
using System.Text;
using System.Collections.Generic;

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

        public string MaxWeightAllowed
        {
            get { return this.m_MaxWeightAllowed.ToString(); }
            set
            {
                try
                {
                    m_MaxWeightAllowed = float.Parse(value);
                }
                catch (FormatException)
                {
                    throw new FormatException("Max Weight Allowed");
                }
            }
        }

		public String HasHazardousMaterials
		{
			get { return toStringBoolYesOrNo(m_HasHazardousMaterials); }
            set
            {
                try
                {
                    m_HasHazardousMaterials = bool.Parse(value);
                }
                catch (FormatException)
                {
                    throw new FormatException("Has Hazardous Materials");
                }
            }
		}

		protected Truck(string i_LicenceNumber, string i_OwnerName, string i_OwnerPhoneNumber, string i_ModelName, List<Vehicle.Wheel> i_Wheels)
			: base(i_LicenceNumber, i_OwnerName, i_OwnerPhoneNumber, i_ModelName, i_Wheels)
        {
            MaxWeightAllowed = 0.0f.ToString();
            HasHazardousMaterials = false.ToString();
            this.Wheels = CreateWheels(k_NumberOfWheelsForTruck, k_MaxAirPressureTruck);
        }

        private string toStringBoolYesOrNo(bool i_Bool)
        {
            string answer;

            if (i_Bool)
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
Max Allowed Weight Load: {1}", toStringBoolYesOrNo(m_HasHazardousMaterials), MaxWeightAllowed);

            output.Append(base.ToString());
            output.Append(truckOutput);
            output.Append(Environment.NewLine);

            return output.ToString();
        }
    }
}
