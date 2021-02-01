using System;
using System.Collections.Generic;
using System.Linq;

namespace Helpers
{
    public static class RandomDataGenerator
    {
        private static Random random = new Random();

        public static string RandomStringOnlyLetters(int numberOfLetters)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, numberOfLetters).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomAlphaNumericString(int numberOfLetters)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, numberOfLetters).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomEmailAddress()
        {
            string domainChars = "abcdefghijklmnopqrstuvwxyz";
            string emailChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789._";

            string emailLocalPart = new string(Enumerable.Repeat(emailChars, random.Next(8, 13)).Select(s => s[random.Next(s.Length)]).ToArray());
            string emailDomain = new string(Enumerable.Repeat(domainChars, random.Next(4, 7)).Select(s => s[random.Next(s.Length)]).ToArray());

            return $"{emailLocalPart}@{emailDomain}";
        }

        public static int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        public static T RandomListItem<T>(this List<T> list) where T : class
        {
            if(list.Count == 1)
            {
                return list.First();
            }
            else
            {
                return list.ElementAt(RandomNumber(0, list.Count));
            }
        }
    }
}
