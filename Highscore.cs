using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbeit_Quizgame
{
    public class Highscore
    {
        private int h_id;
        private int score;
        private int b_id;

        public int H_id { get => h_id; set => h_id = value; }
        public int Score { get => score; set => score = value; }
        public int B_id { get => b_id; set => b_id = value; }

        public Highscore() { }
        public Highscore(int hid, int sc, int bid) 
        {
            h_id = hid;
            score = sc;
            b_id = bid;
        }

    }
}
