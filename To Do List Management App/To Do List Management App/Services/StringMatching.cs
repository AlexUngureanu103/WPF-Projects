using System;

namespace To_Do_List_Management_App.Services
{
    internal static class StringMatching
    {
        public static bool IsMatch(string source, string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                return false;
            }
            if (string.IsNullOrEmpty(source))
            {
                return false;
            }

            source = source.ToLower();
            pattern = pattern.ToLower();

            int matchCount = 0;
            int minLenght = Math.Min(source.Length, pattern.Length);

            for (int i = 0; i < minLenght; i++)
            {
                if (source[i] == pattern[i])
                {
                    matchCount++;
                }
            }

            double matchPercentage = (double)matchCount / minLenght;

            return matchPercentage >= 0.5;
        }
    }
}
