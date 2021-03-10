using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Logic
{
    [DataContract]
    public class PedagogicalElement
    {

        [DataMember] private float coef;
        [DataMember] private string name;

        /// <summary>
        /// Renvoi une exception si la valeur est <= 0
        /// </summary>
        public float Coef
        {
            get => coef;
            set
            {                
                if (value <= 0) throw new Exception("The coef must be > 0");
                coef = value;
            }
        }

        /// <summary>
        /// Renvoi une exception si la valeur est vide ou null
        /// </summary>
        public string Name
        {
            get => name;
            set
            {
                //if (value == null || value == "") Correction, il existe une méthode pour faire cela
                if (String.IsNullOrEmpty(value)) throw new Exception("The name can't be empty");
                name = value;
            }
        }

        public override string ToString()
        {
            //return this.name + " ("+this.coef+")"; Conseil, utiliser un formateur pour simplifier la lecture de la méthode
            return String.Format("{0} ({1})", this.Name, this.Coef);
        }

        public bool Equals(PedagogicalElement pe)
        {
            bool res = true;

            if (pe.ToString() != this.ToString()) res = false;// Ca ne garantie pas l'égalité, c'est un hack, comparer terme à terme

            return res;
        }
    }
}
