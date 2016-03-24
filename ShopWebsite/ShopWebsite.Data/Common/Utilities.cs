using System;
namespace ShopWebsite.Data.Common
{
    public static class Utilities
    {
        private static Random rand { get; set; }

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

        public static int GetRandomInt(int min, int max)
        {
            if (min >= max)
            {
                min = 1;
                max = 100;
            }
            return rand.Next(min, max);
        }

        public static decimal GetRandomDecimal(decimal min, decimal max)
        {
            if (min >= max)
            {
                min = 1.0M;
                max = 100.0M;
            }
            return ((decimal)rand.NextDouble()) * (max - min) + min;
        }

        public static string GetRandomIntAsString(int lenght)
        {
            return GetRandomInt((int)Math.Pow(10, lenght), ((int)Math.Pow(10, lenght + 1.0) - 1)).ToString();
        }
    }
}
