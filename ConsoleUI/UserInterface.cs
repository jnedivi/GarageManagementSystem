﻿using GarageLogic;
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


        private void mainMenu()
        {

            Menu mainMenu = new Menu();

            System.Console.WriteLine(mainMenu.mainMenu());

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
            string insertMessage = string.Format("Insert a new vehicle into garage:{0} " +
                                                 "Please Select a Vehile type you wish to insert: ",System.Environment.NewLine);
            string userInputVehicleType = System.Console.ReadLine();
            int vehicleTypeNumber;
            while(!isValidVehicleTypeInput(userInputVehicleType , out vehicleTypeNumber))
            {
				System.Console.WriteLine("Invalid Input. Please enter the number of the task you wish to complete.");
				//userMainMenuInput = System.Console.ReadLine();
            }

        }

		private bool isValidVehicleTypeInput(string i_UserInput, out int o_MainMenuNumber)
		{
			return int.TryParse(i_UserInput, out o_MainMenuNumber) && o_MainMenuNumber >= 1 && o_MainMenuNumber <= 8;
		}



		/* 2) Display list of licence numbers */
		private void displayListOfLicenceNumbers()
		{

		}

        /* 3) Change a Vehicle's status */
		private void changeVehicleStatus()
		{

		}

		/* 4) Inflate tires */
		private void inflateTires()
		{

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

	}



    public class Menu {


        public string mainMenu()
        {
          

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
