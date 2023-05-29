using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uss
{
    internal class Store
    {
        Dictionary<string, User> newusers = new Dictionary<string, User>();

        string filePath = @"..\..\..\Users.txt";
        public void AddUser(User user)
        {
            if (newusers.ContainsKey(user.username))
            {
                newusers[user.username] = user;
            }
            else
            {
                newusers.Add(user.username, user);
            }
            
        }
        public void save()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                StreamWriter login = new StreamWriter(filePath, true);
                foreach (KeyValuePair<string, User> keyValue in newusers)
                {
                    string user = $"{keyValue.Key} {keyValue.Value.score}";
                    login.WriteLine(user);
                }
                login.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Viga failiga " + ex.Message);
            }

        }
        public void read()
        {
            try
            {
                StreamReader logins = new StreamReader(filePath, true);
                string line;
                while ((line = logins.ReadLine()) != null)
                {
                    string[] parts = line.Split(' ');

                    string username = parts[0];
                    int score = int.Parse(parts[1]); // Преобразование счета из string в int

                    Console.WriteLine(line);
                    AddUser(new User(username, score));
                }
                logins.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Viga failiga " + ex.Message);
            }
        }
    }
    
}
