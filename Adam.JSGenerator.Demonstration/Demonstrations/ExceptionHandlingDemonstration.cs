namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    [Description("Exception Handling")]
    [Group(Group.Statements, 3)]
    class ExceptionHandlingDemonstration : Demonstration
    {
        public override object Run()
        {
            var e = JS.Id("e");
            return JS.Try(JS.Throw("Raise Hell!"))
                     .Catch(e, JS.Alert(e))
                     .Finally(JS.Alert("Finally!"));
        }
    }
}
