namespace Sot.Crossfit.Toolbox.Domain
{
    public record Barbell
    {
        public Barbell(int id, string name, decimal weight)
        {
            Id = id;
            Name = name;
            Weight = weight;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }

        public override string ToString() => $"{Weight}KG";

        public static Barbell Barbell_20kg = new Barbell(1, "Barbell 20kg", 20);
        public static Barbell Barbell_15kg = new Barbell(2, "Barbell 15kg", 15);
        public static Barbell Barbell_10kg = new Barbell(3, "Barbell 10kg", 10);
        public static Barbell[] BarbellsAvailable = new Barbell[]
        {
            Barbell_10kg,
            Barbell_15kg,
            Barbell_20kg
        };
    }
}
