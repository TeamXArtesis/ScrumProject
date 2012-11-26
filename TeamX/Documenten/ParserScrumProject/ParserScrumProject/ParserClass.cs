using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.IO;

namespace ParserScrumProject
{
    class ParserClass
    {

        public string[] uitvoer(string path)
        {
            List<string> cllcn = readFromFile(path);
            string[] returncllcn = cllcn.ToArray();

            return returncllcn;
        }

        public string[] test(string path)
        {
            string[] lijst = null;
            string[] uitvoer = new string[1];
            string[] tempPuntComma = null;
            //string[] listToArraytemp = null;
            string[] addStringToArray = null;
            List<string> temp2 = new List<string>();
            List<string> col = readFromFile(path);
            string puntComma = ";";

            foreach (string s in col)
            {
                lijst = parseOnTab(s);
                foreach (string a in lijst)
                {
                    if (a.Contains(puntComma))
                    {
                        tempPuntComma = parsePuntComma(a);

                        addStringToArray = new string[uitvoer.Length + tempPuntComma.Length];
                        uitvoer.CopyTo(addStringToArray, 0);
                        tempPuntComma.CopyTo(addStringToArray, uitvoer.Length);
                        uitvoer = addStringToArray;
                        addStringToArray = null;
                    }
                    else
                    {
                        addStringToArray = new string[uitvoer.Length + 1];
                        uitvoer.CopyTo(addStringToArray, 0);
                        addStringToArray[uitvoer.Length] = a;
                        uitvoer = addStringToArray;
                        addStringToArray = null;
                    }
                }
            }

            return uitvoer;
        }

        public List<string> readFromFile(string path)
        {
            List<string> uitvoer = new List<string>();
            FileStream reader =null;
            string buffer = null;

            try
            {
                reader = new FileStream(@path, FileMode.Open);
            }
            catch (FileNotFoundException e)
            {
                System.Windows.Forms.MessageBox.Show("File in use "+e);
                //Console.WriteLine(e);
            }

            StreamReader frstr_in = new StreamReader(reader);

            while ((buffer = frstr_in.ReadLine()) != null)
            {
                uitvoer.Add(buffer);
            }

            //buffer = frstr_in.ReadLine();
            //uitvoer.Add(buffer);

            return uitvoer;
        }

        public string[] parsePuntComma(string value)
        {
            char[] puntComma = {';'};
            string[] lijst = value.Split(puntComma);
            return lijst;
        }

        public string[] parseOnTab(string value)
        {
            char[] tab = {'\t'};
            string[] lijst = value.Split(tab);
            return lijst;
        }



        //public void checkDocent(string name)
        //{
        //    ResultSet rs = null;
        //    string docentName = null;
        //    bool inDatabase = false;
        //    while (rs.next())
        //    {
        //        docentName = rs.getstring("naam") + " " + rs.getstring("voornaam");
        //        if (docentName == name)
        //        {
        //            inDatabase = true;
        //        }
        //    }
        //    if (!inDatabase)
        //    {
        //        insert docent query here
        //    }
        //}

        //public void checkClass(string className)
        //{
        //    ResultSet rs = null;
        //    string nameClass = null;
        //    bool inDatabase = false;
        //    while(rs.next())
        //    {
        //        nameClass = rs.getstring("naam");
        //        if(nameClass == className)
        //        {
        //            inDatabase = true;
        //        }
        //    }
        //    if(!inDatabase)
        //    {
        //        // insert class query here
        //    }
        //}

        //public Boolean addDocent(int id, string name, string lastName, string email)
        //{
        //    try{
        //        //insert query here
        //        return true;
        //    }
        //    catch(Exception E){
        //        E.ToString();
        //        return false;
        //    }

        //}

    }

}
