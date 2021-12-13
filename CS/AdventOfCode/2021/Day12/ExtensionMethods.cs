namespace Day12
{
    public static class ExtensionMethods
    {
        public static bool IsUpper(this string input)
        {
            foreach (char c in input)
            {
                if (!char.IsUpper(c))
                    return false;

            }

            return true;
        }
    }
}