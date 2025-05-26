namespace ProblemSolving
{
    /// <summary>
    /// Given a string represeting a paragraph, find the first word
    /// that repeats. Return the word itself. If no word is repeated,
    /// return null.
    /// 
    /// - Words are case-insensitive (This = this)
    /// - Punctuation should be ignored (even, = even)
    /// - Consider only alphanumeric characters as part of words
    /// 
    /// Input:
    /// "This is a test for you, students, this is the best"
    /// Output:
    /// "this"
    /// 
    /// Best data structure
    /// </summary>
    public class FindTheFirstRepeatedWordProblem
    {
        public static string? FindFirstRepeatedWord(string? input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;
            var seen = new HashSet<string>();
            var word = new System.Text.StringBuilder();
            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c))
                {
                    word.Append(char.ToLowerInvariant(c));
                }
                else if (word.Length > 0)
                {
                    var w = word.ToString();
                    if (!seen.Add(w)) return w;
                    word.Clear();
                }
            }
            if (word.Length > 0)
            {
                var w = word.ToString();
                if (!seen.Add(w)) return w;
            }
            return null;
        }
    }
}
