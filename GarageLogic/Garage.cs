﻿﻿﻿using System;
using System.Collections.Generic;

namespace GarageLogic
{
    public class Garage
    {

        /*** Data Members ***/
        private const string k_VehicleDoesntExist = "This vehicle is not in the garage.";
        private readonly Dictionary<string, Vehicle> m_GarageVehicles;

        /*** Getters and Setters ***/

        public Dictionary<string, Vehicle> GarageVehicles
        {
            get { return this.m_GarageVehicles; }
        }

        public Garage()
        {
            m_GarageVehicles = new Dictionary<string, Vehicle>();
        }

        /*** Class Logic ***/

        public bool IsInGarage(string i_LicenseNumber)
        {
            return this.m_GarageVehicles.ContainsKey(i_LicenseNumber);
        }

        public void StatusInRepairedUpdate(string i_LicenseNumber)
        {
			Vehicle vehicleToChange;
			if (this.m_GarageVehicles.TryGetValue(i_LicenseNumber, out vehicleToChange))
			{
				vehicleToChange.VehicleStatus = Vehicle.eVehicleStatus.InRepair;
			}
        }

		public void InsertNewVehicle(Factory.eVehicleType i_VehicleType, string i_LicenseNumber, string i_OwnerName,
                                     string i_OwnerPhoneNumber, string i_ModelName)
        {
            Vehicle currentVehicle;
            currentVehicle = Factory.CreateNewVehicle(i_VehicleType, i_LicenseNumber, i_OwnerName, i_OwnerPhoneNumber, i_ModelName);
            this.m_GarageVehicles.Add(i_LicenseNumber , currentVehicle);
        }

        public Dictionary<string, Vehicle>.KeyCollection GetListOfLicenceNumbers()
        { 
            return GarageVehicles.Keys;
		}

        public Dictionary<string, Vehicle>.KeyCollection GetFilteredListOfLicenseNumbers(Vehicle.eVehicleStatus i_VehicleStatus)
        {
            return filteredVehiclesByStatus(i_VehicleStatus).Keys;
        }

        private Dictionary<string, Vehicle> filteredVehiclesByStatus(Vehicle.eVehicleStatus i_VehicleStatus)
        {
            Dictionary<string, Vehicle> filteredVehicles = new Dictionary<string, Vehicle>();

            foreach(Vehicle vehicle in m_GarageVehicles.Values)
            {
                if(vehicle.VehicleStatus == i_VehicleStatus)
                {
                    filteredVehicles.Add(vehicle.LicenseNumber, vehicle);
                }
            }

            return filteredVehicles;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber , Vehicle.eVehicleStatus i_Status)
		{
            Vehicle vehicle;
            bool isInGarage = GetVehicle(i_LicenseNumber, out vehicle);

            if (!isInGarage)
            {
                throw new System.ArgumentException(k_VehicleDoesntExist);
            }

            vehicle.VehicleStatus = i_Status;
            GarageVehicles[i_LicenseNumber] = vehicle;
        }

		public void InflateTiresToMax(string i_LicenseNumber)
		{
            Vehicle vehicle;
            bool isInGarage = GetVehicle(i_LicenseNumber, out vehicle);

            if (!isInGarage)
            {
                throw new System.ArgumentException(k_VehicleDoesntExist);
            }

            vehicle.InflateAllWheelsToMax();
            GarageVehicles[i_LicenseNumber] = vehicle;
        }

        public void RefuelVehicle(string i_LicenseNumber, FuelBasedEngine.eFuelType i_FuelType, float i_AmountToRefuel)
		{
            Vehicle vehicle;
            bool isInGarage = GetVehicle(i_LicenseNumber, out vehicle);

            if(!isInGarage)
            {
                throw new System.ArgumentException(k_VehicleDoesntExist);
            }

            FuelBasedEngine engine = vehicle.Engine as FuelBasedEngine;

            if(engine != null)
            {
                engine.Refuel(i_AmountToRefuel, i_FuelType);
                m_GarageVehicles[i_LicenseNumber] = vehicle;
            }
            else
            {
                throw new FormatException("Not Fuel Based Vehicle");
            }
		}

		public void ChargeElectricVehice(string i_LicenseNumber, float i_MinutesToCharge)
		{
            Vehicle vehicle;
            bool isInGarage = GetVehicle(i_LicenseNumber, out vehicle);

            if (!isInGarage)
            {
                throw new System.ArgumentException(k_VehicleDoesntExist);
            }

            ElectricBasedEngine engine = vehicle.Engine as ElectricBasedEngine;
            float hoursToRecharge = i_MinutesToCharge / 60;

            if(engine != null)
            {
                engine.Recharge(hoursToRecharge);
                m_GarageVehicles[i_LicenseNumber] = vehicle;
            }
            else
            {
                throw new FormatException("Charge");
            }
        }

        public bool GetVehicle(string i_LicenseNumber, out Vehicle o_Vehicle)
        {
            bool vehicleIsInGarage = m_GarageVehicles.TryGetValue(i_LicenseNumber, out o_Vehicle);

            return vehicleIsInGarage;
        }
    }
}

