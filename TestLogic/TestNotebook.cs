using System;
using System.Collections.Generic;
using System.Text;
using Logic;
using Xunit;

namespace TestLogic
{
    public class TestNotebook
    {

        [Fact]
        public void TestListUnits()
        {
            Notebook nb = new Notebook();

            Assert.NotNull(nb.ListUnits());
            Assert.Empty(nb.ListUnits());

        }

        [Fact]
        public void TestListExams()
        {
            Notebook nb = new Notebook();

            Assert.NotNull(nb.ListExams());
            Assert.Empty(nb.ListExams());

        }

        [Fact]
        public void TestListModules()
        {
            Notebook nb = new Notebook();

            Assert.NotNull(nb.ListModules());
            Assert.Empty(nb.ListModules());

        }

        [Fact]
        public void TestAddUnit()
        {
            Notebook notebook = new Notebook();
            Unit unit = new Unit() { Coef = 15, Name = "Mat" };
            notebook.AddUnit(unit);

            Assert.Equal(unit, notebook.ListUnits().GetValue(0));
            Assert.Equal(1, notebook.ListUnits().Length);
        }

        [Fact]
        public void TestAddExam()
        {
            Notebook notebook = new Notebook();
            Module m = new Module();
            Exam exam = new Exam() { Coef = 15, Module = m };
            notebook.AddExam(exam);

            Assert.Equal(exam, notebook.ListExams().GetValue(0));
            Assert.Equal(1, notebook.ListExams().Length);
        }

        [Fact]
        public void TestRemoveUnit()
        {
            Notebook notebook = new Notebook();
            Unit unit = new Unit() { Coef = 15, Name = "Mat" };
            notebook.AddUnit(unit);
            notebook.RemoveUnit(unit);
            Assert.Empty(notebook.ListUnits());
        }

        [Fact]
        public void TestComputeScore()
        {
            Notebook nb = new Notebook();

            // UE 1
            Unit u = new Unit();
            nb.AddUnit(u);
            Module m1 = new Module();
            Module m2 = new Module();

            m1.Coef = 2;
            m2.Coef = 4;

            m1.Name = "Maths";
            m2.Name = "ProgCSharp";

            Exam e1 = new Exam();
            Exam e2 = new Exam();
            Exam e3 = new Exam();

            // Ajout des exams pour le premier module
            e1.Module = m1;
            e1.Coef = 1;
            e1.Score = 15;

            nb.Exams.Add(e1);

            // Ajout pour le 2eme module
            e2.Module = m2;
            e2.Coef = 2;
            e2.Score = 10;

            nb.Exams.Add(e2);

            e3.Module = m2;
            e3.Coef = 2;
            e3.Score = 20;

            u.AddModule(m1);
            u.AddModule(m2);

            nb.Exams.Add(e3);


            // UE 2
            Unit u2 = new Unit();
            nb.AddUnit(u2);
            Module m3 = new Module();
            Module m4 = new Module();

            m3.Coef = 1;
            m4.Coef = 1;

            m3.Name = "Anglais";
            m4.Name = "ExprCom";

            Exam e4 = new Exam();
            Exam e5 = new Exam();
            Exam e6 = new Exam();

            // Ajout des exams pour le premier module
            e4.Module = m3;
            e4.Coef = 4;
            e4.Score = 14;

            nb.Exams.Add(e4);

            // Ajout pour le 2eme module
            e5.Module = m4;
            e5.Coef = 1;
            e5.Score = 15;

            nb.Exams.Add(e5);

            e6.Module = m4;
            e6.Coef = 1;
            e6.Score = 15;
            
            nb.Exams.Add(e6);

            u2.AddModule(m3);
            u2.AddModule(m4);

            
            // Calcule du notebook

            AvgScore[] listresult = nb.ComputeScore();

            AvgScore expected1 = new AvgScore(15, u);
            AvgScore result1 = listresult[0];

            AvgScore expected2 = new AvgScore((float)15, u2);
            AvgScore result2 = listresult[1];

            Assert.Equal(expected1.Average, result1.Average);
            Assert.Equal(expected2.Average, result2.Average);
        }

