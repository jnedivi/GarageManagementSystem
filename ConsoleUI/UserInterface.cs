﻿﻿﻿using GarageLogic;
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
            //string userMainMenuInput = System.Console.ReadLine();
            int mainMenuInputNumber = this.promptUserForMenuSelection(7);

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
                    /* 6) Charge a electric vehice. */
                    chargeElectricVehice();
                    break;
                case 7:
                    /* 7) Display Vehicle information. */
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
            System.Console.WriteLine(createMenuStringFromEnum(typeof(Factory.eVehicleType), "Insert New Vehicle"));
            int vehicleTypeNumber = promptUserForMenuSelection(Enum.GetNames(typeof(Factory.eVehicleType)).Length);
            Factory.eVehicleType vehicleToAdd = (Factory.eVehicleType)vehicleTypeNumber - 1;
            string licenseNumber;
            this.promptUserForLicenseNumber(out licenseNumber);

            if (this.m_Garage.IsInGarage(licenseNumber))
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

                this.m_Garage.InsertNewVehicle(vehicleToAdd, licenseNumber, ownerName, ownerPhoneNumber, vehicleModelName);

                System.Console.WriteLine(createMenuStringFromEnum(typeof(Vehicle.eTireAirPressureStatus), "Do all tires have the same air pressure"));
				int tireStatusNumber = promptUserForMenuSelection(Enum.GetNames(typeof(Factory.eVehicleType)).Length);
                Vehicle createdVehicle;
                m_Garage.GetVehicle(licenseNumber, out createdVehicle);
                List<float> tirePressures = new List<float>();

                if(tireStatusNumber == 1)
                {


                }
                else 
                {



                }


                System.Console.WriteLine("Please enter Tires Manufacturer Name:");
                string tiresManufacturerName = System.Console.ReadLine();


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
            System.Console.WriteLine(createMenuStringFromEnum(typeof(Vehicle.eVehicleStatus), "Enter a Vehicle type"));
            int userChoice = promptUserForMenuSelection(Enum.GetNames(typeof(Vehicle.eVehicleStatus)).Length);
            Dictionary<string, Vehicle>.KeyCollection list = m_Garage.GetFilteredListOfLicenseNumbers((Vehicle.eVehicleStatus)(userChoice - 1));

            foreach (string license in list)
            {
                System.Console.WriteLine(license);
            }

            mainMenu();
        }

        /* 3) Change a Vehicle's status */
        private void changeVehicleStatus()
        {
            string licenseNumber;
            Vehicle current = promptUserForLicenseNumber(out licenseNumber);
            if (current != null)
            {
                System.Console.WriteLine(createMenuStringFromEnum(typeof(Vehicle.eVehicleStatus), "Enter a Vehicle Status"));
                int userChoice = promptUserForMenuSelection(Enum.GetNames(typeof(Vehicle.eVehicleStatus)).Length);
                m_Garage.ChangeVehicleStatus(licenseNumber, (Vehicle.eVehicleStatus)(userChoice - 1));
            }

            mainMenu();
        }

        /* 4) Inflate tires */
        private void inflateTires()
        {
            string licenceNumber;
            Vehicle vehicleToInflate = this.promptUserForLicenseNumber(out licenceNumber);
            if (vehicleToInflate != null)
            {
                vehicleToInflate.InflateAllWheelsToMax();
            }
            mainMenu();
        }

        /* 5) Refuel a vehicle */
        private void refuelVehicle()
        {
            string licenceNumber;
            this.promptUserForLicenseNumber(out licenceNumber);
            System.Console.WriteLine(createMenuStringFromEnum(typeof(FuelBasedEngine.eFuelType), "Enter a Fuel Type"));
            int userChoice = promptUserForMenuSelection(Enum.GetNames(typeof(FuelBasedEngine.eFuelType)).Length);
            System.Console.WriteLine("Please enter amount to refuel");
            string refuelAmount = System.Console.ReadLine();
            float amountToRefuel;
            float.TryParse(refuelAmount, out amountToRefuel); //TODO: while loop
            m_Garage.RefuelVehicle(licenceNumber, (FuelBasedEngine.eFuelType)(userChoice - 1), amountToRefuel);
            mainMenu();
        }

        /* 6) Charge a electric vehice. */
        private void chargeElectricVehice()
        {
            string licenceNumber;
            Vehicle vehicleToRecharge = this.promptUserForLicenseNumber(out licenceNumber);
            if (vehicleToRecharge != null)
            {
                //TODO get info and recharge
            }

            mainMenu();
        }

        /* 7) Display vehicle information */
        private void displayVehicleInformation()
        {
            string licenceNumber;
            Vehicle vehicleToDisplay = this.promptUserForLicenseNumber(out licenceNumber);
            if (vehicleToDisplay != null)
            {
                System.Console.WriteLine(vehicleToDisplay.ToString());
            }

            mainMenu();
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
                while (!isLegalLicenceNumber(o_licenceNumber))
                {
                    System.Console.WriteLine("Invalid input. please enter a legal licence plate number.");
                    o_licenceNumber = System.Console.ReadLine();
                }
            }

            Vehicle currentVehicle;
            return m_Garage.GetVehicle(o_licenceNumber, out currentVehicle) ? currentVehicle : null;
        }

        public bool isLegalLicenceNumber(string i_licence)
        {
            char[] licenceNumber = i_licence.ToCharArray();
            bool isLegalNumber = true;
            foreach (char digit in licenceNumber)
            {
                if (!char.IsDigit(digit))
                {
                    isLegalNumber = false;
                    break;
                }
            }

            return licenceNumber.Length == 7 ? isLegalNumber : false;
        }

        private static string createMenuStringFromEnum(Type i_EnumType, string i_Title)
        {
            int i = 1;
            StringBuilder menuString = new StringBuilder();
            menuString.AppendLine(i_Title);

            foreach (string menuValue in Enum.GetNames(i_EnumType))
            {
                menuString.Append(i.ToString()).Append(". ");
                menuString.Append(menuValue).Append(Environment.NewLine);
                i++;
            }

            return menuString.ToString();
        }


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

