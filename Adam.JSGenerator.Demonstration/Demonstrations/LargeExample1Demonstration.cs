using Adam.JSGenerator.JQuery;

namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    [Description("Other Example 1")]
    [Group(Group.Other, 0)]
    class LargeExample1Demonstration : Demonstration
    {
        public override object Run()
        {
            var chipsets = new[]
            {
                new {chipset = "X58", codename = "Tylersburg", socket = "LGA1366", fdi = false},
                new {chipset = "P55", codename = "Ibex Peak", socket = "LGA1156", fdi = false},
                new {chipset = "H55", codename = "Ibex Peak", socket = "LGA1156", fdi = true},
                new {chipset = "H57", codename = "Ibex Peak", socket = "LGA1156", fdi = true}
            };

            var result = JS.JQuery(JS.Function().Do(
                JS.JQuery("#target").Data("chipsets", Expression.FromObject(chipsets))
                ));

            return result;
        }
    }
}
