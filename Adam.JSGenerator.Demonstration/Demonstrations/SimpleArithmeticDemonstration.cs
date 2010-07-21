using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    class SimpleArithmeticDemonstration : Demonstration
    {
        public override string Description
        {
            get { return "Simple Arithmetic"; }
        }

        public override Group Group
        {
            get { return Group.Basics; }
        }

        public override int Order
        {
            get { return 3; }
        }

        public override object Run()
        {
            return JS.Id("a").IsGreaterThan(JS.Id("b").AddWith(50));
        }
    }
}
