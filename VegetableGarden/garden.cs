using System.Collections.Generic;

namespace VegetableGarden.Models
{
    public class Garden
    {
        public List<Plant> Plants { get; } = new List<Plant>();
        public int Storage { get; private set; }

        public void AddPlant(Plant plant)
        {
            Plants.Add(plant);
        }

        public void WaterAll()
        {
            foreach (var plant in Plants)
                plant.Water();
        }

        public void GrowAll()
        {
            foreach (var plant in Plants)
                plant.Grow();
        }

        public void HarvestReadyPlants()
        {
            for (int i = Plants.Count - 1; i >= 0; i--)
            {
                if (Plants[i].IsReadyToHarvest)
                {
                    Storage += Plants[i].Harvest();
                    Plants.RemoveAt(i);
                }
            }
        }
    }
}
