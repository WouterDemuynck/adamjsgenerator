using System;

namespace Adam.JSGenerator.Demonstration
{
    public class DescriptionAttribute : Attribute
    {
        public string Text { get; set; }

        public DescriptionAttribute(string value)
        {
            this.Text = value;
        }
    }
}
