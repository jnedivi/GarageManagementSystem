﻿﻿﻿﻿﻿using GarageLogic;
using System;
using System.Text;
using System.Collections.Generic;
namespace ConsoleUI
{
    public class UserInterface
    {
        /*** Data Members ***/

        private Garage m_Garage;
       
        /*** Constructor ***/

        public UserInterface()
        {
            m_Garage = new Garage();
            mainMenu();
        }

        /*** Class Logic ***/

        private void mainMenu()
        {
            
            System.Console.WriteLine(MainMenuMessage());
            int mainMenuInputNumber = this.promptUserForMenuSelection(7);
           
            if(mainMenuInputNumber == 7)
            {
				System.Environment.Exit(1);
			}

            switch (mainMenuInputNumber)
            {
                case 1:
                    /* 1) Insert new Vehicle into Garage. */
                    insertNewVehicleIntoGarage();
                    break;
                case 2:
                    /* 2) Display list of licence numbers. */
                    displayListOfLicenceNumbers();
                    break;
                default:
					/* Options 3 - 7 */
					menuOptions(mainMenuInputNumber);
                    break;
            }
        }

        /* 1) Insert new Vehicle into Garage */
        private void insertNewVehicleIntoGarage()
        {
            System.Console.WriteLine(createMenuStringFromEnum(typeof(Factory.eVehicleType), "Insert New Vehicle"));
            int vehicleTypeNumber = promptUserForMenuSelection(Enum.GetNames(typeof(Factory.eVehicleType)).Length);
            Factory.eVehicleType vehicleToAdd = (Factory.eVehicleType)vehicleTypeNumber - 1;
            string licenseNumber;
            this.promptUserForLicenseNumber(out licenseNumber);

            if (this.m_Garage.IsInGarage(licenseNumber))
            {
                System.Console.WriteLine("Veicle currently in garage. Status changed to: In Repair.");
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

                this.m_Garage.InsertNewVehicle(vehicleToAdd, licenseNumber, ownerName, ownerPhoneNumber, vehicleModelName);

                System.Console.WriteLine(createMenuStringFromEnum(typeof(Vehicle.eTireAirPressureStatus), "Do all tires have the same air pressure"));
				int tireStatusNumber = promptUserForMenuSelection(Enum.GetNames(typeof(Factory.eVehicleType)).Length);
                Vehicle createdVehicle;
                m_Garage.GetVehicle(licenseNumber, out createdVehicle);
                List<float> tirePressures = new List<float>();

                if (tireStatusNumber == 1)
                {
                    float singleTireAirPressure = this.getTirePressureFromUser(createdVehicle);
                    for (int i = 0; i < createdVehicle.NumberOfWheels; i++)
                    {
                        tirePressures.Add(singleTireAirPressure);
                    }
                }
                else
                {
                    for (int i = 0; i < createdVehicle.NumberOfWheels; i++)
                    {
                        tirePressures.Add(getTirePressureFromUser(createdVehicle));
                    }
                }

                System.Console.WriteLine("Please enter Tires Manufacturer Name:");
                string tiresManufacturerName = System.Console.ReadLine();

                Factory.CreateWheels(createdVehicle , tiresManufacturerName , tirePressures);

                if(createdVehicle is Car)
                {
                    //TODO: get color and number of doors
                }
                else if (createdVehicle is Motorcycle)
                {
                    //TODO: get licence tyoe
                }
                else
                {
                    //TODO : get hazardous materials state
                }

            }

            mainMenu();
        }


        /* 2) Display list of licence numbers */
        private void displayListOfLicenceNumbers()
        {
            System.Console.Clear();
           
            System.Console.WriteLine(createMenuStringFromEnum(typeof(Vehicle.eVehicleStatus), "Enter a Vehicle type"));
            int userChoice = promptUserForMenuSelection(Enum.GetNames(typeof(Vehicle.eVehicleStatus)).Length);
            Dictionary<string, Vehicle>.KeyCollection list = m_Garage.GetFilteredListOfLicenseNumbers((Vehicle.eVehicleStatus)(userChoice - 1));
            int vehicleNumber = 1;  
            foreach (string license in list)
            {
                
                System.Console.WriteLine(string.Format("{0}. Licence number: {1}{2}" , vehicleNumber, license , Environment.NewLine));
                vehicleNumber++;
            }

            if(list.Count == 0)
            {
                System.Console.WriteLine("No Vehicles Available" + Environment.NewLine);
            }

            mainMenu();
        }

