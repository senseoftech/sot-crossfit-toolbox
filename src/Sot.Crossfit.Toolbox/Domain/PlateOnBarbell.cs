namespace Sot.Crossfit.Toolbox.Domain
{
    public record PlateOnBarbell : Plate
    {
        public PlateOnBarbell(Plate plate, int count)
        {
            this.Color = plate.Color;
            this.Name = plate.Name;
            this.Weight = plate.Weight;
            this.CssClass = plate.CssClass;
            Count = count;
        }

        public override string ToString() => $"{Weight}KG";

        public int Count { get; set; }

    }
}
