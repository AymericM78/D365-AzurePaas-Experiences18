using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusDataLoader
{
    internal class DataRandomizer
    {
        private static char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcefghijklmnopqrstuvwxyz0123456789".ToCharArray();
        private static Random m_randomInstance = new Random();
        private static object m_randLock = new object();

        /// <summary>
        /// Gets the random string.
        /// </summary>
        /// <param name="minLen">The minimum length.</param>
        /// <param name="maxLen">The maximum length.</param>
        /// <returns></returns>
        public static string GetRandomString(int minLen, int maxLen)
        {
            int alphabetLength = Alphabet.Length;
            int stringLength;
            lock (m_randLock)
            {
                stringLength = m_randomInstance.Next(minLen, maxLen);
            }
            char[] str = new char[stringLength];

            // max length of the randomizer array is 5
            int randomizerLength = stringLength > 5 ? 5 : stringLength;

            int[] rndInts = new int[randomizerLength];
            int[] rndIncrements = new int[randomizerLength];

            // Prepare a "randomizing" array
            for (int i = 0; i < randomizerLength; i++)
            {
                int rnd = m_randomInstance.Next(alphabetLength);
                rndInts[i] = rnd;
                rndIncrements[i] = rnd;
            }

            // Generate "random" string out of the alphabet used
            for (int i = 0; i < stringLength; i++)
            {
                int indexRnd = i % randomizerLength;
                int indexAlphabet = rndInts[indexRnd] % alphabetLength;
                str[i] = Alphabet[indexAlphabet];

                // Each rndInt "cycles" characters from the array, 
                // so we have more or less random string as a result
                rndInts[indexRnd] += rndIncrements[indexRnd];
            }
            return new string(str);
        }

        /// <summary>
        /// Gets the random double.
        /// </summary>
        /// <returns></returns>
        public static double GetRandomDouble()
        {
            return m_randomInstance.NextDouble();
        }

        /// <summary>
        /// Gets the random number.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        public static string GetRandomNumber(int min, int max)
        {
            return m_randomInstance.Next(min, max).ToString();
        }

        /// <summary>
        /// Gets the random int.
        /// </summary>
        /// <returns></returns>
        public static int GetRandomInt()
        {
            return m_randomInstance.Next();
        }

        /// <summary>
        /// Gets the random int.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns></returns>
        public static int GetRandomInt(int min, int max)
        {
            return m_randomInstance.Next(min, max);
        }

        /// <summary>
        /// Gets the random int from value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int GetRandomIntFromValue(int value)
        {
            int min = value > 0 ? value - 1 : 0;
            int max = value + 1;

            return GetRandomInt(min, max);
        }

        /// <summary>
        /// Gets the random phone number.
        /// </summary>
        /// <returns></returns>
        public static string GetRandomPhoneNumber(bool mobile = false)
        {
            string phoneNumber = "0";
            if (mobile)
            {
                phoneNumber += GetRandomNumber(6, 7);
            }
            else
            {
                phoneNumber += GetRandomNumber(1, 5);
            }
            phoneNumber += GetRandomNumber(11, 99);
            phoneNumber += GetRandomNumber(11, 99);
            phoneNumber += GetRandomNumber(11, 99);
            phoneNumber += GetRandomNumber(11, 99);

            return phoneNumber;
        }
    }
}
