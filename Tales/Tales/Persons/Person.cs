using System;
using System.Collections.Generic;
using System.Text;

namespace Tales.Persons
{
    public class Person : IPerson
    {
        public int CreationTime { get; set; }
        public string Name { get; set; }
    }
}
