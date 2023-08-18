namespace Drone_Opgave_Vis
{
    using System.IO;
    internal class Program
    {
        static void Main(string[] args)
        {
            string theShit = File.ReadAllText("flyvning1.csv");
                Console.WriteLine(theShit);
        }
    }
}