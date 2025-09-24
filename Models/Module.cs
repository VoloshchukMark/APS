using System;
using System.Collections.Generic;
using System.Linq;

namespace APS.Models
{
    public abstract class Module            //Abstract Product
    {
        public abstract void displayInformation();
    }

    public class TestModule : Module        //Concrete Product
    {
        override public void displayInformation()
        {
            Console.WriteLine("Test Module Information");
        }
    }
    public class PracticalTestModule : Module
    {
        override public void displayInformation()
        {
            Console.WriteLine("Practical Test Module Information");
        }
    }

    public abstract class ModuleManager         //Abstract Creator
    {
        public abstract Module createModule();

        public void RenderModuleInfo()
        {
            Module module = createModule();
            module.displayInformation();
        }
    }

    class TestModuleCreator : ModuleManager     //Concrete Creator
    {
        override public Module createModule()
        {
            return new TestModule();
        }

    }

    class PracticalTestModuleCreator : ModuleManager
    {
        override public Module createModule()
        {
            return new PracticalTestModule();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("App: Launched with the TestModuleCreator.");
            ModuleManager manager = new TestModuleCreator();
            manager.RenderModuleInfo();

            Console.WriteLine("");

            Console.WriteLine("App: Launched with the ProductionModuleCreator.");
            manager = new PracticalTestModuleCreator();
            manager.RenderModuleInfo();
        }
    }
}