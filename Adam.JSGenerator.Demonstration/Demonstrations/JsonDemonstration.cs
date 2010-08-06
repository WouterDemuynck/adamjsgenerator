using System.Linq;

namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    [Description("JSON")]
    [Group(Group.ObjectLiterals, 4)]
    class JsonDemonstration : Demonstration
    {
        public override object Run()
        {
            var i = from item in Enumerable.Range(1, 10)
                    where item%2 == 0
                    orderby item descending
                    select new {item, name = "Item " + item};

            var obj = JS.Object(new {menu = i});
            return obj.ToString(false, ScriptOptions.Json);
        }
    }
}
