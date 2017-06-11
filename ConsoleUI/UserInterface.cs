﻿﻿using GarageLogic;
using System;
using System.Text;
namespace ConsoleUI
{
    public class UserInterface
    {

        private Garage m_Garage = new Garage();

        public void startGarage()
        {
            mainMenu();
        }


        private void mainMenu()
        {

          

            System.Console.WriteLine(UserMessages.MainMenuMessage());

            string userMainMenuInput = System.Console.ReadLine();
            int mainMenuInputNumber;

            while(!isValidMainMenuInput(userMainMenuInput , out mainMenuInputNumber))
            {
                System.Console.WriteLine("Invalid Input. Please enter the number of the task you wish to complete.");
                userMainMenuInput = System.Console.ReadLine();
            }

            switch(mainMenuInputNumber)
            {
                case 1:
                    /* 1) Insert new Vehicle into Garage. */
                    insertNewVehicleIntoGarage();
					break;
                case 2:
                    /* 2) Display list of licence numbers. */
                    displayListOfLicenceNumbers();
					break;
                case 3:
                    /* 3) Change a Vehicle's status. */
                    changeVehicleStatus();
					break;
				case 4:
                    /* 4) Inflate tires */
                    inflateTires();
					break;
				case 5:
					// 5) Refuel a vehicle.
					break;
				case 6:
					// 6) Charge a electric vehice.
					break;
				case 7:
					// 7) Display vehicle information.
					break;
                default:
                    System.Environment.Exit(1);
                    break;
					
            }
        }


        private bool isValidMainMenuInput(string i_UserInput , out int o_MainMenuNumber)
        {
            return int.TryParse(i_UserInput , out o_MainMenuNumber) && o_MainMenuNumber >= 1 && o_MainMenuNumber <= 8;
        }




		/* 1) Insert new Vehicle into Garage */
		private void insertNewVehicleIntoGarage()
        {
         
            System.Console.WriteLine(UserMessages.InsertNewVehicleIntoGarageMessage());
                                                
            string userInputVehicleType = System.Console.ReadLine();
            int vehicleTypeNumber;
            while(!isValidVehicleTypeInput(userInputVehicleType , out vehicleTypeNumber))
            {
				System.Console.WriteLine("Invalid Input. Please enter the number of the task you wish to complete.");
				userInputVehicleType = System.Console.ReadLine();
            }
            Vehicle vehicleToAdd;
			switch (vehicleTypeNumber)
			{
				case 1:
                    /* 1) Fuel-Based Motorcycle */
                    vehicleToAdd = new FuelBasedMotorcycle();
					break;
				case 2:
					/* 2) Electric Motorcycle */
                    vehicleToAdd = new ElectricMotorcycle();
					break;
				case 3:
					/* 3) Fuel-Based Car */
                    vehicleToAdd = new FuelBasedCar();
					break;
				case 4:
					/* 4) Electric Car */
                    vehicleToAdd = new ElectricCar();
					break;
				case 5:
					/* 5) Fuel-Based Truck */
                    vehicleToAdd = new FuelBasedTruck();
					break;
                default:
                    /* 5) back to main menu */
                    mainMenu();
                    return; 
			}

            //TODO: get new licence number and insert new vehicle

        }

		private bool isValidVehicleTypeInput(string i_UserInput, out int o_MainMenuNumber)
		{
			return int.TryParse(i_UserInput, out o_MainMenuNumber) && o_MainMenuNumber >= 1 && o_MainMenuNumber <= 5;
		}


		/* 2) Display list of licence numbers */
		private void displayListOfLicenceNumbers()
		{
			string insertMessage = string.Format("Display List Of Licence Numbers. Please choose a filter:{0} " +
                                                 "{1} ", System.Environment.NewLine);
          //  this.m_Garage.DisplayListOfLicenceNumbers(i_Status: Garage.eVehicleStatus.InRepair);
            //TODO: get input from garage 

		}

