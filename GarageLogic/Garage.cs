using System;
using System.Collections.Generic;

namespace GarageLogic
{
    public class Garage
    {
		/*** Data Members ***/

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


        public void InsertNewVehicle(Vehicle i_Vehicle)
        {

            //TODO: insert new vehicle


        }

        public enum eVehicleStatus
        {
            InRepair,
            Repaired,
            PayedFor
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
