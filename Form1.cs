using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls.Crypto;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;


namespace Projektarbeit_Quizgame
{
    public partial class Form1 : Form
    {
        private Datenbank db = new Datenbank();
        List<Land> lilae;
        List<RadioButton> lirae = new List<RadioButton>();
        List<Highscore> lihigh;
        Random rd = new Random();
        int spielart = 0;
        int zaehler = 1;
        int punkte = 0;
        const int HAUPTSTADT_VON_LAND = 0;
        const int LAND_VON_HAUPTSTADT = 1;
        const int FLAGGE_VON_LAND = 2;
        const int FLAGGE_VON_HAUPTSTADT = 3;
        const int LAND_VON_FLAGGE = 4;
        const int HAUPTSTADT_VON_FLAGGE = 5;

        private Nutzer nutzer = null;
   
        public Form1()
        {

            InitializeComponent();
            

            // Liste RadioButton füllen
            lirae.Add(radioButton1);
            lirae.Add(radioButton2);
            lirae.Add(radioButton3);
            lirae.Add(radioButton4);
       
      
            groupBox4.Enabled = false;
            groupBox3.Enabled = false;


            Login();
        }
        private void Login()
        {
            Login lg = new Login();
            lg.ShowDialog();
            nutzer = lg.nutzer;
            lbSpielerIDNummer.Text = "" + nutzer.L_id;
            lbSpielername.Text = "" + nutzer.Nutzername;
            HighscoreAnzeigen();
            HighscoreSpielerAnzeigen();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }

        // Vorentscheidung

        private void lbAfrika_Click(object sender, EventArgs e)
        {
            tBKontinentwahl.Text = "1";
            labelklick();
            groupBox4.Enabled = true;
            groupBox3.Enabled = true;
     
        }
        private void lbAsien_Click(object sender, EventArgs e)
        {
            tBKontinentwahl.Text = "2";
            labelklick();
            groupBox4.Enabled = true;
            groupBox3.Enabled = true;
        }
        private void lbAustralien_Click(object sender, EventArgs e)
        {
            tBKontinentwahl.Text = "3";
            labelklick();
            groupBox4.Enabled = true;
            groupBox3.Enabled = true;
        }
        private void lbEuropa_Click(object sender, EventArgs e)
        {
            tBKontinentwahl.Text = "4";
            labelklick();
            groupBox4.Enabled = true;
            groupBox3.Enabled = true;
        }
        private void lbNordamerika_Click(object sender, EventArgs e)
        {
            tBKontinentwahl.Text = "5";
            labelklick();
            groupBox4.Enabled = true;
            groupBox3.Enabled = true;
        }
        private void lbSüdamerika_Click(object sender, EventArgs e)
        {
            tBKontinentwahl.Text = "6";
            labelklick();
            groupBox4.Enabled = true;
            groupBox3.Enabled = true;
        }
        private void label9_Click(object sender, EventArgs e)
        {
            tBKontinentwahl.Text = "";
            labelklick();
            groupBox4.Enabled = true;
            groupBox3.Enabled = true;
        }

        // Spielwahl
        private void rBLH_CheckedChanged_1(object sender, EventArgs e)
        {
            //LHSpiel();
            Frage1();
            spielart = HAUPTSTADT_VON_LAND;
            radioButtonSpielwahlStop();
            SpielAnzeigen();
            
        }
        private void rBHL_CheckedChanged_1(object sender, EventArgs e)
        {
            spielart = LAND_VON_HAUPTSTADT;
            Frage1();
            radioButtonSpielwahlStop();
            SpielAnzeigen();
          

        }
        private void rBLF_CheckedChanged_1(object sender, EventArgs e)
        {
            spielart = FLAGGE_VON_LAND;
            Frage1();
            radioButtonSpielwahlStop();
            SpielAnzeigen();
           

        }
        private void rBHF_CheckedChanged_1(object sender, EventArgs e)
        {
            spielart = FLAGGE_VON_HAUPTSTADT;
            Frage1();
            radioButtonSpielwahlStop();
            SpielAnzeigen();
           

        }
        private void rBFL_CheckedChanged_1(object sender, EventArgs e)
        {
            spielart = LAND_VON_FLAGGE;
            Frage2();
            radioButtonSpielwahlStop();
            SpielAnzeigen();
            

        }
        private void rBFH_CheckedChanged_1(object sender, EventArgs e)
        {
            spielart = HAUPTSTADT_VON_FLAGGE;
            Frage2();
            radioButtonSpielwahlStop();
            SpielAnzeigen();
           
        }

