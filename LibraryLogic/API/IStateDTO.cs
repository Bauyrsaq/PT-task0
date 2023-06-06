using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic.API
{
    public interface IStateDTO
    {
        int Id { get; set; }
        int bookId { get; set; }
        int bookQuantity { get; set; }
    }
}
