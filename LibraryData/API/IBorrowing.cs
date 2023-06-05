using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.API
{
    public interface IBorrowing
    {
        int Id { get; set; }
        int userId { get; set; }
        int stateId { get; set; }
        DateTime Date { get; set; }
        public int? bookQuantity { get; set; }
    }
}
