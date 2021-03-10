using System;
using Logic;
using Storage;
using Xunit;

namespace TestStorage
{
    public class TestStorage
    {

        /// <summary>
        /// en on recupere le test des moyennes (ajoutant tout un tas de modules et d'unite + exams)
        /// puis on test une sauvegarde entre temps (avec donc un ajout d'un IStockage)
        /// </summary>
        [Fact]
        public void TestSave()
        {
            IStockage stockage = new JsonStockage();

            Notebook nb = stockage.Load();

            // UE 1
            Unit u = new Unit();
            nb.AddUnit(u);

            Module m1 = new Module();

            m1.Coef = 2;

            m1.Name = "Maths";

            Exam e1 = new Exam();
            Exam e2 = new Exam();

            // Ajout des exams pour le premier module
            e1.Module = m1;
            e1.Coef = 1;
            e1.Score = 15;

            nb.Exams.Add(e1);

            // Ajout pour le 2eme module
            e2.Module = m1;
            e2.Coef = 2;
            e2.Score = 10;

            nb.Exams.Add(e2);

            u.AddModule(m1);

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

            // on vient une premiere fois sauvegarder cette instance
            stockage.Update(nb);

            // on récupère le notebook sauvegardé
            Notebook savedNB = stockage.Load();

            // puis on test si les deux correspondes
            Assert.Equal(nb,savedNB);

        }
    }
}
