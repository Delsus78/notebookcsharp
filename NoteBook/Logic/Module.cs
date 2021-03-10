using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Module : PedagogicalElement
    {
        public AvgScore ComputeAverage(Exam[] exams)
        {
            AvgScore res = null;
            float avgRes = 0;
            float avgDiv = 0;

            foreach (Exam e in exams)
            {
                if (e.Module.Equals(this))
                {
                    avgRes += e.Coef * e.Score;
                    avgDiv += e.Coef;
                }
            }
            if (avgDiv != 0)
            {
                avgRes = avgRes / avgDiv;
                res = new AvgScore(avgRes, this);
            }

            return res;

        }
    }
}
