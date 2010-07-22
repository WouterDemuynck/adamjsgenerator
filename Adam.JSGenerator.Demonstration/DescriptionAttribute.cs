using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
