using System;
using System.Collections.Generic;

namespace Viagogo
{


	/**
	 * Event class
	 * @author Ronan Watkins
	 *
	 */	
	public class Event {
	
	    private Coordinate coordinate;
	    private int eventId;
	    private int ticketNum;
	    private List<double> tickets = new List<double>();
	
	    /**
	     * Creates an Event object
	     * Randomly generates ticket prices and amount of tickets
	     * Minimum amount of tickets is 0, Maxmimum amount is 300
	     * Minumum ticket price is $10, Maximum price is no more than Minimum price+$30
	     * @param eventId
	     * @param x
	     * @param y
	     */
	    public Event(int eventId, int x, int y) {
	        this.eventId = eventId;
	        this.coordinate = new Coordinate(x, y);
	        this.ticketNum = StaticRandom.Instance.Next(300);
	
	        double minPrice = 10 + StaticRandom.Instance.NextDouble()*100;
	        double price;
	        for (int i = 0; i < ticketNum; i++) {
	            price = minPrice+StaticRandom.Instance.NextDouble()*30; //Randomly generate price for every ticket
	            tickets.Insert(i, price);
	        }
	        
	        tickets.Sort(); //Sort tickets in ascending order
	    }
	
	    /**
	     *
	     * Properties
	     */
		#region Properties
		
	    public double MinPrice {
			get { return tickets[0]; }
	    }
	
	    public double MaxPrice {
			get { return tickets[tickets.Count-1]; }
	    }
	
	    
	    public int EventId {
			get { return eventId; }
	    }
	
	    public int TicketNum {
			get { return ticketNum; }
	    }
	
	    public string Location {
			get { return coordinate.ToString(); }
	    }
		#endregion
	    
		/**
	     * Overriding the toString method
	     */
	    public override String ToString() {
	        return "ID: " + eventId + " Num of tickets: " + ticketNum + " Max price: " + MaxPrice + " Min price: " + MinPrice + " Location: " + Location;
	    }
	}

}
