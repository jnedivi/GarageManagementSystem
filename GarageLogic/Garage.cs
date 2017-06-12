﻿﻿using System;
using System.Collections.Generic;

namespace GarageLogic
{
    public class Garage
    {
		

        /*** Data Members ***/
        private const string k_VehicleDoesntExist = "This vehicle is not in the garage.";
        private Dictionary<string, Vehicle> m_GarageVehicles;


        /*** Getters and Setters ***/

        public Dictionary<string, Vehicle> GarageVehicles
        {
            get { return this.m_GarageVehicles; }
        }


        public Garage()
        {
            m_GarageVehicles = new Dictionary<string, Vehicle>();
        }


        /*** Garage Logic Methods ***/

        /* 1) Insert new Vehicle into Garage */
        //public void InsertVehicleIntoGarage(Vehicle i_Vehicle)
        //{
        //    GarageVehicles.Add(i_Vehicle.LicenseNumber, i_Vehicle);
        //}

        //public void CreateVehicleIfNotInGarage(Factory.eVehicleType i_VehicleType, string i_LicenseNumber, out bool io_VehicleExists, out Vehicle o_Vehicle)
        //{
        //    io_VehicleExists = m_GarageVehicles.TryGetValue(i_LicenseNumber, out o_Vehicle);


        //    if (!io_VehicleExists)
        //    {
                

        //    }
        //}

        /*** alternative instet functions ***/
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

		/** created by j.w might not be necessary **/
		public void InsertNewVehicle(Factory.eVehicleType i_VehicleType, string i_LicenseNumber, string i_OwnerName,
                                     string i_OwnerPhoneNumber, string i_ModelName, List<float> i_WheelPressures, string i_WheelsManufactureName)
        {
            Vehicle currentVehicle;
            currentVehicle = Factory.CreateNewVehicle(i_VehicleType, i_LicenseNumber, i_OwnerName, i_OwnerPhoneNumber, i_ModelName, i_WheelPressures , i_WheelsManufactureName);
            this.m_GarageVehicles.Add(i_LicenseNumber , currentVehicle);

        }




        /* 2) Display list of licence numbers */
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

		/* 3) Change a Vehicle's status */
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

		/* 4) Inflate tires */
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

		/* 5) Refuel a vehicle */
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
            }
            else
            {
                throw new FormatException("Refuel");
            }

		}

		/* 6) Charge a electric vehice. */
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
            }
            else
            {
                throw new FormatException("Recharge");
            }
        }

		/* 7) Display vehicle information */
        // toString() method
        public bool GetVehicle(string i_LicenseNumber, out Vehicle o_Vehicle)
        {
            
            bool vehicleIsInGarage = m_GarageVehicles.TryGetValue(i_LicenseNumber, out o_Vehicle);

            return vehicleIsInGarage;
        }
    }
}

/*
 * 
 * 1. “Insert” a new vehicle into the garage. The user will be asked to select a
vehicle type out of the supported vehicle types, and to input the license
number of the vehicle. If the vehicle is already in the garage (based on
license number) the system will display an appropriate message and will use
the vehicle in the garage (and will change the vehicle status to “In Repair”), if
not, a new object of that vehicle type will be created and the user will be
prompted to input the values for the properties of his vehicle, according to the
type of vehicle he wishes to add.
2. Display a list of license numbers currently in the garage, with a filtering option
based on the status of each vehicle
3. Change a certain vehicle’s status (Prompting the user for the license number and
new desired status)
4. Inflate tires to maximum (Prompting the user for the license number)
5. Refuel a fuel-based vehicle (Prompting the user for the license number, fuel type
and amount to fill)
6. Charge an electric-based vehicle (Prompting the user for the license number
and number of minutes to charge)
7. Display vehicle information (License number, Model name, Owner name, Status in
garage, Tire specifications (manufacturer and air pressure), Fuel status + Fuel type /
Battery status, other relevant information based on vehicle type)
 * 
 */
