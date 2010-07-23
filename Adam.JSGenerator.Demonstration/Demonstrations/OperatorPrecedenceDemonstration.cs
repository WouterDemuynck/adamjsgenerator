using System;

namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    [Description("Operator Precedence")]
    [Group(Group.Basics, 4)]
    class OperatorPrecedenceDemonstration : Demonstration
    {
        public override object Run()
        {
            return JS.Number(10).MultiplyBy(JS.Number(5).AddWith(2));
        }
    }
}
