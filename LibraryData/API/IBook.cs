﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryData.API
{
    public interface IBook
    {
        int Id { get; set; }
        string Author { get; set; }
        string Name { get; set; }
    }
}
