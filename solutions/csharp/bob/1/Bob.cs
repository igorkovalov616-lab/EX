public static class Bob
{
    public static string Response(string statement)
    {
        if (statement == null) statement = "";

        string s = statement.Trim();

        // Silence
        if (s.Length == 0)
            return "Fine. Be that way!";

        bool isQuestion = s.EndsWith("?");
        bool hasLetter = false;
        bool hasLower = false;
        bool hasUpper = false;

        foreach (char c in s)
        {
            if (char.IsLetter(c))
            {
                hasLetter = true;
                if (char.IsLower(c)) hasLower = true;
                if (char.IsUpper(c)) hasUpper = true;
            }
        }

        bool isYelling = hasLetter && hasUpper && !hasLower;

        // Yelled question
        if (isQuestion && isYelling)
            return "Calm down, I know what I'm doing!";

        // Yelling
        if (isYelling)
            return "Whoa, chill out!";

        // Question
        if (isQuestion)
            return "Sure.";

        // Anything else
        return "Whatever.";
    }
}






