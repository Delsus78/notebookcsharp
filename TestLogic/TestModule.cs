using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestModule
    {
        [Fact]
        public void TestComputeAverage()
        {
            Module m = new Module();
            AvgScore avgExpected = new AvgScore(15, m);
            Notebook nb = new Notebook();

            Assert.Null(m.ComputeAverage(nb.ListExams()));

            Exam e1 = new Exam { Score = 10, Coef = 1, Module = m };
            nb.AddExam(e1);

            Exam e2 = new Exam { Score = 10, Coef = 2, Module = m };
            nb.AddExam(e2);

            Exam e3 = new Exam { Score = 20, Coef = 3, Module = m };
            nb.AddExam(e3);

            

            Assert.Equal(avgExpected.Average, m.ComputeAverage(nb.ListExams()).Average);
            
        }
    }
}
