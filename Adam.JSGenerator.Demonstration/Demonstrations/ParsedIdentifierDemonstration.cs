namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    [Description("Parsing Identifiers")]
    [Group(Group.Basics, 1)]
    class ParsedIdentifierDemonstration : Demonstration
    {
        public override object Run()
        {
            return JS.ParseId("System.UI.Control");
        }
    }
}
