using System;
using APS.Demo; // Make sure to import the Demo namespace

// This is the main entry point for your application
public class Program
{
    public static void Main(string[] args)
    {
        // Call the static Run method from the demo class
        CommandPatternDemo.Run();
        MediatorPatternDemo.Run();
    }
}