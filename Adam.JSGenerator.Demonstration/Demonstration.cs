using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adam.JSGenerator.Demonstration
{
    public abstract class Demonstration
    {
        public virtual string Explanation
        {
            get
            {
                string name = this.GetType().Name.Replace("Demonstration", "Explanation");
                string explanation = Explanations.ResourceManager.GetString(name);

                return !string.IsNullOrEmpty(explanation) ? explanation : string.Empty;
            }
        }

        public abstract string Description { get; }
        public abstract Group Group { get; }
        public abstract int Order { get; }
        public abstract object Run();
    }
}
