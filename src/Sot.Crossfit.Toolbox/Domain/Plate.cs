using System.Collections.Generic;

namespace Sot.Crossfit.Toolbox.Domain
{
    public record Plate
    {
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public string Color { get; set; }
        public string CssClass { get; set; }

        public static Plate Plate20Kg = new Plate { Name = "20kg", Color = "Black", Weight = 20, CssClass = "extra-extra-large" };
        public static Plate Plate15Kg = new Plate { Name = "15kg", Color = "Black", Weight = 15, CssClass = "extra-large" };
        public static Plate Plate10Kg = new Plate { Name = "10kg", Color = "Black", Weight = 10, CssClass = "large" };
        public static Plate Plate5Kg = new Plate { Name = "5kg", Color = "Black", Weight = 5 };
        public static Plate Plate2_5Kg = new Plate { Name = "2.5kg", Color = "Red", Weight = 2.5m, CssClass = "small" };
        public static Plate Plate2Kg = new Plate { Name = "2kg", Color = "Blue", Weight = 2, CssClass = "extra-small" };
        public static Plate Plate1_5Kg = new Plate { Name = "1.5kg", Color = "Yellow", Weight = 1.5m, CssClass = "extra-extra-small" };
        public static Plate Plate1Kg = new Plate { Name = "1kg", Color = "Green", Weight = 1, CssClass = "extra-extra-extra-small" };
        public static Plate Plate0_5Kg = new Plate { Name = "0.5kg", Color = "White", Weight = 0.5m, CssClass = "extra-extra-extra-extra-small" };

        public static IEnumerable<Plate> AvailablePlates = new Plate[]
        {
            Plate20Kg,
            Plate15Kg,
            Plate10Kg,
            Plate5Kg ,
            Plate2_5Kg,
            Plate2Kg,
            Plate1_5Kg,
            Plate1Kg,
            Plate0_5Kg
        };
    }
}
