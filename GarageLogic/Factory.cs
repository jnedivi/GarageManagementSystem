using System;
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


        public static Vehicle CreateNewVehicle(eVehicleType i_VehicleType, string i_LicenseNumber, string i_OwnerName,
                                               string i_OwnerPhoneNumber, string i_ModelName)
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

        public static List<Vehicle.Wheel> CreateWheels(string i_ManufactureName , List<float> i_CurrentAirPressures)
        {
            //TODO: make wheels with air pressure


            return null;
        }


    }
}