        /* 3) Change a Vehicle's status */
		private void changeVehicleStatus()
		{
            
            System.Console.WriteLine("Please enter the licence number of your vehicle:");
            string licenseNumber = System.Console.ReadLine();

            while (!isLegalLicenceNumber(licenseNumber)) // might need try catch
            {
                System.Console.WriteLine("Invalid input. Please enter a legal licence plate");
                licenseNumber = System.Console.ReadLine();
            }
            StringBuilder vehicleStatusOut = new StringBuilder();
            vehicleStatusOut.Append("Please enter the new desired vehicle status:");
            vehicleStatusOut.Append("1. In Repair");
            vehicleStatusOut.Append("2. Repaired");
            vehicleStatusOut.Append("3. Payed For");
            System.Console.WriteLine(vehicleStatusOut.ToString());
            string userInput = System.Console.ReadLine();
            int numUserInput;
            int.TryParse(userInput, out numUserInput);
            Vehicle.eVehicleStatus newVehicleStatus;

            switch (numUserInput)
            {
                case 1:
                    newVehicleStatus = Vehicle.eVehicleStatus.InRepair;
                    break;
                case 2:
                    newVehicleStatus = Vehicle.eVehicleStatus.Repaired;
                    break;
                case 3:
                    newVehicleStatus = Vehicle.eVehicleStatus.PayedFor;
                    break;
                default:
                    throw new ArgumentException("Change Vehicle Status");
            }

            m_Garage.ChangeVehicleStatus(licenseNumber, newVehicleStatus);
        }

		

		/* 4) Inflate tires */
		private void inflateTires()
		{
			string licenceNumber;
			this.promptUserForLicenseNumber(out licenceNumber);


		}

		/* 5) Refuel a vehicle */
		private void refuelVehicle()
		{

		}

		/* 6) Charge a electric vehice. */
		private void chargeElectricVehice()
		{

		}

		/* 7) Display vehicle information */
		private void displayVehicleInformation()
		{

		}

        private Vehicle promptUserForLicenseNumber(out string o_licenceNumber)
        {

			System.Console.WriteLine("Please enter the licence number of your vehicle:");
			string licencePlateNumber = System.Console.ReadLine();

			while (!isLegalLicenceNumber(licencePlateNumber)) // might need try catch
			{
				System.Console.WriteLine("Invalid input. please enter a legal licence plate");
				licencePlateNumber = System.Console.ReadLine();
			}
            o_licenceNumber = licencePlateNumber;

			Vehicle currentVehicle;

			if (this.m_Garage.GetVehicle(licencePlateNumber, out currentVehicle))
			{

                //TODO ask for status change 

                return currentVehicle;

			}
			else
			{
				System.Console.WriteLine("Sorry, this vehicle is not in the garage now");
				//TODO: try again??
			}

            return null;

        }

        public static bool isLegalLicenceNumber(string i_licence)
        {




            return false;
        }

	}



    public static class UserMessages {


        public static string MainMenuMessage()
        {
          
            string mainMenuMessage = string.Format(
                @"Main Menu
Please Select a task number you wish to complete:
1) Insert new Vehicle into Garage.
2) Display list of licence numbers.
3) Change a Vehicle's status
4) Inflate tires
5) Refuel a vehicle.
6) Charge a electric vehice.
7) Display vehicle information.");
            
            return mainMenuMessage;
        }

        public static StringBuilder InsertNewVehicleIntoGarageMessage()
        {
            StringBuilder InsertNewVehicleMessage = new StringBuilder();
			InsertNewVehicleMessage.AppendLine("Insert a new vehicle into garage:");
			InsertNewVehicleMessage.AppendLine("Please Select a Vehile type you wish to insert:");
			InsertNewVehicleMessage.AppendLine("1) Fuel-Based Motorcycle");
			InsertNewVehicleMessage.AppendLine("2) Electric Motorcycle");
			InsertNewVehicleMessage.AppendLine("3) Fuel-Based Car");
			InsertNewVehicleMessage.AppendLine("4) Electric Car");
			InsertNewVehicleMessage.AppendLine("5) Fuel-Based Truck");
			InsertNewVehicleMessage.AppendLine("6) Back to Main Menu");
            return InsertNewVehicleMessage;

        }











    }
}

/* 
 * 
 * 
 * 2. Display a list of license numbers currently in the garage, with a filtering option
based on the status of each vehicle
3. Change a certain vehicle’s status (Prompting the user for the license number and
new desired status)
4. Inflate tires to maximum (Prompting the user for the license number)
5. Refuel a fuel-based vehicle (Prompting the user for the license number, fuel type
and amount to fill)
 * 
 */
