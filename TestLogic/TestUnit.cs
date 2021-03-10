using System;
using System.Collections.Generic;
using System.Text;
using Logic;
using Xunit;
using Xunit.Sdk;

namespace TestLogic
{
    public class TestUnit
    {
        [Fact]
        public void TestListModules()
        {
            Unit nb = new Unit();

            Assert.NotNull(nb.ListModules());
            Assert.Empty(nb.ListModules());

        }

        [Fact]
        public void TestAddModule()
        {
            Unit unit = new Unit() { Coef = 15, Name = "Mat" };
            Module Module = new Module() { Coef = 10, Name = "Module" };
            unit.AddModule(Module);

            Assert.Equal(Module, unit.ListModules().GetValue(0));
            Assert.Equal(1, unit.ListModules().Length);
        }

        [Fact]
        public void TestRemoveModule()
        {
            Unit unit = new Unit() { Coef = 15, Name = "Mat" };
            Module Module = new Module() { Coef = 15, Name = "Mat" };
            unit.AddModule(Module);
            unit.RemoveModule(Module);
            Assert.Empty(unit.ListModules());
        }

        [Fact]
        public void TestComputeAverages()
        {
            Unit u = new Unit();
            Module m1 = new Module();
            Module m2 = new Module();
            Notebook nb = new Notebook();

            m1.Name = "Maths";
            m2.Name = "ProgCSharp";
            m1.Coef = 2;
            m2.Coef = 1;

            Exam e1 = new Exam();
            Exam e2 = new Exam();
            Exam e3 = new Exam();

            // Ajout des exams pour le premier module
            e1.Module = m1;
            e1.Coef = 10;
            e1.Score = 10;

            nb.Exams.Add(e1);

            // Ajout pour le 2eme module
            e2.Module = m2;
            e2.Coef = 2;
            e2.Score = 10;

            nb.Exams.Add(e2);

            e3.Module = m2;
            e3.Coef = 2;
            e3.Score = 20;

            nb.Exams.Add(e3);

            // Calcule de l Unit
            AvgScore[] listresult = u.ComputeAverages(nb.Exams.ToArray());


            // Test liste vide (vu que aucun module dans l'unit u)
            Assert.Empty(listresult);

            // Test du contenu de listresult
            u.AddModule(m1);
            u.AddModule(m2);

            listresult = u.ComputeAverages(nb.Exams.ToArray());

            AvgScore expected1 = new AvgScore(11.666f, m1);
            AvgScore result1 = listresult[1];

            AvgScore expected2 = new AvgScore(10,m1);
            AvgScore result2 = listresult[1];

            AvgScore expected3 = new AvgScore(15, m2);
            AvgScore result3 = listresult[2];

            Assert.Equal(expected1.Average, result1.Average,3);
            Assert.Equal(expected2.Average, result2.Average);
            Assert.Equal(expected3.Average, result3.Average);
        }
    }
}
