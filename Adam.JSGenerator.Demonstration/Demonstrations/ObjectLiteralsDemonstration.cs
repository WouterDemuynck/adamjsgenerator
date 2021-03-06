﻿using System.Collections.Generic;

namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    [Description("Simple Object Literals")]
    [Group(Group.ObjectLiterals, 0)]
    class ObjectLiteralsDemonstration : Demonstration
    {
        public override object Run()
        {
            var dictionary = new Dictionary<Expression, Expression>();
            dictionary["name"] = "Dave";
            dictionary["function"] = "Developer";
            return new ObjectLiteralExpression(dictionary);
        }
    }
}