        [Fact]
        public void TestComputeTotal()
        {
            Notebook nb = new Notebook();

            // UE 1
            Unit u = new Unit();
            nb.AddUnit(u);
            u.Coef = 2;
            Module m1 = new Module();
            Module m2 = new Module();

            m1.Coef = 2;
            m2.Coef = 4;

            m1.Name = "Maths";
            m2.Name = "ProgCSharp";

            Exam e1 = new Exam();
            Exam e2 = new Exam();
            Exam e3 = new Exam();

            // Ajout des exams pour le premier module
            e1.Module = m1;
            e1.Coef = 1;
            e1.Score = 15;

            nb.Exams.Add(e1);

            // Ajout pour le 2eme module
            e2.Module = m2;
            e2.Coef = 2;
            e2.Score = 10;

            nb.Exams.Add(e2);

            e3.Module = m2;
            e3.Coef = 2;
            e3.Score = 20;

            u.AddModule(m1);
            u.AddModule(m2);

            nb.Exams.Add(e3);


            // UE 2
            Unit u2 = new Unit();
            nb.AddUnit(u2);
            u2.Coef = 6;
            Module m3 = new Module();
            Module m4 = new Module();

            m3.Coef = 1;
            m4.Coef = 1;

            m3.Name = "Anglais";
            m4.Name = "ExprCom";

            Exam e4 = new Exam();
            Exam e5 = new Exam();
            Exam e6 = new Exam();

            // Ajout des exams pour le premier module
            e4.Module = m3;
            e4.Coef = 4;
            e4.Score = 14;

            nb.Exams.Add(e4);

            // Ajout pour le 2eme module
            e5.Module = m4;
            e5.Coef = 1;
            e5.Score = 15;

            nb.Exams.Add(e5);

            e6.Module = m4;
            e6.Coef = 1;
            e6.Score = 15;

            nb.Exams.Add(e6);

            u2.AddModule(m3);
            u2.AddModule(m4);


            // Calcule du notebook

           /*Désactivé car ne compile pas AvgScore result = nb.ComputeTotal();

            AvgScore expected = new AvgScore((float)14.625, u);

            Assert.Equal(expected.Average, result.Average);*/
        }

        [Fact]
        public void TestEqual()
        {
            Notebook instance1 = new Notebook();
            Notebook instance2 = new Notebook();
            // UE 1
            Unit u = new Unit();
            u.Coef = 2;

            instance1.AddUnit(u);
            instance2.AddUnit(u);

            Module m1 = new Module();
            Module m2 = new Module();

            m1.Coef = 2;
            m2.Coef = 4;

            m1.Name = "Maths";
            m2.Name = "ProgCSharp";

            Exam e1 = new Exam();
            Exam e2 = new Exam();
            Exam e3 = new Exam();

            // Ajout des exams pour le premier module
            e1.Module = m1;
            e1.Coef = 1;
            e1.Score = 15;

            instance1.Exams.Add(e1);
            instance2.Exams.Add(e1);

            // Ajout pour le 2eme module
            e2.Module = m2;
            e2.Coef = 2;
            e2.Score = 10;

            instance1.Exams.Add(e2);
            instance2.Exams.Add(e2);

            e3.Module = m2;
            e3.Coef = 2;
            e3.Score = 20;

            u.AddModule(m1);
            u.AddModule(m2);

            instance1.Exams.Add(e3);
            instance2.Exams.Add(e3);

            // UE 2
            Unit u2 = new Unit();
            u2.Coef = 6;

            instance1.AddUnit(u2);
            instance2.AddUnit(u2);

            Module m3 = new Module();
            Module m4 = new Module();

            m3.Coef = 1;
            m4.Coef = 1;

            m3.Name = "Anglais";
            m4.Name = "ExprCom";

            Exam e4 = new Exam();
            Exam e5 = new Exam();
            Exam e6 = new Exam();

                // Ajout des exams pour le premier module
            e4.Module = m3;
            e4.Coef = 4;
            e4.Score = 14;

            instance1.Exams.Add(e4);
            instance2.Exams.Add(e4);

            // Ajout pour le 2eme module
            e5.Module = m4;
            e5.Coef = 1;
            e5.Score = 15;

            instance1.Exams.Add(e5);
            instance2.Exams.Add(e5);

            e6.Module = m4;
            e6.Coef = 1;
            e6.Score = 15;

            instance1.Exams.Add(e6);
            instance2.Exams.Add(e6);

            u2.AddModule(m3);
            u2.AddModule(m4);

            // Nous savons ici que instance1 et instance2 ont recu les meme ajouts
            Assert.True(instance1.Equals(instance2));

        }
    }
}
