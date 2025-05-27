using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using VegetableGarden.Models;

namespace VegetableGarden.ViewModels
{
    public abstract class MainWindowViewModelBase : INotifyPropertyChanged
    {
        public ObservableCollection<PlantViewModel> Plants { get; } = new ObservableCollection<PlantViewModel>();

        public ICommand AddPlantCommand { get; }
        public ICommand WaterAllCommand { get; }
        public ICommand NextDayCommand { get; }
        public ICommand HarvestCommand { get; }

        protected MainWindowViewModelBase()
        {
            AddPlantCommand = new RelayCommand(_ => AddPlant());
            WaterAllCommand = new RelayCommand(_ => WaterAll());
            NextDayCommand = new RelayCommand(_ => NextDay());
            HarvestCommand = new RelayCommand(_ => Harvest());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected abstract void AddPlant();
        protected abstract void WaterAll();
        protected abstract void NextDay();
        protected abstract void Harvest();
    }
}
