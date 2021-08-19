using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFeatures_C
{

    [Serializable]
    public class RecipeUnavailbleException : Exception
    {
        public RecipeUnavailbleException() { }
        public RecipeUnavailbleException(string message) : base(message) { }
        public RecipeUnavailbleException(string message, Exception inner) : base(message, inner) { }
        protected RecipeUnavailbleException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
