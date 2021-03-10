using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Logic
{
    [DataContract]
    public class Exam
    {
        [DataMember] private string teacher;
        [DataMember] private DateTime dateExam = DateTime.Now;
        [DataMember] private float coef = 1;
        [DataMember] private bool isAbsent = true;
        [DataMember] private float score = 0;
        [DataMember] private Module module;

        /// <summary>
        /// Get/Set de Teacher
        /// </summary>
        public string Teacher
        {
            get => teacher;
            set
            {
                if (value == null || value == "") throw new Exception("The teacher can't be empty");
                teacher = value;
            }
        }

        /// <summary>
        /// la date est set a aujourd'hui de base
        /// </summary>
        public DateTime DateExam
        {
            get => dateExam;
            set
            {
                if (value == null) throw new Exception("The date can't be empty");
                dateExam = value;
            }
        }
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
        /// si la valeur est true, met la note à 0
        /// </summary>
        public bool IsAbsent
        {
            get => isAbsent;
            set
            {
                isAbsent = value;
                if (isAbsent) Score = 0;
            }
        }

        /// <summary>
        /// Renvoi une exception si la valeur est < 0 ou > 20
        /// </summary>
        public float Score
        {
            get => score;
            set
            {
                if (value < 0 || value > 20) throw new Exception("The score can't be <0 or >20");
                score = value;
            }
        }

        /// <summary>
        /// Renvoi une exception si la valeur est null
        /// </summary>
        public Module Module
        {
            get => module;
            set
            {
                module = value ?? throw new Exception("The module can't be null");
            }
        }

        public bool Equals(Exam e)
        {
            bool res = true;
            //Correction, on peut aussi aggréger les tests avec &&
            if (e.Teacher != this.Teacher) res = false;
            if (e.Coef != this.Coef) res = false;
            if (e.Score != this.Score) res = false;
            if (e.Module != this.Module) res = false;
            if (e.isAbsent != this.isAbsent) res = false;
            //Ok mais pas très fiable, on peut comparer la date 
            //if ((e.DateExam-this.DateExam).TotalSeconds > 0.5) res = false;
            res &= dateExam.ToShortDateString().Equals(e.dateExam.ToShortDateString());

            return res;
        }

    }
}
