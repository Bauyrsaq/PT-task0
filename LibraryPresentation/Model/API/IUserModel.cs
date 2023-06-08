using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentation.Model.API
{
    public interface IUserModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
    }
}
