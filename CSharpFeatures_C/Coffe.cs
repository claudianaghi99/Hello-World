namespace CSharpFeatures_C
{
    internal class Coffe
    {
        public string CoffeType { get; set; }
        public Coffe()
        {
        }
        public Coffe(string type)
        {
            CoffeType = type;
        }

        public override string ToString()
        {
            return CoffeType;
        }
    }
}