using System;

namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    [Description("Operator Precedence")]
    [Group(Group.Basics, 4)]
    class OperatorPrecedenceDemonstration : Demonstration
    {
        public override object Run()
        {
            return 10.MultiplyBy(5.AddWith(2));
        }
    }
}
