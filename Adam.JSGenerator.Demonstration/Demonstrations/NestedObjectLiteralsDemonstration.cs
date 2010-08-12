namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    [Description("Nested Types")]
    [Group(Group.ObjectLiterals, 3)]
    class NestedObjectLiteralsDemonstration : Demonstration
    {
        public override object Run()
        {
            var obj = JS.Object(new
            {
                make = "Bow before me, for I am root",
                type = "tshirt",
                sizes = new [] { "S", "M", "L", "XL", "XXL" }
            });

            return obj;
        }
    }
}
