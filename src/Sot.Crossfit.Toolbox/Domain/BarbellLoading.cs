using System;
using System.Collections.Generic;
using System.Linq;

namespace Sot.Crossfit.Toolbox.Domain
{
    public class BarbellLoading
    {
        private IEnumerable<Plate> _availablePlates { get; set; }

        public BarbellLoading(Barbell barbell, IEnumerable<Plate> availablePlates)
        {
            Barbell = barbell;
            _availablePlates = availablePlates;
        }

        public Barbell Barbell { get; set; }
        public List<PlateOnBarbell> Plates { get; set; }
        public bool NotPossibleBarbell { get; set; } = true;
        public decimal TotalWeight => Barbell.Weight + Plates.Sum(d => d.Weight * 2);

        public void CalculateLoading(decimal targetLoad)
        {
            if (Barbell.Weight > targetLoad)
            {
                NotPossibleBarbell = true;
                return;
            }
            NotPossibleBarbell = false;
            Plates = new List<PlateOnBarbell>();
            decimal rest = targetLoad - Barbell.Weight;
            Console.WriteLine($"Available Plates : {_availablePlates.Count()}");
            foreach (var plate in _availablePlates.OrderByDescending(c => c.Weight))
            {
                Console.WriteLine($"Plate : {plate.Weight}");
                var plateWeightOnBothSide = plate.Weight * 2;
                var plateRest = rest;
                int plateCount = 0;
                while (plateRest >= plateWeightOnBothSide && plateRest != 0)
                {
                    plateRest -= plateWeightOnBothSide;
                    plateCount++;
                    Console.WriteLine($"Plate : {plate.Weight} - {plateCount}");
                }
                if (plateCount > 0)
                {
                    Plates.Add(new PlateOnBarbell(plate, plateCount));
                    rest -= plateCount * plateWeightOnBothSide;
                }
            }
        }
    }
}
