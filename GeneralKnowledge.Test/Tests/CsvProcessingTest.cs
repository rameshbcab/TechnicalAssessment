using System;
using System.IO;
using System.Linq;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// CSV processing test
    /// </summary>
    public class CsvProcessingTest : ITest
    {
        public void Run()
        {
            // TODO
            // Create a domain model via POCO classes to store the data available in the CSV file below
            // Objects to be present in the domain model: Asset, Country and Mime type
            // Process the file in the most robust way possible
            // The use of 3rd party plugins is permitted
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("       Csv Processing Test");
            Console.WriteLine("-----------------------------------");
            try
            {
                AssetDatabaseEntities assetEntities = new AssetDatabaseEntities();
                var csvFile = Resources.AssetImport;
                StringReader reader = new StringReader(csvFile);
                string line;
                int count = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (count != 0&&count<=100)
                    {
                        string[] lineItem = line.Split(',');
                        Asset asset = new Asset()
                        {
                            AssetId = lineItem[0],
                            Name = lineItem[1],
                            MimeType = lineItem[2],
                            CreatedBy = lineItem[3],
                            Email = lineItem[4],
                            Country = lineItem[5],
                            Description = lineItem[6]
                        };
                        if (!assetEntities.Assets.AsEnumerable().Any(i => i.AssetId == lineItem[0]))
                        {
                            assetEntities.Assets.Add(asset);
                        }
                    }
                    else
                    {
                        assetEntities.SaveChanges();
                        assetEntities.Dispose();
                        assetEntities = new AssetDatabaseEntities();
                        assetEntities.Configuration.AutoDetectChangesEnabled = false;
                        count = 0;
                    }
                    count++;
                }
                assetEntities.SaveChanges();
                Console.WriteLine("Csv file processed and insert records into db.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception : " + ex.Message);
            }
            

        }
    }

}
