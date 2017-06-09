﻿using System;
using System.Collections.Generic;

namespace GarageLogic
{
    public class Garage
    {
        /*** Data Members ***/
        private List<Dictionary<string, object>> m_Garage;
		private List<Vehicle> m_GarageVehicles;


		/*** Getters and Setters ***/

		public List<Vehicle> GarageVehicles
		{
			get { return this.m_GarageVehicles; }
			set { this.m_GarageVehicles = value; }
		}


		public Garage()
        {
        }


        /*** Garage Logic Methods ***/

		/* 1) Insert new Vehicle into Garage */
        public void InsertNewVehicleIntoGarage(Vehicle i_Vehicle)
		{
            //TODO: add new vehicle (if does not exits already)
		}

		/* 2) Display list of licence numbers */
        public string DisplayListOfLicenceNumbers(eVehicleStatus i_Status)
		{
            //TODO: filter and display list 

            return null;
		}

		/* 3) Change a Vehicle's status */
        public void ChangeVehicleStatus(Vehicle i_Vehicle , eVehicleStatus i_Status)
		{
            
		}

		/* 4) Inflate tires */
		public void InflateTiresToMax(Vehicle i_Vehicle)
		{
            //TODO: inflate to maximum
		}

		/* 5) Refuel a vehicle */
        public void RefuelVehicle(string i_LicenseNumber, FuelBasedEngine.eFuelType i_FuelType, float i_AmountToRefuel)
		{
            Vehicle vehicle;
            GetVehicle(i_LicenseNumber, out vehicle);

            if(vehicle == null)
            {
                throw new System.ArgumentException("This vehicle doesn't exist in the garage.");
            }
            // TODO: check if vehicle fuel based

            FuelBasedEngine.Refuel(i_AmountToRefuel, i_FuelType, ref vehicle);
		}

		/* 6) Charge a electric vehice. */
		public void ChargeElectricVehice(Vehicle i_Vehicle, float i_MinutsToCharge)
		{

		}

		/* 7) Display vehicle information */
        public void DisplayVehicleInformation(Vehicle i_Vehicle)
		{
            //Display vehicle information 
            //(License number, Model name, Owner name, 
            //Status in garage, Tire specifications (manufacturer and air pressure),
            //Fuel status + Fuel type / Battery status, other relevant information based on vehicle type)

            Dictionary<string, string> vehicleInformation = i_Vehicle.CreateVehicleInformation();
            Dictionary<string, string>.KeyCollection keys = vehicleInformation.Keys;

            foreach(string key in keys)
            {

            }
		}

        public bool GetVehicle(string i_LicenseNumber, out Vehicle o_Vehicle)
        {
            bool vehicleExists = false;
            o_Vehicle = null;

            foreach(Vehicle vehicle in m_GarageVehicles)
            {
                if(i_LicenseNumber == vehicle.LicenseNumber)
                {
                    vehicleExists = true;
                    o_Vehicle = vehicle;
                    break;
                }
            }

            return vehicleExists;
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
