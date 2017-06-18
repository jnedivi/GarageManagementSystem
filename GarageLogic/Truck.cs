﻿using System;
using System.Text;
using System.Collections.Generic;

namespace GarageLogic
{
    public abstract class Truck : Vehicle
    {
        /*** Constants ***/

        private const float k_MaxAirPressureTruck = 32.0f;
        private const byte k_NumberOfWheelsForTruck = 12;

        /*** Data Members ***/

        private float m_MaxWeightAllowed;
        private bool m_HasHazardousMaterials;

        /*** Getters and Setters***/

        public float MaxWeightAllowed
        {
            get { return this.m_MaxWeightAllowed; }
            set { m_MaxWeightAllowed = value; }
        }

        public bool HasHazardousMaterials
        {
            get { return m_HasHazardousMaterials; }
            set { m_HasHazardousMaterials = value; }
        }

		/*** Constructor ***/

		protected Truck(string i_LicenceNumber, string i_OwnerName, string i_OwnerPhoneNumber, string i_ModelName)
            : base(i_LicenceNumber, i_OwnerName, i_OwnerPhoneNumber, i_ModelName , k_NumberOfWheelsForTruck, k_MaxAirPressureTruck)
        {
           MaxWeightAllowed = 0.0f;
           HasHazardousMaterials = false;
   
        }

		/*** Class Logic ***/

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

            string truckOutput = string.Format(@"Truck Information:
Is Carrying Hazardous Material?: {0}
Max Allowed Weight Load: {1}
", toStringBoolYesOrNo(m_HasHazardousMaterials), MaxWeightAllowed);

            output.Append(base.ToString());
            output.Append(truckOutput);
            output.Append(Environment.NewLine);

            return output.ToString();
        }
    }
}
