using System;

namespace VegetableGarden.Models
{
    public abstract class Plant
    {
        public int GrowthDays { get; protected set; }
        public int MaxGrowthDays { get; }
        public bool WasWateredToday { get; private set; }

        public bool IsReadyToHarvest => GrowthDays >= MaxGrowthDays;

        protected Plant(int maxGrowthDays)
        {
            MaxGrowthDays = maxGrowthDays;
            GrowthDays = 0;
        }

        public void Water()
        {
            WasWateredToday = true;
        }

        public virtual void Grow()
        {
            if (WasWateredToday && GrowthDays < MaxGrowthDays)
            {
                GrowthDays++;
                WasWateredToday = false;
            }
        }

        public int Harvest()
        {
            return IsReadyToHarvest ? 1 : 0;
        }

        public abstract string Name { get; }
    }
}
