using System;

namespace Adam.JSGenerator.Demonstration
{
    public class GroupAttribute : Attribute
    {
        public Group Group { get; set; }
        public int Order { get; set; }

        public GroupAttribute(Group value, int order)
        {
            this.Group = value;
            this.Order = order;
        }
    }
}