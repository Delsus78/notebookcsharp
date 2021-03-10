using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Logic
{
    [DataContract]
    public class Unit : PedagogicalElement
    {
        [DataMember] private List<Module> modules = new List<Module>();


        /// <summary>
        /// Renvoi une exception si la valeur est null
        /// </summary>
        public List<Module> Modules
        {
            get => modules;
            set
            {
                if (value == null) throw new Exception("The teacher can't be empty");
                modules = value;
            }
        }

        /// <summary>
        /// Renvoie une liste de modules
        /// </summary>
        /// <returns>une liste de modules</returns>
        public Module[] ListModules()
        {
            return this.modules.ToArray();
        }

        /// <summary>
        /// ajoute un module a la liste modules
        /// </summary>
        public void AddModule(Module module)
        {
            this.modules.Add(module);
        }

        /// <summary>
        /// supprime un module de la liste modules
        /// </summary>
        public void RemoveModule(Module module)
        {
            this.modules.Remove(module);
        }
    
        /// <summary>
        /// calcule la moyenne de tout les modules de cette UE
        /// </summary>
        /// <param name="exams">liste d'exam</param>
        /// <returns></returns>
        public AvgScore[] ComputeAverages(Exam[] exams)
        {
            List<AvgScore> res = new List<AvgScore>();

            float avgRes = 0;
            float avgDiv = 0;

            foreach (Module m in ListModules())
            {
                AvgScore moduleAvg = m.ComputeAverage(exams);

                if (moduleAvg != null)
                {
                    avgRes += moduleAvg.Element.Coef * moduleAvg.Average;
                    avgDiv += moduleAvg.Element.Coef;

                    res.Add(moduleAvg);
                }
            }
            if (avgDiv != 0)
            {
                avgRes = avgRes / avgDiv;
                res.Insert(0,new AvgScore(avgRes, this));
            }
            
            return res.ToArray();
        }
    }
}