﻿using System;
using System.Collections.Generic;

namespace GarageLogic
{
    public class Garage
    {
        public enum eVehicleType
        {
            FuelBasedMotorcycle,
            FuelBasedCar,
            ElectricMotorcycle,
            ElectricCar,
            FuelBasedTruck
        }

        /*** Data Members ***/
        private const string k_VehicleDoesntExist = "This vehicle is not in the garage";
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
        public void InsertNewVehicleIntoGarage(Vehicle i_Vehicle, )
        {

        }

        public void CreateVehicleIfNotInGarage(eVehicleType i_VehicleType, string i_LicenseNumber, out bool io_VehicleExists, out Vehicle o_Vehicle)
        {
            io_VehicleExists = GarageVehicles.TryGetValue(i_LicenseNumber, out o_Vehicle);

            if (!io_VehicleExists)
            {
                switch (i_VehicleType)
                {
                    case eVehicleType.FuelBasedMotorcycle:
                        o_Vehicle = new FuelBasedMotorcycle();
                        break;
                    case eVehicleType.ElectricMotorcycle:
                        o_Vehicle = new ElectricMotorcycle();
                        break;
                    case eVehicleType.FuelBasedCar:
                        o_Vehicle = new FuelBasedCar();
                        break;
                    case eVehicleType.ElectricCar:
                        o_Vehicle = new ElectricCar();
                        break;
                    case eVehicleType.FuelBasedTruck:
                        o_Vehicle = new FuelBasedTruck();
                        break;
                    default:
                        throw new ArgumentException("Vehicle type is not supported");
                }
            }
        }

        /* 2) Display list of licence numbers */
        public string DisplayListOfLicenceNumbers()
        { 
            return GarageVehicles.Keys.ToString();
		}

        public string DisplayFilteredListOfLicenseNumbers(Vehicle.eVehicleStatus i_VehicleStatus)
        {
            return FilteredVehiclesByStatus(i_VehicleStatus).Keys.ToString();
        }

        public Dictionary<string, Vehicle> FilteredVehiclesByStatus(Vehicle.eVehicleStatus i_VehicleStatus)
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
            bool isInGarage = GarageVehicles.TryGetValue(i_LicenseNumber, out vehicle);

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
            bool isInGarage = GarageVehicles.TryGetValue(i_LicenseNumber, out vehicle);

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
            bool isInGarage = GarageVehicles.TryGetValue(i_LicenseNumber, out vehicle);

            if(!isInGarage)
            {
                throw new System.ArgumentException(k_VehicleDoesntExist);
            }
            // TODO: check if vehicle fuel based

            if(vehicle.)

            vehicle.FuelBasedEngine.Refuel(i_AmountToRefuel, i_FuelType, ref vehicle);
		}

		/* 6) Charge a electric vehice. */
		public void ChargeElectricVehice(Vehicle i_Vehicle, float i_MinutsToCharge)
		{

		}

		/* 7) Display vehicle information */
        // toString() method
  
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
