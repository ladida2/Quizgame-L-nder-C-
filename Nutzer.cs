using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbeit_Quizgame
{
    public class Nutzer
    {
        private int l_id;
        private string nutzername;
        private string passwort;

        public string Nutzername { get => nutzername; set => nutzername = value; }
        public string Passwort { get => passwort; set => passwort = value; }
        public int L_id { get => l_id; set => l_id = value; }

        public Nutzer() { }
        public Nutzer(int lid, string nuna, string pw) 
        {
            l_id = lid;
            nutzername = nuna;
            passwort = pw;
        }

    }
}
