using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Adam.JSGenerator.Demonstration
{
    public abstract class Demonstration
    {
        public abstract string Description { get; }
        public abstract string Explanation { get; }
        public abstract Group Group { get; }
        public abstract int Order { get; }
        public abstract object Run();
    }
}
