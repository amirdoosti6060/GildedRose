namespace GildedRose.Console
{
    public static class Helper
    {
        public static int DecreaseQuality(int quality, int decreas_by)
        {
            quality -= decreas_by;

            if (quality < 0)
                quality = 0;

            return quality;
        }

        public static int IncreaseQuality(int quality, int increas_by)
        {
            quality += increas_by;

            if (quality > GildedRoseApp.MAX_QUALITY)
                quality = GildedRoseApp.MAX_QUALITY;

            return quality;
        }
    }
}
