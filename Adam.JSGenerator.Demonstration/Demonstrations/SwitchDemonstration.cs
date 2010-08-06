namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    [Description("Switch Statement")]
    [Group(Group.Statements, 2)]
    class SwitchDemonstration : Demonstration
    {
        public override object Run()
        {
            return JS.Switch(JS.Id("event"))
                .Case("click")
                .Case("contextmenu").Do(
                    JS.Alert("clicked!"),
                    JS.Break())
                .Case("enter").Do(
                    JS.Alert("entered"),
                    JS.Break())
                .Case("leave").Do(
                    JS.Alert("leave"),
                    JS.Break());
        }
    }
}
