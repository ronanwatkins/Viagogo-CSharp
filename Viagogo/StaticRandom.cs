using System;
using System.Threading;

namespace Viagogo
{
	/**
	 * Static method for creating random numbers
	 * Needed to use this as creating a random number in a tight loop creates the same number multiple times
	 * because random numbers are initialised by the clock in C#
	 * Taken from https://stackoverflow.com/questions/767999/random-number-generator-only-generating-one-random-number
	*/
	
	public static class StaticRandom
	{
	    private static int seed;
	
	    private static ThreadLocal<Random> threadLocal = new ThreadLocal<Random>
	        (() => new Random(Interlocked.Increment(ref seed)));
	
	    static StaticRandom()
	    {
	        seed = Environment.TickCount;
	    }
	
	    public static Random Instance { get { return threadLocal.Value; } }
	}
}
