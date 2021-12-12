namespace Day03
{
    public static class ExtensionMethods
    {
        public static int ConvertStrBinToDec(this string n)
        {
            int dec = 0, rem;
            int len = n.Length;

            for (int i = 0; i < len; ++i)
            {
                if (n[i] == '1')
                {
                    dec += 1 << (len - (i + 1));
                }
            }

            return dec;
        }
    }
}