using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class GildedRoseApp
    {
        public const int MAX_QUALITY = 50;
        public const int SULFURAS_QUALITY = 80;
        public const int BACKSTAGE_DAY_STEP1 = 10;
        public const int BACKSTAGE_DAY_STEP2 = 5;
        public const int BACKSTAGE_DAY_STEP3 = 0;

        public IList<Item> Items;

        public void UpdateQuality()
        {
            var updateFactory = new UpdateLogicFactory();
            IUpdateLogic updater;

            foreach (Item item in Items)
            {
                updater = updateFactory.Create(item);
                updater.Update(item);
            }
        }
    }
}
