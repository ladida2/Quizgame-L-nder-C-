using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace Projektarbeit_Quizgame
{
    public class Datenbank
    {
        private MySqlConnection con = null;
        public Datenbank()
        {
            con = new MySqlConnection("SERVER = localhost;UID = root; PASSWORD = '';DATABASE = Quizgame");
        }

        // Datenbank Funktionen
        private void oeffnen()
        {

            con.Open();
        }
        private void schliessen()
        {
            if (con != null)
                con.Close();
        }

        // Benutzer und passwort prüfen 
        public Nutzer checkNutzer(string nutzer, string passwort)
        {
            string s = string.Format("select * from benutzer where nutzername = '{0}' and passwort ='{1}'", nutzer, passwort);

            oeffnen();


            MySqlCommand com = con.CreateCommand();
            com.CommandText = s;
            MySqlDataReader reader = com.ExecuteReader();
            try
            {

                if (reader.Read())
                {
                    return new Nutzer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler in check_passwort: " + ex.Message);
            }
            finally
            {
                reader.Close();
                schliessen();

            }
            return null;


        }

        // listen 
        public List<Land> getLaender()
        {
            List<Land> lilä = new List<Land>();
            oeffnen();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = "Select * from laender order by rand();";
            MySqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                lilä.Add(
                    new Land(reader.IsDBNull(1) ? -1 : reader.GetInt32(0)
                                   , reader.IsDBNull(0) ? "" : reader.GetString(1)
                                   , reader.IsDBNull(0) ? "" : reader.GetString(2)
                                   , reader.IsDBNull(1) ? -1 : reader.GetInt32(3)
                                  )
                    );
            }
            schliessen();
            return lilä;
        }
        public List<Kontinente> getKontinente()
        {
            List<Kontinente> likon = new List<Kontinente>();
            oeffnen();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = "Select * from kontinente;";
            MySqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                likon.Add(
                    new Kontinente(reader.IsDBNull(1) ? -1 : reader.GetInt32(0)
                                   , reader.IsDBNull(0) ? "" : reader.GetString(1)
                                  )
                    );
            }
            schliessen();
            return likon;
        }
        public List<Highscore> getHighscore()
        {
            List<Highscore> lihigh = new List<Highscore>();
            oeffnen();
            MySqlCommand com = con.CreateCommand();
            com.CommandText = "Select * from highscore order by score desc;";
            MySqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                lihigh.Add(
                    new Highscore(   reader.IsDBNull(1) ? -1 : reader.GetInt32(0)
                                   , reader.IsDBNull(1) ? -1 : reader.GetInt32(1)
                                   , reader.IsDBNull(1) ? -1 : reader.GetInt32(2)
                                  )
                    );
            }
            schliessen();
            return lihigh;
        }
  
        //Nutzer Speichern
        public void saveLogin(Nutzer l)
        {
            oeffnen();
            string s = String.Format("Insert into benutzer Values(null,'{0}','{1}');",
                                       l.Nutzername, l.Passwort);
            MySqlCommand com = con.CreateCommand();
            com.CommandText = s;
            com.ExecuteNonQuery();

            schliessen();
        }

        // Highscore
        public void saveHighscore(Highscore hs)
        {
            oeffnen();
            string s = String.Format("Insert into highscore Values(null,{0},{1});",
                                       hs.Score,hs.B_id);
            MySqlCommand com = con.CreateCommand();
            com.CommandText = s;
            com.ExecuteNonQuery();

            schliessen();
        }
        public int HighscoreSpieler(int b_id)
        {

            int i=0;
            oeffnen();

            string s = string.Format
                ("select max(score) from highscore where b_id = {0}; ",b_id);


            MySqlCommand com = con.CreateCommand();
            com.CommandText = s;
            MySqlDataReader reader = com.ExecuteReader();

            if (reader.Read())
            {
                i = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
            }

            reader.Close();
            schliessen();
            return i;


        }

        // kontinente
        public List <Land> KontinentWahl(string k_id)
        {

            List<Land> lilae = new List<Land> ();

            oeffnen();

            string s = string.Format
                (" select * from laender where k_id = {0} order by rand(); ", k_id);


            MySqlCommand com = con.CreateCommand();
            com.CommandText = s;
            MySqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                lilae.Add(new Land(reader.GetInt32(0), reader.GetString(1),reader.GetString(2),reader.GetInt32(3)));
            }

            reader.Close();
            schliessen();
            return lilae;

        }

      
        
    }
}
