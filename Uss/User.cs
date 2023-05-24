using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uss
{
    internal class User
    {
        public string username { get; set; }
        public int score { get; set; }
        public User(string username) 
        {
            this.username = username;
            score = 0;
        }
        public User(string username,int score)
        {
            this.username = username;
            this.score = score;
        }
        public void plusScore()
        { score++; }
    }
}
