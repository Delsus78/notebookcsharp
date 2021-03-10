using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Logic
{
    [DataContract]
    public class Notebook
    {
        [DataMember]
        public List<Unit> Units { get; set; }
        [DataMember]
        public List<Exam> Exams { get; set; }
        [DataMember]
        public PedagogicalElement MoyenneGeneral { get; set; }

        public Notebook()
        {
            this.Units = new List<Unit>();
            this.Exams = new List<Exam>();
            this.MoyenneGeneral = new PedagogicalElement() { Coef = 1 , Name = "Général" };
        }

        /// <summary>
        /// retourne la liste d'units
        /// </summary>
        /// <return>une liste d'unit</return>
        public Unit[] ListUnits()
        {
            return this.Units.ToArray();
        }

        /// <summary>
        /// retourne la liste des modules de toutes les units
        /// </summary>
        /// <return>une liste d'unit</return>
        public Module[] ListModules()
        {
            List<Module> res = new List<Module>();
            foreach (Unit u in this.ListUnits())
                foreach (Module m in u.ListModules())
                    res.Add(m);
            return res.ToArray();
        }

        /// <summary>
        /// retourne la liste d exams
        /// </summary>
        /// <return>une liste d'unit</return>
        public Exam[] ListExams()
        {
            return this.Exams.ToArray();
        }

        /// <summary>
        /// ajoute une unit a la liste unit
        /// </summary>
        public void AddUnit(Unit unit)
        {
            this.Units.Add(unit);
        }

        /// <summary>
        /// ajoute un exam a la liste exam
        /// </summary>
        public void AddExam(Exam exam)
        {
            this.Exams.Add(exam);
        }

        /// <summary>
        /// supprime une unit de la liste units
        /// </summary>
        public void RemoveUnit(Unit unit)
        {
            this.Units.Remove(unit);
        }

        /// <summary>
        /// supprime un exam de la liste exams
        /// </summary>
        public void RemoveExam(Exam exam)
        {
            this.Exams.Remove(exam);
        }

        /// <summary>
        /// calcule la moyenne de chaque UE
        /// </summary>
        /// <returns></returns>
        public AvgScore[] ComputeScore()
        {
            List<AvgScore> res = new List<AvgScore>();

            float avgRes = 0;
            float avgDiv = 0;

            foreach (Unit u in ListUnits())
            {
                AvgScore[] unitAvg = u.ComputeAverages(ListExams());

                if (unitAvg.Length != 0)
                {
                    // on récupère seulement le rang 0 = la moyenne de l'unit
                    avgRes += unitAvg[0].Element.Coef * unitAvg[0].Average;
                    avgDiv += unitAvg[0].Element.Coef;

                    for (int i = 0; i < unitAvg.Length; i++) res.Add(unitAvg[i]);
                }
            }
            
            if (avgDiv != 0)
            {
                avgRes = avgRes / avgDiv;
                res.Insert(0,new AvgScore(avgRes, this.MoyenneGeneral));
            }
            return res.ToArray();
        }

        public override bool Equals(object o)
        {
            bool res = true;
            if (!o.GetType().IsInstanceOfType(this)) res = false;
            else
            {
                Notebook n = (Notebook) o;

                if (!this.ListExams().Equals(n.ListExams())) res = false;
                if (!this.ListUnits().Equals(n.ListUnits())) res = false;
                if (!this.ListModules().Equals(n.ListModules())) res = false;
            }

            return res;
        }
    }
}
