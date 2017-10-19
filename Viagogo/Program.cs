using System.Collections.Generic;
using System.Text;
using System;

namespace Viagogo
{
	/**
	 * Driver class
	 * @author Ronan Watkins
	 */
	public class Program {
	
	    private static int[] coordinates;
	
	    /**
	     * Main function
	     * This is the entry point to the program
	     * Gets user input and creates a Coordinate object from it
	     * Computes distance between user's coordinates and coordinates of all events
	     * Finds 5 closest events to the user's coordinates and prints the:
	     *  Event ID
	     *  Minimum Price
	     *  Number of Tickets
	     *  Distance and Location
	     * of each event
	     *
	     * @param args  [unused]
	     */
	    public static void Main(string[] args) {
	        EventGrid eventGrid = new EventGrid();
	        Dictionary<Coordinate, Event> grid = eventGrid.GetGrid();
	
	        //Get coordinates from user
	        getInput(true);
	
	        //Coordinate object to hold user inputted coordinates
	        Coordinate inputCoordinate = new Coordinate(coordinates[0], coordinates[1]);
	
	        //Integer list to hold distances between user coordinates and each event
	        List<int> distance = new List<int>();
	
	        //Compute distances between user coordinates and each event 
	        //Add the distance to the list
	        foreach (Coordinate c in grid.Keys) {
	            distance.Add(getDistance(inputCoordinate, c));
	        }
	        distance.Sort(); //Sort list in ascending order
	
	        if (distance.Count == 0) { //If no events exist (rare condition)
	            Console.WriteLine("No Events Found");
	        } else {
	            Console.WriteLine("\nClosest events to \"" + inputCoordinate + "\"\n");
	            StringBuilder sb;
	            //Event list to hold up to 5 of the closest events to the user
	            List<Event> eventList = new List<Event>();
	            Event temp;
	
	            int i=0;
	            //Allow a maximum of 5 events. Take into account the fact that there may be less than 5
	            int eventNum = distance.Count < 5 ? distance.Count : 5;
	            foreach(int dist in distance) { //Step through list of distances between user coordinates and all events
	                foreach(Coordinate c in grid.Keys) { //Step through coordinates of all events
	                    //This will find the closest 5 events to the user, place each event in a List and print the details of the event
	                    if(getDistance(inputCoordinate, c) == dist && i < eventNum) {
	                    	if(!eventList.Contains(grid[c])) { //Don't select the same event twice
	                    		temp = grid[c];
	                            eventList.Add(temp); //Add the Event to the eventList
	
	                            sb = new StringBuilder();
	                            sb.Append("Event ID : " + temp.EventId + "\n");
	                            sb.Append(string.Format("Minimum Price: ${0:00.00}\n", temp.MinPrice));
	                            sb.Append("Number of Tickets: " + temp.TicketNum + "\n");
	                            sb.Append("Distance and Location: " + dist +", (" + temp.Location + ")\n");
	                            Console.WriteLine(sb.ToString());
	
	                            i++;
	                        }
	                    }
	                }
	            }
	            Console.ReadKey();
	        }
	    }
	
	    /**
	     * This function gets user input and places the input into the global array "coordinates"
	     * Recursively calls itself while wrong coordinates are entered
	     * @param isFirst
	     */
	    private static void getInput(bool isFirst) {
	        coordinates = new int[2];
	
	        if (isFirst) { //This will be printed on the first iteration of the function
	             Console.WriteLine("Please enter coordinates in the form \"x,y\"");
	             Console.WriteLine("Coordinates range between -10 and 10");
	        } else { //This will be printed on subsequent iterations of the function
	             Console.WriteLine("You supplied incorrect coordinates");
	             Console.WriteLine("Please enter coordinates in the form \"x,y\"");
	        }
	        String input = Console.ReadLine(); //Get user input from the console
	
	        try {
	            coordinates[0] = Int32.Parse(input.Substring(0, input.IndexOf(",")));
	            Console.WriteLine(input.Substring(0, input.IndexOf(",")));
	            coordinates[1] = Int32.Parse(input.Substring(input.IndexOf(",")+1));
	            Console.WriteLine(input.Substring(input.IndexOf(",")+1));
	        } catch (Exception ) { //An exception will occur here if the user enters a String, float etc
	            getInput(false);
	        } finally {
	            if(coordinates[0] < -10 || coordinates[0] > 10 || coordinates[1] < -10 || coordinates[1] > 10) { //Check if coordinates are too small/large
	                getInput(false);
	            }
	        }
	    }
	
	    /**
	     * This function computes the Manhattan distance between 2 Coordinates
	     * @param c1
	     * @param c2
	     * @return Manhattan distance between both coordinates as an integer
	     */
	    private static int getDistance(Coordinate c1, Coordinate c2) {
	        return Math.Abs(c1.XCoord - c2.XCoord) + Math.Abs(c1.YCoord - c2.YCoord);
	    }
	
	}

}