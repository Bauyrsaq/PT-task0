using LibraryData.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public User() { }

        public User(int id, string name, string surname)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
        }

        public override string ToString()
        {
            return Id + ": " + Name + " " + Surname;
        }

        public override int GetHashCode()
        {
            int hashId = Id.GetHashCode();
            int hashName = Name.GetHashCode();
            int hashSurname = Surname.GetHashCode();
            return hashId ^ hashName ^ hashSurname;
        }
    }
}
