using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    class ParsedIdentifierDemonstration : Demonstration
    {
        public override string Description
        {
            get
            {
                return "Parsing Identifiers";
            }
        }

        public override string Explanation
        {
            get
            {
                return Explanations.ParsedIdentifierExplanation;
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
                return 1;
            }
        }

        public override object Run()
        {
            return JS.ParseId("System.UI.Control");
        }
    }
}
