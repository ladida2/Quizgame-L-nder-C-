using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbeit_Quizgame
{
    public class Land
    {
        private int l_id;
        private string name;
        private string hauptstadt;
        private int kon_id;

        public int L_id { get => l_id; set => l_id = value; }
        public string Name { get => name; set => name = value; }
        public string Hauptstadt { get => hauptstadt; set => hauptstadt = value; }
        public int Kon_id { get => kon_id; set => kon_id = value; }
        public Land() { }
        public Land(int lid , string na, string hau, int kid) 
        {   
            l_id = lid;
            name = na;
            hauptstadt = hau;
            kon_id = kid;
            
        }
    }
}
