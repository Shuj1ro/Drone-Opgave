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
            File.Delete("shadowFlyvning1");
            string theText = File.ReadAllText("flyvning1.csv");

            String[] spearator = { ";", "\n" };
            Int32 count = int.MaxValue;

            // Teksten bliver splittet
            String[] strlist = theText.Split(spearator, count,
                   StringSplitOptions.RemoveEmptyEntries);

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
            for (int i = 0; i < longtitudeData.Count; i++)
            {
                //VIGTIGT FIX HER MAYBE 
                string samlet = ";(" + longtitudeData[i] + ";" + latitudeData[i] + ")";

                samledeData.Add(samlet);
                //Console.WriteLine(samledeData[i]);
            }

            String[] seperator2 = {"\r" };
            String[] strlist2 = theText.Split(seperator2, count,
                StringSplitOptions.RemoveEmptyEntries);

            strlist2[0] += ";GPSKoord";

            for(int i = 2; i < longtitudeData.Count; i++)
            {
                int j = 0;
                strlist2[i] += samledeData[j];
                File.AppendAllText("shadowFlyvning1.csv" , strlist2[i]);
                j++;

            }
        }
    }
}