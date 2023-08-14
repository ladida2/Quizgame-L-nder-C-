using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbeit_Quizgame
{
    public class Kontinente
    {
        private int kon_id;
        private string name;

        public int Kon_id { get => kon_id; set => kon_id = value; }
        public string Name { get => name; set => name = value; }

        public Kontinente() { }
        public Kontinente(int kid, string na) 
        {
            kon_id = kid;
            name = na;
        }
    }
}
