namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    [Description("Simple Identifiers")]
    [Group(Group.Basics, 0)]
    class SimpleIdentifierDemonstration : Demonstration
    {
        public override object Run()
        {
            return JS.Id("identifier");
        }
    }
}
