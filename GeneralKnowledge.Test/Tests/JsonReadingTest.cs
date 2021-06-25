using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic data retrieval from JSON test
    /// </summary>
    public class JsonReadingTest : ITest
    {
        public string Name { get { return "JSON Reading Test";  } }

        public void Run()
        {
            var jsonData = Resources.SamplePoints;

            // TODO: 
            // Determine for each parameter stored in the variable below, the average value, lowest and highest number.
            // Example output
            // parameter   LOW AVG MAX
            // temperature   x   y   z
            // pH            x   y   z
            // Chloride      x   y   z
            // Phosphate     x   y   z
            // Nitrate       x   y   z
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("       Json Reading Test");
            Console.WriteLine("-----------------------------------");
            PrintOverview(jsonData);
        }

        private void PrintOverview(byte[] data)
        {
            var json= System.Text.Encoding.Default.GetString(data);
            SamplePoint samples = JsonConvert.DeserializeObject<SamplePoint>(json);
            var points = samples.Samples;
            foreach(var property in typeof(Sample).GetProperties())
            {
                if(property.Name=="Date")
                {
                    Console.WriteLine("Parameter \t Max \t Avg \t Low");
                    continue;
                }
              switch(property.Name)
                {
                    case "Temperature" :
                        {
                            float max = points.Max(m => m.Temperature);
                            float avg = points.Average(a => a.Temperature);
                            float low = points.Min(a => a.Temperature);
                            Console.WriteLine(property.Name + " \t " +max+" \t "+Math.Round(avg,2)+" \t "+low );
                            break;
                        }
                    case "PH":
                        {
                            int max = points.Max(m => m.PH);
                            double avg = points.Average(a => a.PH);
                            int low = points.Min(a => a.PH);
                            Console.WriteLine(property.Name + " \t " + max + " \t " + Math.Round(avg, 2) + " \t " + low);
                            break;
                        }
                    case "Phosphate":
                        {
                            int max = points.Max(m => m.Phosphate);
                            double avg = points.Average(a => a.Phosphate);
                            int low = points.Min(a => a.Phosphate);
                            Console.WriteLine(property.Name + " \t " + max + " \t " + Math.Round(avg, 2) + " \t " + low);
                            break;
                        }
                    case "Chloride":
                        {
                            int max = points.Max(m => m.Chloride);
                            double avg = points.Average(a => a.Chloride);
                            int low = points.Min(a => a.Chloride);
                            Console.WriteLine(property.Name + " \t " + max + " \t " + Math.Round(avg, 2) + " \t " + low);
                            break;
                        }
                    case "Nitrate":
                        {
                            int max = points.Max(m => m.Nitrate);
                            double avg = points.Average(a => a.Nitrate);
                            int low = points.Min(a => a.Nitrate);
                            Console.WriteLine(property.Name + " \t " + max + " \t " + Math.Round(avg, 2) + " \t " + low);
                            break;
                        }
                    default:
                        break;
                }
                

            }

        }
        class SamplePoint
        {
            [JsonProperty("samples")]
            public List<Sample> Samples { get; set; }
        }
        class Sample
        {
            [JsonProperty("date")]
            public DateTime Date { get; set; }
            [JsonProperty("temperature")]
            public float Temperature { get; set; }
            [JsonProperty("pH")]
            public int PH { get; set; }
            [JsonProperty("phosphate")]
            public int Phosphate { get; set; }
            [JsonProperty("chloride")]
            public int Chloride { get; set; }
            [JsonProperty("nitrate")]
            public int Nitrate { get; set; }

        } 
    }
}
