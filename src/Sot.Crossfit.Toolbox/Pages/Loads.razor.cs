using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Sot.Crossfit.Toolbox.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sot.Crossfit.Toolbox.Pages
{
    public partial class Loads : ComponentBase
    {
        private const int minimumPercent = 50;
        private const int maximumPercent = 115;
        private const int stepPercent = 5;
        private int _barbellSelected = 1;

        private IList<LoadPercent> LoadPercents { get; set; }

        public Loads()
        {
            LoadPercents = new List<LoadPercent>();
            for (int i = minimumPercent; i <= maximumPercent; i += stepPercent)
                LoadPercents.Add(new LoadPercent(i));
        }

        [Inject]
        public IModalService Modal { get; set; }

        [Parameter]
        public int? LoadParameterValue { get; set; }

        public int BarbellSelected
        {
            get => _barbellSelected;
            set
            {
                _barbellSelected = value;
                RefreshBarbell();
            }
        }

        public void ShowVisual(decimal weight, decimal barbellWeight)
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(Components.Barbell.Weight), weight);
            parameters.Add(nameof(Components.Barbell.BarbellWeight), barbellWeight);

            if (Modal != null)
            {
                Modal.Show<Components.Barbell>($"Visual load for {weight}KG on barbell {barbellWeight}KG", parameters);
            }
        }

        private int LoadValue
        {
            get => LoadParameterValue.Value;
            set
            {
                LoadParameterValue = value;
                SetNewPercentLoadValues(value);
            }
        }

        private void RefreshBarbell()
        {
            var barbell = Barbell.BarbellsAvailable.FirstOrDefault(c => c.Id == _barbellSelected);
            if (barbell != null)
                foreach (var item in LoadPercents)
                {
                    item.BarbellLoading.Barbell = barbell;
                    item.CalculateValue(LoadValue);
                }

        }

        private void SetNewPercentLoadValues(int repitionMax)
        {
            foreach (var item in LoadPercents)
                item.CalculateValue(repitionMax);
        }

        protected override void OnParametersSet()
        {
            LoadValue = LoadParameterValue ?? 50;
        }
    }
}
