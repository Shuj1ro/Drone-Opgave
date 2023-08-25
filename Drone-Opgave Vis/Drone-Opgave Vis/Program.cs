using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace DronerOpgave
{
    internal class Program
    {

        static void Main(string[] args)
        {
            File.Delete("doneText.csv");
            string theText = File.ReadAllText("flyvning1.csv");

            String[] spearator = { ";", "\n" };
            Int32 count = int.MaxValue;

            // Teksten bliver splittet
            String[] strlist = theText.Split(spearator, count,
                   StringSplitOptions.RemoveEmptyEntries);

            // Teksten bliver læst
            for (int i = 0; i < strlist.Length; i++)
            {
                File.AppendAllText("doneText.csv", strlist[i] + "\n");
            }

            // Longittude data læsning
            List<string> longtitudeData = new List<string>();
            for (int i = 17; i < strlist.Length; i++)
            {
                string brokenLongData = strlist[i];
                // Console.WriteLine("long data " + i + ":" + brokenLongData);
                longtitudeData.Add(brokenLongData);
                i = (i + 12);
            }


            // Latitude data læsning 
            List<string> latitudeData = new List<string>();
            for (int i = 18; i < strlist.Length; i++)
            {
                string brokenLatData = strlist[i];
                // Console.WriteLine("lat data " + i + ":" + brokenLatData);
                latitudeData.Add(brokenLatData);
                i = (i + 12);
            }

            // Longtitude data Rettelse
            for (int i = 0; i < longtitudeData.Count; i++)
            {
                longtitudeData[i] = longtitudeData[i].Replace(".", "");
                longtitudeData[i] = longtitudeData[i].Insert(1, ".");
                //Console.WriteLine("Rettede Long Data #" + i + ": " + longtitudeData[i]);
            }

            // Latitude data Rettelse
            for (int i = 0; i < latitudeData.Count; i++)
            {
                latitudeData[i] = latitudeData[i].Replace(".", "");
                latitudeData[i] = latitudeData[i].Insert(2, ".");
                //Console.WriteLine("Rettede Lat Data #" + i + ": " + latitudeData[i]);
            }



            //samle dit data

            List<string> samledeData = new List<string>();
            for (int i = 0; i < samledeData.Count; i++)
            {
                samledeData.Add("(" + longtitudeData[i] + ";" + latitudeData[i] + ")");
                Console.WriteLine(samledeData[i]);
            }
        }
    }
}