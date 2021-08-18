using System.IO;
using System.Text.RegularExpressions;

namespace TextAnalyzer
{
    class FileToString
    {
        public static void ReadFile(string path)
        {
            var regex = new Regex("[^a-zA-Zа-яА-Я ]");
            TripletFinder.SeparateText(regex.Replace(File.ReadAllText(path), "").ToLower());
        }
    }
}
