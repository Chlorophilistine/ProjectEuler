using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Forty
{
    public class Forty
    {
        public static void Main()
        {
            var result = ChampernownesConstantCharacters()
                .Take(1000000)
                .Select((champ, index) => new {index, champ})
                .Where(indexedChamp => DesiredIndex(indexedChamp.index))
                .Select(indexedChamp => indexedChamp.champ)
                .Aggregate((accumulate, next) => accumulate * next);

            Console.Out.WriteLine("Euler 40 = {0}", result);
            Console.ReadKey();
        }

        private static bool DesiredIndex(int index)
        {
            var position = index + 1;

            return position == 1 ||
                   position == 10 ||
                   position == 100 ||
                   position == 1000 ||
                   position == 10000 ||
                   position == 100000 ||
                   position == 1000000;
        }


        private static IEnumerable<int> ChampernownesConstantCharacters()
        {
            return
                IncreasingInteger()
                    .SelectMany(integer => integer.ToString(CultureInfo.InvariantCulture))
                    .Select(character => int.Parse(character.ToString(CultureInfo.InvariantCulture)));
        }

        private static IEnumerable<int> IncreasingInteger()
        {
            var index = 1;
            while (true)
            {
                yield return index++;
            }
        }
    }
}
