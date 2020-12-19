using System;
using System.Linq;

namespace Sot.Crossfit.Toolbox.Domain
{
    public class LoadPercent
    {
        public LoadPercent(int percent)
        {
            Percent = percent;
            BarbellLoading = new BarbellLoading(Barbell.Barbell_20kg, Plate.AvailablePlates);
        }

        public int Percent { get; set; }
        public decimal Value { get; set; }
        public BarbellLoading BarbellLoading { get; set; }

        public void CalculateValue(int repitionMax)
        {
            decimal value = repitionMax * Percent / 100;
            Value = Math.Round(value * 2, MidpointRounding.AwayFromZero) / 2;
            BarbellLoading.CalculateLoading(Value);
        }
    }
}
