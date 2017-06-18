﻿﻿using System;
using System.Collections.Generic;
namespace GarageLogic
{
    public static class Factory
    {

		public enum eVehicleType
		{
			FuelBasedMotorcycle,
			FuelBasedCar,
			ElectricMotorcycle,
			ElectricCar,
			FuelBasedTruck,
		}

        public static Vehicle CreateNewVehicle(eVehicleType i_VehicleType, string i_LicenseNumber, string i_OwnerName,string i_OwnerPhoneNumber, string i_ModelName)
        {
            Vehicle newVehicle;

            switch(i_VehicleType)
            {
                case eVehicleType.FuelBasedMotorcycle:
                    newVehicle = new FuelBasedMotorcycle(i_LicenseNumber, i_OwnerName, i_OwnerPhoneNumber, i_ModelName);
                    break;
				case eVehicleType.FuelBasedCar:
                    newVehicle = new FuelBasedCar(i_LicenseNumber, i_OwnerName, i_OwnerPhoneNumber, i_ModelName);
					break;
				case eVehicleType.ElectricMotorcycle:
					newVehicle = new ElectricMotorcycle(i_LicenseNumber , i_OwnerName, i_OwnerPhoneNumber,  i_ModelName);
					break;
				case eVehicleType.ElectricCar:
                    newVehicle = new ElectricCar(i_LicenseNumber, i_OwnerName, i_OwnerPhoneNumber, i_ModelName);
					break;
                default:
                    newVehicle = new FuelBasedTruck(i_LicenseNumber, i_OwnerName, i_OwnerPhoneNumber, i_ModelName);
                    break;
            }

            return newVehicle;
        }

        public static void CreateWheels(Vehicle i_Vehicle , string i_ManufactureName , List<float> i_CurrentAirPressures)
        {
            List < Vehicle.Wheel > newVehiclesWheels = new List<Vehicle.Wheel>();

            foreach(float wheelPressure in i_CurrentAirPressures)
            {
                newVehiclesWheels.Add(new Vehicle.Wheel(i_ManufactureName , wheelPressure , i_Vehicle.MaxAirPressure));
            }

            i_Vehicle.Wheels = newVehiclesWheels;
        }
<<<<<<< HEAD

        public static void CreateMotorcycleFeatures(Motorcycle i_Motorcycle , Motorcycle.eLicenseType i_LicenceType)
=======
        
        /*public static void SetLicenseType(Motorcycle i_Motorcycle , Motorcycle.eLicenseType i_LicenceType)
>>>>>>> origin/master
        {


        }

<<<<<<< HEAD
        public static void CreateCarFeatures(Car i_Car, Car.eNumOfDoors i_NumOfDoors , Car.eColor i_Color)
        {


        }

        public static void CreateTruckFeatures(Truck i_Truck)
=======


        public static void SetTruckHasHazardousMaterials(Truck i_Truck)
>>>>>>> origin/master
        {
             

        }*/
    }
}
