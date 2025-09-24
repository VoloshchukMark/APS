using System;
using System.Collections.Generic;
using System.Linq;

namespace APS.Models
{
    public interface Module            //Interface Product
    {
        public void displayInformation();
    }

    public class TestModule : Module        //Concrete Product
    {
        public void displayInformation()
        {
            Console.WriteLine("Test Module Information");
        }
    }
    public class PracticalTestModule : Module
    {
        public void displayInformation()
        {
            Console.WriteLine("Practical Test Module Information");
        }
    }

    public interface ModuleManager         //Interface Creator
    {
        public Module createModule();

        public void RenderModuleInfo()
        {
            Module module = createModule();
            module.displayInformation();
        }
    }

    class TestModuleCreator : ModuleManager     //Concrete Creator
    {
        public Module createModule()
        {
            return new TestModule();
        }

    }

    class PracticalTestModuleCreator : ModuleManager
    {
        public Module createModule()
        {
            return new PracticalTestModule();
        }
    }

    //Test code
    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //         Console.WriteLine("App: Launched with the TestModuleCreator.");
    //         ModuleManager manager = new TestModuleCreator();
    //         manager.RenderModuleInfo();

    //         Console.WriteLine("");

    //         Console.WriteLine("App: Launched with the ProductionModuleCreator.");
    //         manager = new PracticalTestModuleCreator();
    //         manager.RenderModuleInfo();
    //     }
    // }
}