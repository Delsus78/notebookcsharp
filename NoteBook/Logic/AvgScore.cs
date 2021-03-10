using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class AvgScore
    {
        public string ElementName { get => Element.Name; }
        public PedagogicalElement Element { get; set; }
        public float Average { get; set; }

        public AvgScore(float average, PedagogicalElement pe)
        {
            this.Average = average;
            this.Element = pe;
        }

        public override string ToString()
        {
            return this.ElementName + " (Moyenne : " + this.Average + ")";
        }
    }
}
