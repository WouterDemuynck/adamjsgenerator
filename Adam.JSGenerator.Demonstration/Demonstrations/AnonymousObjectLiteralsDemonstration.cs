namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    [Description("Using Anonymous Types")]
    [Group(Group.ObjectLiterals, 2)]
    class AnonymousObjectLiteralsDemonstration : Demonstration
    {
        public override object Run()
        {
            var obj = JS.Object(new {name = "Dave", function = "Developer"});
            return obj.ToString();
        }
    }
}
