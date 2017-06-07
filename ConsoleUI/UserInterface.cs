using GarageLogic;
using System;
namespace ConsoleUI
{
    public class UserInterface
    {

        private Garage m_Garage;
        private Vehicle[] VehicleTypes = new Vehicle[5];
        private FuelBasedTruck k;

        public void startGarage()
        {

            VehicleTypes[0] = new FuelBasedTruck();

        }



        private void refuelVehicle(ref Vehicle io_Vehicle)
        {
         


        }


        private void insertNewVehicle()
        {
         

            System.Console.WriteLine("Please select a Vehicle type: ");




        }








    }
}
