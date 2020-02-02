using System;
using System.Collections.Generic;
using System.Text;

namespace jointest
{
    
        class Person
        {
            public string Name { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }

       
        /*
         This code produces the following output:

         Hedlund, Magnus - Daisy
         Adams, Terry - Barley
         Adams, Terry - Boots
         Weiss, Charlotte - Whiskers
        */
    }