        /*** Options 3 - 7 ***/
        private void menuOptions(int i_MainMenuSelection)
        {
            int userChoice;
			System.Console.Clear();
			string licenseNumber;
			Vehicle currentVehicle = this.promptUserForLicenseNumber(out licenseNumber);
            if (currentVehicle != null)
			{
                switch(i_MainMenuSelection)
                {
                    case 3:
						/* 3) Change a vehicle status */
                        // TODO: add catches
						System.Console.WriteLine(createMenuStringFromEnum(typeof(Vehicle.eVehicleStatus), "Enter a Vehicle Status"));
						userChoice = promptUserForMenuSelection(Enum.GetNames(typeof(Vehicle.eVehicleStatus)).Length);
						m_Garage.ChangeVehicleStatus(licenseNumber, (Vehicle.eVehicleStatus)(userChoice - 1));
                        break;
					case 4:
						/* 4) Inflate tires to max */
						currentVehicle.InflateAllWheelsToMax();
						break;
					case 5:
						/* 5) Refuel vehicle */
                        // TODO: get function to work, as well as the catches
						System.Console.WriteLine(createMenuStringFromEnum(typeof(FuelBasedEngine.eFuelType), "Enter a Fuel Type"));
						userChoice = this.promptUserForMenuSelection(Enum.GetNames(typeof(FuelBasedEngine.eFuelType)).Length);
                        System.Console.WriteLine("Please enter amount to refuel");
                        float amountToRefuel = this.getFloatFromUser(0, int.MaxValue);
                        try
                        {
                            this.m_Garage.RefuelVehicle(licenseNumber, (FuelBasedEngine.eFuelType)(userChoice - 1), amountToRefuel);
                        }
                        catch(FormatException ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        catch (ValueOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.ToString());

                        }
                        catch(ArgumentException ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
						break;
					case 6:
                        /* 6) charge vehicle */
                        // TODO: get function to work, add catches
                        System.Console.WriteLine("Please enter amount to recharge:");
						float amountToRecharge = this.getFloatFromUser(0, int.MaxValue);
                        m_Garage.ChargeElectricVehice(licenseNumber , amountToRecharge);
						break;
					case 7:
						/* 7) Display vehicle information */
						System.Console.WriteLine(currentVehicle.ToString());
						break;
                }
			}
			else
			{
				System.Console.WriteLine(string.Format("Vehicle with licence number {0} is not in the garage.{1}", licenseNumber, Environment.NewLine));
			}

			mainMenu();
        }

        private float getFloatFromUser(int i_MaxNumber , int i_MinNumber)
        {
            float userInputNumber;
            string input = System.Console.ReadLine();
            while (!(float.TryParse(input , out userInputNumber) && userInputNumber >= i_MinNumber && userInputNumber <= i_MaxNumber))
            {
                System.Console.Write(string.Format("Invalid Input. Please eneter a number between {0} and {1}.") , i_MinNumber , i_MaxNumber);
                input = System.Console.ReadLine();
            }

            return userInputNumber;
        }

        /* Get Menu Selection From User */
        private int promptUserForMenuSelection(int i_NumberOfItems)
        {
            string userInputString = System.Console.ReadLine();
            int userInputNumber;
            string messageToUser = string.Format("Please enter a number between 1 and {0}", i_NumberOfItems);

            while (!(int.TryParse(userInputString, out userInputNumber) && userInputNumber >= 1 && userInputNumber <= i_NumberOfItems))
            {
                System.Console.WriteLine("Invalid Input. " + messageToUser);
                userInputString = System.Console.ReadLine();
            }
            System.Console.Clear();
            return userInputNumber;
        }

        /* Get Licence number and Vehilce from user */
        private Vehicle promptUserForLicenseNumber(out string o_licenceNumber)
        {
            System.Console.WriteLine("Please enter the licence number of your vehicle or Q to cancel:");
            o_licenceNumber = System.Console.ReadLine();
            if (o_licenceNumber == "Q" || o_licenceNumber == "q")
            {
                mainMenu();
            }
            else
            {
                while (!Vehicle.isLegalLicenseNumber(o_licenceNumber))
                {
                    System.Console.WriteLine("Invalid input. please enter a legal licence plate number.");
                    o_licenceNumber = System.Console.ReadLine();
                }
            }

            Vehicle currentVehicle;

            return m_Garage.GetVehicle(o_licenceNumber, out currentVehicle) ? currentVehicle : null;
        }

		/* Get Tire pressures from user */
		private float getTirePressureFromUser(Vehicle i_Vehicle)
		{
            float tirePressure;
			string maxAirPressumeMessage = string.Format("Please enter a number below or equal to the max air pressure: {0}.", i_Vehicle.MaxAirPressure);

			System.Console.WriteLine(maxAirPressumeMessage);
            string userInputPressure = System.Console.ReadLine();

			while (!(float.TryParse(userInputPressure, out tirePressure) && tirePressure <= i_Vehicle.MaxAirPressure && tirePressure >= 0))
			{
				System.Console.WriteLine(string.Format("Invalid Input. {0}", maxAirPressumeMessage));
				userInputPressure = System.Console.ReadLine();
			}

			return tirePressure;
		}


        private static string createMenuStringFromEnum(Type i_EnumType, string i_Title)
        {
            int menuNumber = 1;
            StringBuilder menuString = new StringBuilder();
            menuString.AppendLine(i_Title);

            foreach (string menuValue in Enum.GetNames(i_EnumType))
            {
                menuString.Append(menuNumber.ToString()).Append(". ");
                menuString.Append(menuValue).Append(Environment.NewLine);
                menuNumber++;
            }

            return menuString.ToString();
        }

        /*private static void refuelVehicle(ref Vehicle io_Vehicle)
        {
         
        }*/



        /*** End of class ***/


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
    }


}

