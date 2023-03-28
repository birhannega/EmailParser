namespace EmailParser
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
            EmailParser.ParseEmail();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
