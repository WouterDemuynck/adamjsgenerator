using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    [Description("Using Anonymous Types")]
    [Group(Group.ObjectLiterals, 2)]
    class AnonymousObjectLiterals : Demonstration
    {
        public override object Run()
        {
            var obj = JS.Object(new {name = "Dave", function = "Developer"});
            return obj.ToString();
        }
    }
}
