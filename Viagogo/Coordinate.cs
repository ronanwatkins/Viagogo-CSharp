using System;

namespace Viagogo
{
	/**
	 * Coordinate class
	 * @author Ronan Watkins
	 */
	public class Coordinate {
	
	    private int xCoord, yCoord;
	
	    /**
	     * Creates a Coordinate object
	     * @param xCoord
	     * @param yCoord
	     */
	    public Coordinate(int xCoord, int yCoord) {
	        this.xCoord = xCoord;
	        this.yCoord = yCoord;
	    }
	
	    #region Properties
	
	    public int XCoord {
	    	get { return xCoord; }
	    }
	
	    public int YCoord {
	    	get { return yCoord; }
	    }
	    
	    #endregion
	
	    /**
	     * Overriding the toString method
	     * @return xCoord and yCoord as String
	     */
	    
	    public override String ToString() {
	        return xCoord + ", " + yCoord;
	    }
	
	    /**
	     * Overriding the equals method
	     *
	     * @param obj
	     * @return True if coordinates of object parameter == coordinates of this
	     */
	    
	    public override bool Equals(Object obj) {
	        if (obj == this)
	            return true;
	
	        if (!(obj.GetType() == typeof(Coordinate)))
	            return false;
	
	        Coordinate coordinate = (Coordinate) obj;
	        return coordinate.xCoord == xCoord && coordinate.yCoord == yCoord;
	    }
	
	    /**
	     * Overriding the hashCode method
	     *
	     * @return Computed hashCode for xCoord combined with yCoord
	     */
	    
	    public override int GetHashCode() {
	        int result = 11; //non-zero prime
	        result = result * 37 + this.xCoord; //compute hash for xCoord
	        result = result * 37 + this.yCoord; //compute hash for yCoord
	        return result;
	    }
	}

}
