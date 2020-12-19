using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using Sot.Crossfit.Toolbox.Domain;

namespace Sot.Crossfit.Toolbox.Components
{
    public partial class Barbell : ComponentBase
    {

        [CascadingParameter]
        BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter]
        public decimal Weight { get; set; }
        [Parameter]
        public decimal BarbellWeight { get; set; }

        private BarbellLoading BarbellLoading { get; set; }

        protected override void OnInitialized()
        {
            var barbell = Domain.Barbell.Barbell_20kg;
            switch (BarbellWeight)
            {
                case 20:
                    barbell = Domain.Barbell.Barbell_20kg;
                    break;
                case 15:
                    barbell = Domain.Barbell.Barbell_15kg;
                    break;
                case 10:
                    barbell = Domain.Barbell.Barbell_10kg;
                    break;
                default:
                    break;
            }
            BarbellLoading = new BarbellLoading(barbell, Plate.AvailablePlates);
            BarbellLoading.CalculateLoading(Weight);
        }
    }
}