using DevTeams_Challenge_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevTeamTest2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Developer dev = new Developer();
            dev.Specialty = (Specialty)1;
            Console.WriteLine($"{ dev.Specialty}");
        }
    }
}
