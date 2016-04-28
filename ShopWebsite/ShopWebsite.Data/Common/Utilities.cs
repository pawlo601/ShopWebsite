using System;
namespace ShopWebsite.Data.Common
{
    public static class Utilities
    {
        private static Random Rand { get; }

        static Utilities()
        {
            Rand = new Random();
        }

        public static int CalculateTotalPages(long numberOfRecords, int pageSize)
        {
            long result;
            int totalPages;
            Math.DivRem(numberOfRecords, pageSize, out result);
            if (result > 0)
            {
                totalPages = (int)((numberOfRecords / pageSize)) + 1;
            }
            else
            {
                totalPages = (int)(numberOfRecords / pageSize);
            }
            return totalPages;
        }
    }
}
