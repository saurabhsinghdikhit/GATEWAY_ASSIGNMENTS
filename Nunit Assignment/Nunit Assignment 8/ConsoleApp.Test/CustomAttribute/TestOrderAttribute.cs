using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Test.CustomAttribute
{
    class TestOrderAttribute : Attribute
    {
        public int Sequence { get; set; }


        public TestOrderAttribute(int sequence)
        {
            this.Sequence = sequence;
        }
    }
}
