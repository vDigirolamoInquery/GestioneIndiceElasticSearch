
namespace FullTextElasticSearch.Utils.Classes
{
    public static class Parser
    {
        public static string[] RemoveChar(string[] strings)
        {
            var clearStrings = new string[strings.Length];
            var index = 0;

            foreach (var phrase in strings)
            {
                clearStrings[index] = phrase.Replace(",","").Replace(".", "").Replace("(", "").Replace(")", "").Replace("[", "").Replace("]", "")
                                            .Replace("{", "").Replace("}", "").Replace(":", "").Replace(";", "");
                index++;
            }
            return clearStrings;
        }
    }
}
