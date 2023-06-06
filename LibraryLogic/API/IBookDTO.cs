using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic.API
{
    public interface IBookDTO
    {
        int Id { get; set; }
        string Author { get; set; }
        string Name { get; set; }
    }
}
