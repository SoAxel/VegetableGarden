﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using VegetableGarden.Models;

namespace VegetableGarden.ViewModels
{
    public class MainWindowViewModel : MainWindowViewModelBase
    {
        private readonly Garden garden = new Garden();

        public List<string> PlantTypes { get; } = new List<string> { "помідор", "морква", "картопля" };

        private string selectedPlantType = "помідор";
        public string SelectedPlantType
        {
            get => selectedPlantType;
            set
            {
                selectedPlantType = value;
                OnPropertyChanged(nameof(SelectedPlantType));
            }
        }

        protected override void AddPlant()
        {
            Plant plant = null;
            switch (selectedPlantType)
            {
                case "помідор":
                    plant = new Tomato();
                    break;
                case "морква":
                    plant = new Carrot();
                    break;
                case "картопля":
                    plant = new Potato();
                    break;
            }

            if (plant != null)
            {
                garden.AddPlant(plant);
                Plants.Add(new PlantViewModel(plant));
            }
        }

        protected override void WaterAll()
        {
            garden.WaterAll();
            RefreshPlants();
        }

        protected override void NextDay()
        {
            garden.GrowAll();
            RefreshPlants();
        }

        protected override void Harvest()
        {
            garden.HarvestReadyPlants();
            RefreshPlants();
        }

        private void RefreshPlants()
        {
            for (int i = Plants.Count - 1; i >= 0; i--)
            {
                if (!garden.Plants.Contains(Plants[i].Plant))
                {
                    Plants.RemoveAt(i);
                }
                else
                {
                    Plants[i].NotifyChanges();
                }
            }
        }
    }
}
