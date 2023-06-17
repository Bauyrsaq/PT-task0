﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentation
{
    public interface IErrorInformer
    {
        void InformError(string message);

        void InformSuccess(string message);

        string GetRecentMessage();
    }
}
