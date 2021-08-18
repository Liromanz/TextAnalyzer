using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    class TripletFinder
    {
        private static readonly List<string> _fulltext = new List<string>();

        public static void SeparateText(string fileText)
        {
            for (var i = 0; i < fileText.Length - 3; i++)
                if (fileText[i] != ' ' && fileText[i + 1] != ' ' && fileText[i + 2] != ' ')
                    _fulltext.Add($"{fileText[i]}{fileText[i + 1]}{fileText[i + 2]}");

            Parallel.For(0, 10, Find);
        }
        public static void Find(int x)
        {
            var tripletElement = _fulltext.GroupBy(textTriplet => textTriplet)
                .Select(grouping => new { grouping, count = grouping.Count() })
                .OrderByDescending(t => t.count)
                .Select(t => new { Value = t.grouping.Key, Count = t.count }).ElementAt(x);

            Console.WriteLine($"{tripletElement.Value} - {tripletElement.Count}");
        }
    }
}
