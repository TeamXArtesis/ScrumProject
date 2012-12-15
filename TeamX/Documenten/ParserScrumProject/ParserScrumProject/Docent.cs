using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserScrumProject
{
    class Docent
    {
        private string lastname;

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public Docent(string lastname, string name)
        {
            this.lastname = lastname;
            this.name = name;
            this.email = name+"."+lastname.Replace(" ",string.Empty)+"@artesis.be";
        }
    }
}
