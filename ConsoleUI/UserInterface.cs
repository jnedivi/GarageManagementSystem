using GarageLogic;
using System;
namespace ConsoleUI
{
    public class UserInterface
    {

        private Garage m_Garage;

      

        public void startGarage()
        {

            Menu m = new Menu();

            System.Console.WriteLine(m.mainMenu());


            

        }



        private void refuelVehicle(ref Vehicle io_Vehicle)
        {
         


        }


        private void insertNewVehicle()
        {
         

            System.Console.WriteLine("Please select a Vehicle type: ");




        }
    }



    public class Menu {


        public string mainMenu()
        {
            //System.Console.Clear();
           // System.Console.WriteLine("Main Menu");
           // System.Console.WriteLine("Please Select a task number you wish to complete:");

            string message = string.Format(
                @"Main Menu
Please Select a task number you wish to complete:
1) Insert new Vehicle into Garage.
2) Display list of licence numbers.
3) Change a Vehicle's status
4) Inflate tires
5) Refuel a vehicle.
6) Charge a electric vehice.
7) Display vehicle information.");



            return message;
        }









    }
}
