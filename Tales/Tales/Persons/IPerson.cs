using System;
using System.Collections.Generic;
using System.Text;

namespace Tales.Persons
{
    interface IPerson
    {
        int CreationTime { get; set; }
        string Name { get; set; }
    }

}
