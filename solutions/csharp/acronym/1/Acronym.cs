public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        phrase = phrase.Replace('-', ' ');

        string result = "";
        bool newWord = true;

        foreach (char c in phrase)
        {
            if (char.IsLetter(c))
            {
                if (newWord)
                {
                    result += char.ToUpper(c);
                    newWord = false;
                }
            }
            else if (c == '\'')
            {
                continue;
            }
            else
            {
                newWord = true;
            }
        }

        return result;
    }
}