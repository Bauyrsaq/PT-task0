using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentation.Model
{
    public interface IBorrowingModel
    {
        int Id { get; set; }
        int userId { get; set; }
        int stateId { get; set; }
        DateTime Date { get; set; }
        int? bookQuantity { get; set; }
    }
}
