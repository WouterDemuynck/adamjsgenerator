using System.Linq;

namespace Adam.JSGenerator.Demonstration
{
    public abstract class Demonstration
    {
        public virtual string Explanation
        {
            get
            {
                string name = this.GetType().Name;
                string explanation = Explanations.ResourceManager.GetString(name);

                return !string.IsNullOrEmpty(explanation) ? explanation : string.Empty;
            }
        }

        public virtual string Description 
        { 
            get
            {
                DescriptionAttribute attribute = (DescriptionAttribute)this.GetType().GetCustomAttributes(typeof (DescriptionAttribute), false).FirstOrDefault();
                return attribute != null ? attribute.Text : string.Empty;
            }
        }

        public virtual Group Group
        {
            get
            {
                GroupAttribute attribute = (GroupAttribute) this.GetType().GetCustomAttributes(typeof (GroupAttribute), false).FirstOrDefault();
                return attribute != null ? attribute.Group : Group.Basics;
            }
        }

        public virtual int Order
        {
            get
            {
                GroupAttribute attribute = (GroupAttribute)this.GetType().GetCustomAttributes(typeof(GroupAttribute), false).FirstOrDefault();
                return attribute != null ? attribute.Order : 0;                
            }
        }

        public abstract object Run();
    }
}
