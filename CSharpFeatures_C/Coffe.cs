namespace CSharpFeatures_C
{
    internal class Coffe
    {
        
        public Coffe()
        {
        }
        public Coffe(string type)
        {
            CoffeType = type;
        }
        public string CoffeType { get; }


        public override string ToString()
        {
            return CoffeType;
        }
    }
}