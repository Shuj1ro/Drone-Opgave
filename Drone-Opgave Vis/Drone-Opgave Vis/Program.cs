namespace Drone_Opgave_Vis
{
    using System.IO;
    internal class Program
    {
        static void Main(string[] args)
        {
            string theShit = File.ReadAllText("flyvning1.csv");

            String[] spearator = {";"};
            Int32 count = int.MaxValue;

            // using the method
            String[] strlist = theShit.Split(spearator, count,
                   StringSplitOptions.RemoveEmptyEntries);

            foreach (String s in strlist)
            {
                Console.WriteLine(s);
            }

           

        }
    }
}