﻿using LibraryLogic.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryPresentationTest.Mock
{
    internal class BookDTOMock : IBookDTO
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }

        public BookDTOMock(int id, string author, string name)
        {
            this.Id = id;
            this.Author = author;
            this.Name = name;
        }
    }
}
