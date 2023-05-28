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
            this.username = username; //name это переменная метода которая передает значение в username, this (username) для того чтобы отличать переменные объекта от переменных метода (name)
            score = 0; //нет this так как метода нет переменной с таким же иминем
        }
        public User(string username,int score) //для обновления
        {
            this.username = username;
            this.score = score;
        }
        public void plusScore()
        { score++; }
    }
}
