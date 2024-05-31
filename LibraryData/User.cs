using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        
        public User(int id, string name, string surname)
        {
            UserID = id;
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return UserID + ": " + Name + " " + Surname;
        }

        public override int GetHashCode()
        {
            int hashId = UserID.GetHashCode();
            int hashName = Name.GetHashCode();
            int hashSurname = Surname.GetHashCode();
            return hashId ^ hashName ^ hashSurname;
        }
    }
}
