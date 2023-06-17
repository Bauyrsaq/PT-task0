using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentation.Model
{
    public interface IStateModel
    {
        int Id { get; set; }
        int bookId { get; set; }
        int bookQuantity { get; set; }
    }
}
