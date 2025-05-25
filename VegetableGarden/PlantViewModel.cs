using System.ComponentModel;
using VegetableGarden.Models;

namespace VegetableGarden.ViewModels
{
    public class PlantViewModel : INotifyPropertyChanged
    {
        public Plant Plant { get; }

        public string Name => Plant.Name;

        public string Status => Plant.IsReadyToHarvest
            ? "Готово до збору"
            : $"Росте: {Plant.GrowthDays}/{Plant.MaxGrowthDays}";

        public double GrowthProgress => (double)Plant.GrowthDays / Plant.MaxGrowthDays;

        public event PropertyChangedEventHandler PropertyChanged;

        public PlantViewModel(Plant plant)
        {
            Plant = plant;
        }

        public void NotifyChanges()
        {
            OnPropertyChanged(nameof(Status));
            OnPropertyChanged(nameof(GrowthProgress));
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
