namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    [Description("Simple Arithmetic")]
    [Group(Group.Basics, 3)]
    class SimpleArithmeticDemonstration : Demonstration
    {
        public override object Run()
        {
            return JS.Id("a").IsGreaterThan(0).Iif(JS.Number(20).AddWith(10), JS.Number(40).RemainderBy(5));
        }
    }
}
