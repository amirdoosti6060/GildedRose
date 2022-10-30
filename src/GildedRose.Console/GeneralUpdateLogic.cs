namespace GildedRose.Console
{
    internal class GeneralUpdateLogic : IUpdateLogic
    {
        public void Update(Item item)
        {
            item.Quality = Helper.DecreaseQuality(item.Quality, 1);

            item.SellIn -= 1;

            if (item.SellIn < 0)
                item.Quality = Helper.DecreaseQuality(item.Quality, 1);
        }
    }
}
