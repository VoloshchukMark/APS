using System;
using System.Collections.Generic;
using System.Linq;

namespace APS.Models
{
    abstract class Creator()
    {
        public abstract IModule FactoryMethod();

        private string Name;
        private int MaxGrade;


        public string DisplayInformation()
        {
            var module = FactoryMethod();
            var result = "Module: " + Name + "\n" +
                         "Max Grade: " + MaxGrade + "\n" +
                         module.GetList();

            return result;
        }
    }

    class TestModuleCreator : Creator
    {
        public override IModule FactoryMethod()
        {
            return new TestModule();
        }
    }

    class TestModule : IModule
    {
        public List<(string Name, int Grade)> tests;

        public TestModule()
        {
            tests = new List<(string Name, int Grade)>
            {
                ("Test 1", 5),
                ("Test 2", 5),
                ("Test 3", 10)
            };
        }


        public List<(string Name, int Grade)> GetList()
        {
            return tests;
        }
    }

    public interface IModule
    {
        List<(string Name, int Grade)> GetList();
    }

    class Module
    {
        public void ModuleCode(Creator creator)
        {
            Console.WriteLine(creator.DisplayInformation());
        }
    }


}