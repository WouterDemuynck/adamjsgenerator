namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    [Description("Simple Arithmetic")]
    [Group(Group.Basics, 3)]
    class SimpleArithmeticDemonstration : Demonstration
    {
        public override object Run()
        {
            return JS.Id("a").IsGreaterThan(0).Iif(20.AddWith(10), 40.RemainderBy(5));
        }
    }
}
