namespace Adam.JSGenerator.Demonstration.Demonstrations
{
    [Description("Other Example 2")]
    [Group(Group.Other, 2)]
    class LargeExample2Demonstration : Demonstration
    {
        public override object Run()
        {
            var images = new[]
            {
                "Images/Image1.jpg", 
                "Images/Image2.jpg", 
                "Images/Image3.jpg"
            };

            var properties = new {images, duration = 3000};

            return JS.Id("$create").Call(
                JS.ParseId("Adam.Controls.SlideShow"), 
                JS.Object(properties), 
                null, 
                null, 
                JS.Get("ClientId"));
        }
    }
}
