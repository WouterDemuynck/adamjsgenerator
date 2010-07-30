using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    [Description("Adding a block")]
    [Group(Group.Statements, 1)]
    class AddingBlockDemonstration : Demonstration
    {
        public override object Run()
        {
            var a = JS.Id("a");
            return JS.For(null, a.IsGreaterThan(0), a.PostDecrement()).Do(
                JS.Alert(a),
                JS.If(a.IsEqualTo(5)).Then(
                    JS.Break()));
        }
    }
}
