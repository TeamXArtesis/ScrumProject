using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;

namespace ParserScrumProject
{
    class PutInDatabase
    {
        private SqlConnection connection;
        Form1 gs = new Form1();

        private static PutInDatabase instance = null;

        public static PutInDatabase getInstance()
        {
            if (instance == null)
            {
                instance = new PutInDatabase();
            }
            return instance;
        }

        public void setConnectionString(string pcname, string username, string password)
        {
            connection = new SqlConnection(@"Data Source="+pcname+";Initial Catalog=Timetable;Persist Security Info=True;User ID="+username+";Password="+password+"");
        }

        public Boolean testConnection()
        {
            Boolean success = false;
            try
            {
                connection.Open();
                success = true;
            }
            catch
            {
                success = false;
            }
            finally
            {
                connection.Close();
            }
            return success;
        }

        public void addListToDatabase(Records recs, string pcname, string username, string password)
        {
            connection = new SqlConnection(@"Data Source=" + pcname + ";Initial Catalog=Timetable;Persist Security Info=True;User ID=" + username + ";Password=" + password + "");

            try
            {
                connection.Open();
                    int minutes = recs.StartUur % 100;
                    int hours = recs.StartUur / 100;

                    TimeSpan startTijd = new TimeSpan(hours, minutes, 0);

                    int olodId = checkOlod(recs.Deelopleidingsonderdeel.Replace('\'', ' '), recs.Opleidingsonderdeel.Replace('\'', ' '), recs.Studiepunten);

                    Docent[] docenten = new Docent[recs.Docenten.Length];
                    int count = 0;
                    if (recs.Docenten.Length != 0)
                    {
                        foreach (string s in recs.Docenten)
                        {
                            if (s.Contains(' '))
                            {
                                string[] naamvoornaam = s.Split(' ');
                                if (naamvoornaam.Length == 2)
                                {
                                    docenten[count] = new Docent(naamvoornaam[0].Replace('\'', ' '), naamvoornaam[1].Replace('\'', ' '));
                                }
                                else
                                {
                                    string achternaam = naamvoornaam[0];
                                    for (int i = 1; i < naamvoornaam.Length-1; i++)
                                    { 
                                        achternaam += " "+naamvoornaam[i];
                                    }
                                    docenten[count] = new Docent(achternaam.Replace('\'', ' '), naamvoornaam[naamvoornaam.Length - 1].Replace('\'', ' '));
                                }
                            }
                            else
                            {
                                docenten[count] = new Docent(s, string.Empty);
                            }
                            count++;
                        }
                    }
                    else
                    {
                        docenten[count] = new Docent("info", "artesis");
                    }

                    int[] docentId = checkDocent(docenten);
                    checkOlodDocentRelation(docentId, olodId);
                    int[] klasid = checkKlas(recs.Klas);
                    checkOlodKlasRelation(klasid, olodId);

                    int duur = (recs.Duration%100)+((recs.Duration/100)*60);

                    string room = null;

                    foreach (string s in recs.Lokaal)
                    {
                        room += s + "  ";
                    }

                    int dag = recs.Dag;

                    CultureInfo ciCurr = CultureInfo.CurrentCulture;
                    int week = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

                    SqlCommand addLes = connection.CreateCommand();
                    addLes.CommandText = "INSERT INTO Les (tijd, olod_id, duur_in_minuten,lokaal, dag, week) VALUES ('" + startTijd + "'," + olodId + ", " +
                    +duur + ",'"+room+"'," + dag + "," + week + ")";
                    addLes.ExecuteNonQuery();

                    

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private int checkOlod(string deelOpleidingsOnderdeel, string opleidingsOnderdeel, int studiepunten)
        {
            int id = 0;
            Boolean found = false;
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Olod";

            SqlDataReader thisReader = command.ExecuteReader();
            List<string> dolodList = new List<string>();
            Boolean nothingInDatabase = false;
            if (!thisReader.HasRows)
            {
                nothingInDatabase = true;
            }
            while (thisReader.Read())
            {
                dolodList.Add(thisReader.GetString(1));
            }
            thisReader.Close();

            foreach (string s in dolodList)
            {
                if (s == deelOpleidingsOnderdeel)
                {
                    found = true;
                }

            }

            if (!found || nothingInDatabase)
            {
                addOlodToDatabase(deelOpleidingsOnderdeel, opleidingsOnderdeel, studiepunten);
            }

            SqlCommand getOlodId = connection.CreateCommand();
            getOlodId.CommandText = "select olod_id from Olod where naam = '" + deelOpleidingsOnderdeel + "'";

            SqlDataReader idReader = getOlodId.ExecuteReader();
            while (idReader.Read())
            {
                id = idReader.GetInt32(0);
            }

            idReader.Close();
            return id;
        }

        private void addOlodToDatabase(string deelOpleidingsOnderdeel, string opleidingsOnderdeel, int studiepunten)
        {
            SqlCommand docentQuery = connection.CreateCommand();
            docentQuery.CommandText = "INSERT INTO olod (naam,studiepunten,omschrijving) values ('" + deelOpleidingsOnderdeel + "'," + studiepunten + ",'" + opleidingsOnderdeel + "')";
            docentQuery.ExecuteNonQuery();
        }

        private int[] checkDocent(Docent[] docenten)
        {
            int[] id = new int[docenten.Length];

            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Docent";
            SqlDataReader thisReader = command.ExecuteReader();
            List<string> email = new List<string>();

            while (thisReader.Read())
            {
                email.Add(thisReader.GetString(3));
            }
            thisReader.Close();


            int count = 0;
            Boolean found = false;

            foreach (Docent temp in docenten)
            {
                foreach (string a in email)
                {
                    if (a == temp.Email)
                        found = true;
                }

                if (!found || email.Count == 0)
                {
                    addDocentToDatabase(temp.Name, temp.Lastname, temp.Email);
                }
                found = false;

            }


            SqlCommand getDocentId = connection.CreateCommand();
            foreach (Docent a in docenten)
            {
                getDocentId.CommandText = "select docent_id from Docent where email = '" + a.Email + "'";
                SqlDataReader idReader = getDocentId.ExecuteReader();
                while (idReader.Read())
                {
                    id[count] = idReader.GetInt32(0);
                }
                count++;
                idReader.Close();
            }
            return id;
        }

        private void addDocentToDatabase(string naam, string voornaam, string email)
        {
            SqlCommand docentQuery = connection.CreateCommand();
            docentQuery.CommandText = "insert into Docent (naam,voornaam, email) values('" +voornaam + "','" + naam + "','" + email + "')";
            docentQuery.ExecuteNonQuery();
        }

        private int[] checkKlas(string[] klas)
        {
            int[] id = new int[klas.Length];
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Klas";
            SqlDataReader thisReader = command.ExecuteReader();
            List<string> klassen = new List<string>();

            while (thisReader.Read())
            {
                klassen.Add(thisReader.GetString(2));
            }
            thisReader.Close();


            int count = 0;
            Boolean found = false;

            foreach (string a in klas)
            {
                foreach (string s in klassen)
                {
                    if (a == s)
                        found = true;
                }

                if (!found || klassen.Count == 0)
                {
                    addKlasToDatabase(a);
                }
                found = false;

            }


            SqlCommand getDocentId = connection.CreateCommand();
            foreach (string s in klas)
            {
                getDocentId.CommandText = "select klas_id from Klas where naam = '" + s + "'";
                SqlDataReader idReader = getDocentId.ExecuteReader();
                while (idReader.Read())
                {
                    id[count] = idReader.GetInt32(0);
                }
                count++;
                idReader.Close();
            }
            return id;
        }

        private void addKlasToDatabase(string a)
        {
            SqlCommand docentQuery = connection.CreateCommand();
            docentQuery.CommandText = "insert into Klas (afkorting,naam) values('Info','" +a + "')";
            docentQuery.ExecuteNonQuery();
        }

        private void checkOlodKlasRelation(int[] klasid, int olodid)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT klas_id FROM Klas_olod where olod_id = " + olodid + "";
            SqlDataReader thisReader = command.ExecuteReader();
            List<int> klasOlod = new List<int>();
            Boolean found = false;
            while (thisReader.Read())
            {
                klasOlod.Add(thisReader.GetInt32(0));
            }
            thisReader.Close();

            foreach (int i in klasid)
            {
                foreach (int j in klasOlod)
                {
                    if (i == j)
                        found = true;
                }
                if (!found || klasOlod.Count == 0)
                    addKlasOlodRelation(i, olodid);
                else
                    found = false;
            }


        }

        private void addKlasOlodRelation(int i, int olodid)
        {
            SqlCommand docentQuery = connection.CreateCommand();
            docentQuery.CommandText = "insert into Klas_olod (klas_id,olod_id) values(" + i + "," + olodid + ")";
            docentQuery.ExecuteNonQuery();
        }

        private void checkOlodDocentRelation(int[] docent, int olodid)
        {
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT docent_id FROM Docent_olod where olod_id = " + olodid + "";
            SqlDataReader thisReader = command.ExecuteReader();
            List<int> DocentOlod = new List<int>();
            Boolean found = false;
            while (thisReader.Read())
            {
                DocentOlod.Add(thisReader.GetInt32(0));
            }
            thisReader.Close();

            foreach (int i in docent)
            {
                foreach (int j in DocentOlod)
                {
                    if (i == j)
                        found = true;
                }
                if (!found || DocentOlod.Count == 0)
                    addDocentOlodRelation(i, olodid);
                else
                    found = false;
            }
        }

        private void addDocentOlodRelation(int i, int olodid)
        {
            SqlCommand docentQuery = connection.CreateCommand();
            docentQuery.CommandText = "insert into Docent_olod (docent_id,olod_id) values(" + i + "," + olodid + ")";
            docentQuery.ExecuteNonQuery();
        }
    }
}
