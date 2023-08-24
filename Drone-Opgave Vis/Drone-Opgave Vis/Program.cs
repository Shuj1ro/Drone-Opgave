using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputFilePath = "flyvning1.csv";
        string outputFilePath = "new_GPT.csv";

        try
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                // Read and write the header line
                string headerLine = reader.ReadLine();
                writer.WriteLine(headerLine);

                while (!reader.EndOfStream)
                {
                    string dataLine = reader.ReadLine();

                    // Split fields
                    string[] fields = dataLine.Split(';');
                    string gpsLong = fields[3]; // Assuming GPSLong is at index 3
                    string gpsLat = fields[4];  // Assuming GPSLat is at index 4

                    // Correct GPS values
                    double correctedLong = double.Parse(gpsLong) / 10000000.0;
                    double correctedLat = double.Parse(gpsLat) / 10000000.0;

                    fields[3] = correctedLong.ToString();
                    fields[4] = correctedLat.ToString();

                    // Add GPS coordinates column
                    string gpsCoordinates = correctedLong.ToString() + ", " + correctedLat.ToString();
                    dataLine = string.Join(";", fields) + ";" + gpsCoordinates;

                    // Write the modified line to the new file
                    writer.WriteLine(dataLine);
                }
            }

            Console.WriteLine("Data processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
