using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    [Description("Basics")]
    [Group(Group.Statements, 0)]
    class StatementsBasicsDemonstration : Demonstration
    {
        public override object Run()
        {
            var a = JS.Id("a");
            return JS.For(JS.Var(a.AssignWith(10)), a.IsGreaterThan(0), a.PostDecrement())
                .Do(JS.Alert(a));
        }
    }
}
