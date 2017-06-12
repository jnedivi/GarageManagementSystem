﻿﻿﻿using GarageLogic;
using System;
using System.Text;
using System.Collections.Generic;
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

			while (!int.TryParse(userMainMenuInput, out mainMenuInputNumber) && mainMenuInputNumber >= 1 && mainMenuInputNumber <= 8)
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
                    /* 5) Refuel a vehicle. */
                    refuelVehicle();
					break;
				case 6:
                    // 6) Charge a electric vehice.
                    chargeElectricVehice();
					break;
				case 7:
                    displayVehicleInformation();
					break;
                default:
                    System.Environment.Exit(1);
                    break;
					
            }
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

            Factory.eVehicleType vehicleToAdd;

			switch (vehicleTypeNumber)
			{
				case 1:
                    /* 1) Fuel-Based Motorcycle */
                    vehicleToAdd = Factory.eVehicleType.FuelBasedMotorcycle;
					break;
				case 2:
                    /* 2) Electric Motorcycle */
                    vehicleToAdd = Factory.eVehicleType.ElectricMotorcycle;
					break;
				case 3:
                    /* 3) Fuel-Based Car */
                    vehicleToAdd = Factory.eVehicleType.FuelBasedCar;
					break;
				case 4:
                    /* 4) Electric Car */
                    vehicleToAdd = Factory.eVehicleType.ElectricCar;
					break;
				case 5:
                    /* 5) Fuel-Based Truck */
                    vehicleToAdd = Factory.eVehicleType.FuelBasedTruck;
					break;
                default:
                    /* 5) back to main menu */
                    mainMenu();
                    return; 
			}

            string licenseNumber;
            this.promptUserForLicenseNumber(out licenseNumber);

            if(this.m_Garage.IsInGarage(licenseNumber))
            {
                this.m_Garage.StatusInRepairedUpdate(licenseNumber);
            }
            else
            {
				System.Console.WriteLine("Please enter Owner name:");
				string ownerName = System.Console.ReadLine();
				System.Console.WriteLine("Please enter Owners phone number:");
				string ownerPhoneNumber = System.Console.ReadLine();
				System.Console.WriteLine("Please enter Vehicles Model Name:");
				string vehicleModelName = System.Console.ReadLine();
                System.Console.WriteLine(string.Format("Please enter condition of the tires{0}1)All tires have same air pressure{1}2)Enter each tire seperately" , System.Environment.NewLine , System.Environment.NewLine));
                string tireInflationChoice = System.Console.ReadLine();
                while(! (tireInflationChoice == "1") || (tireInflationChoice == "2"))
                {
                    System.Console.WriteLine("Invalid Input. Please enter 1 or 2");
                    tireInflationChoice = System.Console.ReadLine();
                }
                List<float> tirePressures = new List<float>();
                switch(tireInflationChoice)
                {
                    case "1":
						/* 1)All tires have same air pressure */
                        break;
                    case "2":
						/* 2)Enter each tire seperately */
                        break;
                }

				System.Console.WriteLine("Please enter Tires Manufacturer Name:");
				string tiresManufacturerName = System.Console.ReadLine();
                this.m_Garage.InsertNewVehicle(vehicleToAdd , licenseNumber , ownerName , ownerPhoneNumber , vehicleModelName , tirePressures , tiresManufacturerName);
            }
            mainMenu();
        }

		private bool isValidVehicleTypeInput(string i_UserInput, out int o_MainMenuNumber)
		{
			return int.TryParse(i_UserInput, out o_MainMenuNumber) && o_MainMenuNumber >= 1 && o_MainMenuNumber <= 6;
		}


        /* 2) Display list of licence numbers */
        private void displayListOfLicenceNumbers()
		{
		
            System.Console.WriteLine(UserMessages.FilteredListOfVehiclesMessage());
            string filter = System.Console.ReadLine();
            Dictionary<string, Vehicle>.KeyCollection list;
            switch(filter){

                case "1":
                    list = m_Garage.GetFilteredListOfLicenseNumbers(Vehicle.eVehicleStatus.InRepair);
                    break;
				case "2":
                    list = m_Garage.GetFilteredListOfLicenseNumbers(Vehicle.eVehicleStatus.Repaired);
					break;
				case "3":
                    list = m_Garage.GetFilteredListOfLicenseNumbers(Vehicle.eVehicleStatus.PayedFor);
					break;
				case "4":
                    list = m_Garage.GetListOfLicenceNumbers();
                    break;
                    default :
                    System.Console.WriteLine("Invalid Input. Please Try again");
                    displayListOfLicenceNumbers();
                    return;
            }

            foreach(string license in list)
            {
                System.Console.WriteLine(license);
            }
            mainMenu();
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
            mainMenu();
        }

		

		/* 4) Inflate tires */
		private void inflateTires()
		{
			string licenceNumber;
            Vehicle vehicleToInflate;
			this.promptUserForLicenseNumber(out licenceNumber);
            if (this.m_Garage.GetVehicle(licenceNumber, out vehicleToInflate))
            {
                vehicleToInflate.InflateAllWheelsToMax();
            }
            else
            {
                System.Console.WriteLine("Vehicle not found");
                //TODO: throw vehicle not found exception
            }
		}

		/* 5) Refuel a vehicle */
		private void refuelVehicle()
		{
			string licenceNumber;
            Vehicle vehicleToRefuel;
			this.promptUserForLicenseNumber(out licenceNumber);
            if( m_Garage.GetVehicle(licenceNumber , out vehicleToRefuel))
            {
              

                System.Console.WriteLine(UserMessages.SelectFuelTypeMessage());
                string userInputString = System.Console.ReadLine();
                int userInputNumber;
                while(int.TryParse(userInputString , out userInputNumber)) // fix to string
                {
                    System.Console.WriteLine("Please enter a number between 1 and 5");
                    userInputString = System.Console.ReadLine();
                }
                switch(userInputNumber)
                {
					case 1:
						
						break;
					case 2:
						
						break;
					case 3:
						
						break;
					case 4:
						
						break;
					default:
						/* 5) back to main menu */
						mainMenu();
						return;
				}

            }
            else 
            {

                //TODO: throw exception
            }

		}

		/* 6) Charge a electric vehice. */
		private void chargeElectricVehice()
		{
			string licenceNumber;
            Vehicle vehicleToRecharge;
			this.promptUserForLicenseNumber(out licenceNumber);
			if (this.m_Garage.GetVehicle(licenceNumber, out vehicleToRecharge))
			{
                //TODO: recharge vehicle
			}
			else
            {
                // throw error
            }


		}

		/* 7) Display vehicle information */
		private void displayVehicleInformation()
		{
			string licenceNumber;
			Vehicle vehicleToRecharge;
			this.promptUserForLicenseNumber(out licenceNumber);
			if (this.m_Garage.GetVehicle(licenceNumber, out vehicleToRecharge))
			{
                System.Console.WriteLine(vehicleToRecharge.ToString());
			}
			else
			{
                System.Console.WriteLine("Vehicle not in garage");
				// throw error
			}

            mainMenu();
		}

        private Vehicle promptUserForLicenseNumber(out string o_licenceNumber)
        {

            System.Console.WriteLine("Please enter the licence number of your vehicle or Q to cancel:");
            string licencePlateNumber = System.Console.ReadLine();
            if(licencePlateNumber == "q" || licencePlateNumber == "q")
            {
                mainMenu();
                o_licenceNumber = null;
                return null; //  might need to change 
            }

            while (!isLegalLicenceNumber(licencePlateNumber)) // might need try catch
            {
                System.Console.WriteLine("Invalid input. please enter a legal licence plate number.");
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

        public bool isLegalLicenceNumber(string i_licence)
        {
            char[] licenceNumber = i_licence.ToCharArray();
            bool isLegalNumber = true;
            foreach(char digit in licenceNumber)
            {
                if(!char.IsDigit(digit))
                {
                    isLegalNumber = false;
                    break;
                }
            }
            return licenceNumber.Length < 9 && licenceNumber.Length > 5 ? isLegalNumber : false;
        }

		/* handle case of vehicle not found ... */
		private void VehicleNotFound()
		{

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


        public static StringBuilder SelectFuelTypeMessage()
        {
            StringBuilder FuelTypeMessage = new StringBuilder();
			FuelTypeMessage.AppendLine("Please Select a Vehile type you wish to insert:");
			FuelTypeMessage.AppendLine("1) Soler");
			FuelTypeMessage.AppendLine("2) Octance95");
			FuelTypeMessage.AppendLine("3) Octance96");
			FuelTypeMessage.AppendLine("4) Octane98");
			FuelTypeMessage.AppendLine("5) Revoke Action. Back to Main Menu");
			return FuelTypeMessage;
        }

        public static StringBuilder FilteredListOfVehiclesMessage()
        {
            StringBuilder ListOfVehiclesMessage = new StringBuilder();
            ListOfVehiclesMessage.AppendLine("Please Select FilterType");
            ListOfVehiclesMessage.AppendLine("1) In Repair");
            ListOfVehiclesMessage.AppendLine("2) Repaired");
            ListOfVehiclesMessage.AppendLine("3) Payed For");
            ListOfVehiclesMessage.AppendLine("4) All Vehicles");
            return ListOfVehiclesMessage;
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
