using System;
using System.Collections.Generic;

namespace APS.Models
{
    public class Test
    {
        private string Name;
        private List<Question> Questions;
        
        public string GetName() { return Name; }
        public void SetName(string name) { Name = name; }
        
        public List<Question> GetQuestions() { return Questions; }
        public void SetQuestions(List<Question> questions) { Questions = questions; }

        public Test()
        {
            Name = "";
            Questions = [];
        }

        public Test(string name)
        {
            Name = name;
            Questions = [];
        }

        public Test(string name, List<Question> questions)
        {
            Name = name;
            Questions = questions;
        }
    }
    
    public static class TestPool
    {
        private static List<Test> AvailableTests = [];
        private static List<Test> UsedTests = [];
        
        public static Test GetTest()
        {
            lock(AvailableTests)
            {
                if (AvailableTests.Count == 0)
                {
                    var test = new Test();
                    UsedTests.Add(test);
                    return test;
                }
                else
                {
                    var test = AvailableTests[0];
                    AvailableTests.RemoveAt(0);
                    UsedTests.Add(test);
                    return test;
                }
            }
        }
        
        public static void ReleaseTest(Test test)
        {
            CleanTest(test);

            lock(AvailableTests)
            {
                UsedTests.Remove(test);
                AvailableTests.Add(test);
            }
        }
        
        private static void CleanTest(Test test)
        {
            test.SetName("");
            test.SetQuestions([]);
        }
    }
}