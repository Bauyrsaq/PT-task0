using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData
{
    public class Borrowing
    {
        public User User { get; set; }
        public DateTime Date { get; set; }
        public State State { get; set; }

        public Borrowing(User user, DateTime date, State state)
        {
            this.User = user;
            this.Date = date;
            this.State = state;
        }

        public override string ToString()
        {
            return User.ToString() + " Date: " + Date.ToString() + " State: " + State.ToString();
        }

        public override int GetHashCode()
        {
            int hashUser = User.GetHashCode();
            int hashDate = Date.GetHashCode();
            int hashState = State.GetHashCode();
            return hashUser ^ hashDate ^ hashState;
        }
    }
}
