namespace QuizMaster.Shared.Extensions
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoringCase(this string s, string toCompare)
            => string.Equals(s.ToLower(), toCompare.ToLower());
    }
}