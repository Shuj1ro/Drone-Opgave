using System;
using System.Linq;
using System.IO;
namespace Drone_Opgave_Vis
{
    
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
                File.AppendAllText("Sorted.csv", s + "/n");
            }

           
            string[] lines = new string[s.Length];
            for (int i = 0; i <lines.Length; i++)
            {

                lines[i] = s;

            }



        }
    }
}