        // Fragen Anzeige
        private void Frage1()
        {
            // Fragen
            lbAntwort.Show();
            pBAntwort.Hide();
        }
        private void Frage2()
        {
            // Fragen
            lbAntwort.Hide();
            pBAntwort.Show();

    }

        // Radio Button Spielauswertung
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (zaehler < 11)
            {
                RadioButton rb = (RadioButton)sender;
                if (rb.Checked)
                {
                  
                    if (rb.Tag == lilae[0]) 
                    {
                        MessageBox.Show("Richtig");
                        punkte++;

                    }
                    else
                        MessageBox.Show("Falsch");


                    zaehler++;
                    lbPunkteZahl.Text = punkte.ToString();
                    lbRundenZahl.Text = zaehler.ToString();
                    reset();
                    SpielAnzeigen();


                }
            } else
            {
                radioButtonAntwortStop();
                Spielstandspeichern();
            }
        }
    
        // Radio Button reseten
        private void reset ()
    {
        radioButton1.Checked = false;
        radioButton2.Checked = false;
        radioButton3.Checked = false;
        radioButton4.Checked = false;


    }

        // Radio Buttons Klick und Unklickbar machen 
        private void radioButtonSpielwahlStop()
            {
                rBLH.Enabled = false;
                rBHL.Enabled = false;
                rBLF.Enabled = false;
                rBHF.Enabled = false;
                rBFL.Enabled = false;
                rBFH.Enabled = false;
            }
        private void radioButtonAntwortStop()
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
            }
    
        // Label unklickbar machen
        private void labelklick() 
    {
        lbAfrika.Enabled = false;
        lbAsien.Enabled = false;
        lbAustralien.Enabled = false;
        lbEuropa.Enabled = false;
        lbNordamerika.Enabled = false;
        lbSüdamerika.Enabled = false;
        lbAlleLänder.Enabled = false;
    }

        // Anzeigen funktion 
        public void SpielAnzeigen()
        {
            if (tBKontinentwahl.Text != "")
            {
                lilae = db.KontinentWahl(tBKontinentwahl.Text);
            }
            else
            {
                lilae = db.getLaender();
            }

            Land[] gemischt = new Land[4];
            for (int i = 0; i < 4; ++i)
            {
                gemischt[i] = lilae[i];
            }
            for (int i = 0; i < 4; ++i) {
                int j = rd.Next(4);
                Land l = gemischt[i];
                gemischt[i] = gemischt[j];
                gemischt[j] = l;
            }
            radioButton1.Tag = gemischt[0];
            radioButton2.Tag = gemischt[1];
            radioButton3.Tag = gemischt[2];
            radioButton4.Tag = gemischt[3];

            switch (spielart)
            {
                case HAUPTSTADT_VON_LAND:

                    // Fragen 
                    lbAntwort.Text = lilae[0].Name;
                    pBAntwort.Image = null;
                    //Antwortmöglichkeiten
                    radioButton1.Text = gemischt[0].Hauptstadt.PadRight(25);
                    radioButton2.Text = gemischt[1].Hauptstadt.PadRight(25);
                    radioButton3.Text = gemischt[2].Hauptstadt.PadRight(25);
                    radioButton4.Text = gemischt[3].Hauptstadt.PadRight(25);
                    radioButton1.Image = null;
                    radioButton2.Image = null;
                    radioButton3.Image = null;
                    radioButton4.Image = null;
                    break;
                case LAND_VON_HAUPTSTADT:

                    // Fragen 
                    lbAntwort.Text = lilae[0].Hauptstadt;
                    pBAntwort.Image = null;
                    //Antwortmöglichkeiten
                    radioButton1.Text = gemischt[0].Name.PadRight(25);
                    radioButton2.Text = gemischt[1].Name.PadRight(25);
                    radioButton3.Text = gemischt[2].Name.PadRight(25);
                    radioButton4.Text = gemischt[3].Name.PadRight(25);
                    radioButton1.Image = null;
                    radioButton2.Image = null;
                    radioButton3.Image = null;
                    radioButton4.Image = null;
                    break;
                case FLAGGE_VON_LAND:

                    // Fragen 
                    lbAntwort.Text = lilae[0].Name;
                    pBAntwort.Image = null;
                    //Antwortmöglichkeiten
                    radioButton1.Text = "";
                    radioButton2.Text = "";
                    radioButton3.Text = "";
                    radioButton4.Text = "";
                    radioButton1.Image = Image.FromFile("Images\\" + gemischt[0].Name + ".jpg");
                    radioButton2.Image = Image.FromFile("Images\\" + gemischt[1].Name + ".jpg");
                    radioButton3.Image = Image.FromFile("Images\\" + gemischt[2].Name + ".jpg");
                    radioButton4.Image = Image.FromFile("Images\\" + gemischt[3].Name + ".jpg");
                    break;
                  case FLAGGE_VON_HAUPTSTADT:

                    // Fragen 
                    lbAntwort.Text = lilae[0].Hauptstadt;
                    pBAntwort.Image = null;
                    //Antwortmöglichkeiten
                    radioButton1.Text = "";
                    radioButton2.Text = "";
                    radioButton3.Text = "";
                    radioButton4.Text = "";
                    radioButton1.Image = Image.FromFile("Images\\" + gemischt[0].Name + ".jpg");
                    radioButton2.Image = Image.FromFile("Images\\" + gemischt[1].Name + ".jpg");
                    radioButton3.Image = Image.FromFile("Images\\" + gemischt[2].Name + ".jpg");
                    radioButton4.Image = Image.FromFile("Images\\" + gemischt[3].Name + ".jpg");
                    break;
                case LAND_VON_FLAGGE:

                    // Fragen 
                    lbAntwort.Text = "";
                    pBAntwort.Image=Image.FromFile("Images\\" + lilae[0].Name + ".jpg");
                    //Antwortmöglichkeiten
                    radioButton1.Text = gemischt[0].Name.PadRight(25);
                    radioButton2.Text = gemischt[1].Name.PadRight(25);
                    radioButton3.Text = gemischt[2].Name.PadRight(25);
                    radioButton4.Text = gemischt[3].Name.PadRight(25);
                    radioButton1.Image = null;
                    radioButton2.Image = null;
                    radioButton3.Image = null;
                    radioButton4.Image = null;
                    break;
                case HAUPTSTADT_VON_FLAGGE:

                    // Fragen 
                    lbAntwort.Text = "";
                    pBAntwort.Image = Image.FromFile("Images\\" + lilae[0].Name + ".jpg");
                    //Antwortmöglichkeiten
                    radioButton1.Text = gemischt[0].Hauptstadt.PadRight(25);
                    radioButton2.Text = gemischt[1].Hauptstadt.PadRight(25);
                    radioButton3.Text = gemischt[2].Hauptstadt.PadRight(25);
                    radioButton4.Text = gemischt[3].Hauptstadt.PadRight(25);
                    radioButton1.Image = null;
                    radioButton2.Image = null;
                    radioButton3.Image = null;
                    radioButton4.Image = null;
                    break;
                

            }

        }
        private void HighscoreAnzeigen()
        {
                dataGridView1.Rows.Clear();
                lihigh = db.getHighscore();
           

            foreach (Highscore hs in lihigh)
            {

            dataGridView1.Rows.Add(hs.B_id ,hs.Score );
  
            }

           
        }
        private void HighscoreSpielerAnzeigen()
        {
            lbHighscore.Text = db.HighscoreSpieler(nutzer.L_id).ToString();
        }

       // Highscore des aktuellen Spielers anzeigen
        private void button1_Click(object sender, EventArgs e)
{

    if (lihigh != null)
    {

        groupBox7.Visible = true;
        dataGridView1.Visible = false;
    }
    else
        MessageBox.Show("Du hast noch keinen Highscore");
}
       // Highscrore aller Spieler anzeigen
        private void button2_Click(object sender, EventArgs e)
{
            HighscoreAnzeigen();

            if (lihigh != null)
            {
            dataGridView1.Visible = true;
            groupBox7.Visible = false;
    }
            else
                MessageBox.Show("Momentan gibt es keine Highscores");

}

        // Highscore Speichern funktionen
        private void Spielstandspeichern()
        {
            Highscore hs = new Highscore();
            hs.B_id = Convert.ToInt32(lbSpielerIDNummer.Text);
            hs.Score = punkte;
            db.saveHighscore(hs);
            HighscoreAnzeigen();
            HighscoreSpielerAnzeigen();
        }

        // Button Neu
        private void btnNeu_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
