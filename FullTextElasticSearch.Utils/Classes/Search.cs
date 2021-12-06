
namespace FullTextElasticSearch.Utils.Classes
{
    public static class Search
    {
        public enum Types
        {
            Match,
            Fuzzy,
            And,
            Or,
            Phrase
        }

        public static Types DefaultSearchMode()
        {
            return Types.Or;
        }
    }
}
