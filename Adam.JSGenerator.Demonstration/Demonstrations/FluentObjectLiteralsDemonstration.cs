namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    [Description("Fluent Object Literals")]
    [Group(Group.ObjectLiterals, 1)]
    class FluentObjectLiteralsDemonstration : Demonstration
    {
        public override object Run()
        {
            var obj = JS.Object()
                .WithProperty("name", "Dave")
                .WithProperty("function", "Developer");

            return obj.ToString();
        }
    }
}
