using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Account.Controllers
{
    class TestClass
    
    {
        public string Id { get; set; }

        public int A { get; set; }
        public int B { get; set; }

        public override string ToString()
        {
            return "A: " + A + ", B: " + B;
        }
    }
}
