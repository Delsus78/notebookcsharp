using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;
using Xunit.Sdk;

namespace TestLogic
{
    public class TestAvgScore
    {
        [Fact]
        public void TestToString()
        {
            Module m = new Module();
            m.Name = "Maths";
            AvgScore instance = new AvgScore(15,m);

            string expected = "Maths (Moyenne : 15)";

            Assert.Equal(expected, instance.ToString());
        }
    }
}
