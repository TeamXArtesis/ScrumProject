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
    //    PutInDatabase databaseConnector = new PutInDatabase();

        public Records[] uitvoer(string path)
        {
            List<string> cllcn = readFromFile(path);
            string[] returncllcn = cllcn.ToArray();
            Records[] recs = null;
            try
            {
                recs= putDataToObjects(returncllcn);
            }
            catch
            { 
                
            }
            return recs;

        }


        public Records[] putDataToObjects(string[] collection)
        {
            Records[] cllctn = new Records[collection.Length];
            string[] lijst = null;
            int counter = 0;

            foreach (string s in collection)
            {
                lijst = parseOnTab(s);
                Records record = new Records(
                    deleteUFromHours(lijst[1]),
                    parsePuntComma(lijst[3]),
                    lijst[4],
                    lijst[5],
                    parsePuntComma(lijst[6]),
                    parsePuntComma(lijst[7]),
                    int.Parse(lijst[9]),
                    deleteUFromHours(lijst[13]),
                    getDayOutOfParser(lijst[12]),
                    8);
                cllctn[counter] = record;
                counter++;
            }
            //databaseConnector.addListToDatabase(cllctn);
            return cllctn;
        }

        public int getDayOutOfParser(string dag)
        {
            int dotw;
            switch (dag) {
                case "maandag": dotw = 1;
                    break;
                case "dinsdag": dotw = 2;
                    break;
                case "woensdag": dotw = 3;
                    break;
                case "donderdag": dotw =  4;
                    break;
                case "vrijdag": dotw = 5;
                    break;
                default: dotw = 1;
                    break;
            }

            return dotw;
        
        }

        public int deleteUFromHours(string duur)
        {
            return int.Parse(duur.Replace("u", string.Empty));;
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
            }

            StreamReader frstr_in = new StreamReader(reader, Encoding.GetEncoding("iso-8859-1"));

            while ((buffer = frstr_in.ReadLine()) != null)
            {
                uitvoer.Add(buffer);
            }

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

    }

}
