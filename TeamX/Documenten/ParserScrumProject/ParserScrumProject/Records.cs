using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserScrumProject
{
    class Records : IEnumerable
    {
        private int duration;

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        private string[] docenten = null;

        public string[] Docenten
        {
            get { return docenten; }
            set { docenten = value; }
        }
        private string opleidingsonderdeel;

        public string Opleidingsonderdeel
        {
            get { return opleidingsonderdeel; }
            set { opleidingsonderdeel = value; }
        }
        private string deelopleidingsonderdeel;

        public string Deelopleidingsonderdeel
        {
            get { return deelopleidingsonderdeel; }
            set { deelopleidingsonderdeel = value; }
        }
        private string[] klas;

        public string[] Klas
        {
            get { return klas; }
            set { klas = value; }
        }

        private string[] lokaal;

        public string[] Lokaal
        {
            get { return lokaal; }
            set { lokaal = value; }
        }

        private int studiepunten;

        public int Studiepunten
        {
            get { return studiepunten; }
            set { studiepunten = value; }
        }
        private int dag;

        public int Dag
        {
            get { return dag; }
            set { dag = value; }
        }

        private int week;

        public int Week
        {
            get { return week; }
            set { week = value; }
        }

        private int startUur;

        public int StartUur
        {
            get { return startUur; }
            set { startUur = value; }
        }


        public Records(int duration, string[] docenten, string opleidingsonderdeel, string deelopleidingsonderdeel, string[] klas, string[] lokaal, int studiepunten, int startUur, int dag, int week)
        {
            this.Duration = duration;
            this.Docenten = docenten;
            this.Opleidingsonderdeel = opleidingsonderdeel;
            this.Deelopleidingsonderdeel = deelopleidingsonderdeel;
            this.Klas = klas;
            this.Lokaal = lokaal;
            this.Studiepunten = studiepunten;
            this.Dag = dag;
            this.week = week;
            this.StartUur = startUur;
        }

        public override string ToString()
        {
            string docent = null;
             
            foreach(string s in docenten)
            {
                docent += s + " ";
            }

            string lokalen = null;
            foreach (string d in lokaal)
            {
                lokalen += d + " ";
            }

            return Duration + " " +docent +" "+ Opleidingsonderdeel + " " + Deelopleidingsonderdeel + " " + Klas + " " + lokalen + " " + Studiepunten + " " + dag+ " "+week;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
