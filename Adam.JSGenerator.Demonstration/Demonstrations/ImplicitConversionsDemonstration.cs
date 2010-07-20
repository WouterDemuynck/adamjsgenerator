using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    class ImplicitConversionsDemonstration : Demonstration
    {
        public override string Description
        {
            get
            {
                return "Implicit Conversions";
            }
        }

        public override string Explanation
        {
            get
            {
                return Explanations.ImplicitConversions;
            }
        }

        public override Group Group
        {
            get
            {
                return Group.Basics;
            }
        }

        public override int Order
        {
            get
            {
                return 2;
            }
        }

        public override object Run()
        {
            return string.Empty;
        }
    }
}
