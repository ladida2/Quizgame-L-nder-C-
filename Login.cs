using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Projektarbeit_Quizgame
{
    public partial class Login : Form
    {
        private Datenbank db = new Datenbank();

        public Nutzer nutzer = null;

        
        public Login()
        {
           
            InitializeComponent();
        }

        // Nach Registrierung Textfelder lehren
        private void clearRegister()
        {
            tBRegBen.Text = "";
            tBRegPW.Text = "";
        }
        // Benutzer einloggen und überprüfen ob schon Passwor und Name korrekt
        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (tBLoginBen.Text != "" && tBLoginPW.Text != "")
            {
                nutzer = db.checkNutzer(tBLoginBen.Text, tBLoginPW.Text);
                if (nutzer==null)
                {
                    MessageBox.Show("Benutzername oder Passwort falsch", "Fehler!");
                }
                else
                {
                    MessageBox.Show("Wilkommen " + tBLoginBen.Text + " im Quizgame");

                    this.Close(); 
                }
            }
            else
            {
                MessageBox.Show("Bitte Bentuzername und Passwort eingeben !");
            }
           
        }
        // Benutzer Registrierung und überprüfung ob Nutzer schon vorhanden
        private void btnRegis_Click(object sender, EventArgs e)
        {
            Nutzer l = new Nutzer();

            l.L_id = -1;
            Nutzer schonVorhanden = db.checkNutzer(tBRegBen.Text, tBRegPW.Text);
            if (schonVorhanden!=null)
            {
                MessageBox.Show("Benutzer existiert bereits !");
            }
            else
              if (tBRegBen.Text == "" || tBRegPW.Text == "")
            {

                MessageBox.Show("Bitte Benutzername oder Passwort eingeben");

            }
            else
            {
                l.Nutzername = tBRegBen.Text;
                l.Passwort = tBRegPW.Text;
                MessageBox.Show("Registriert !");
                db.saveLogin(l);
                clearRegister();
            }

            
        }
    }
}
