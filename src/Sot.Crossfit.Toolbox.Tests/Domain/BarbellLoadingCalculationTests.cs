using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sot.Crossfit.Toolbox.Domain;
using System.Linq;

namespace Sot.Crossfit.Toolbox.Tests.Domain
{
    [TestClass]
    public class BarbellLoadingCalculationTests
    {
        [TestMethod]
        public void Calculate_WhenBarbell_IsNotEnought_NotAvailable()
        {
            // Arrange
            var loadingValue = 15;
            var sut = new BarbellLoading(Barbell.Barbell_20kg, null);

            // Act 
            sut.CalculateLoading(loadingValue);

            // Assert
            Assert.IsTrue(sut.NotPossibleBarbell);
        }

        [TestMethod]
        public void Calculate_WhenBarbell_IsTheSameWeight_OnlyPlate()
        {
            // Arrange
            var loadingValue = 20;
            var sut = new BarbellLoading(Barbell.Barbell_20kg, Plate.AvailablePlates);

            // Act 
            sut.CalculateLoading(loadingValue);

            // Assert
            Assert.IsFalse(sut.NotPossibleBarbell);
            Assert.AreEqual(0, sut.Plates.Count);
        }

        [TestMethod]
        //       lo  20,15,10,5,2.5,2,1.5,1,0.5   
        [DataRow(25, 0, 0, 0, 0, 1, 0, 0, 0, 0)]
        [DataRow(180, 4, 0, 0, 0, 0, 0, 0, 0, 0)]
        [DataRow(185,4, 0, 0, 0, 1, 0, 0, 0, 0)]
        [DataTestMethod]
        public void Calculate_WhenBarbell_WithWeight_ReturnsExpectedResult(int loadingValue, int kg20count, int kg15count, int kg10count, int kg5count, int kg2_5count, int kg2count, int kg1_5count, int kg1count, int kg0_5count)
        {
            // Arrange;
            var sut = new BarbellLoading(Barbell.Barbell_20kg, Plate.AvailablePlates);

            // Act 
            sut.CalculateLoading(loadingValue);

            // Assert
            Assert.IsFalse(sut.NotPossibleBarbell);
            Assert.AreEqual(kg20count + kg15count + kg10count + kg5count + kg2_5count + kg2count + kg1_5count + kg1count + kg0_5count, sut.Plates.Sum(c => c.Count));
            foreach (var plate in sut.Plates)
            {
                switch (plate.Weight)
                {
                    case 20:
                        Assert.AreEqual(kg20count, plate.Count);
                        break;
                    case 15:
                        Assert.AreEqual(kg15count, plate.Count);
                        break;
                    case 10:
                        Assert.AreEqual(kg10count, plate.Count);
                        break;
                    case 5:
                        Assert.AreEqual(kg5count, plate.Count);
                        break;
                    case 2.5m:
                        Assert.AreEqual(kg2_5count, plate.Count);
                        break;
                    case 2:
                        Assert.AreEqual(kg2count, plate.Count);
                        break;
                    case 1.5m:
                        Assert.AreEqual(kg1_5count, plate.Count);
                        break;
                    case 1:
                        Assert.AreEqual(kg1count, plate.Count);
                        break;
                    case 0.5m:
                        Assert.AreEqual(kg0_5count, plate.Count);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
