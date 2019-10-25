using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LINQInManhattan.Classes;
using Newtonsoft.Json;

namespace LINQInManhattan
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../../Data/data.json";

            // https://www.newtonsoft.com/json/help/html/DeserializeWithJsonSerializerFromFile.htm
            // https://www.jerriepelser.com/blog/deserialize-different-json-object-same-class/
            using StreamReader file = File.OpenText(path);
            JsonSerializer serializer = new JsonSerializer();
            Neighborhood neighborhood = (Neighborhood)serializer.Deserialize(file, typeof(Neighborhood));

            PrintNeighborhoods(neighborhood);
            FilterNoName(neighborhood);
            RemoveDuplicates(neighborhood);
            OpposingMethod(neighborhood);
        }

        static void PrintNeighborhoods(Neighborhood neighborhood)
        {
            Console.WriteLine("Output all of the neighborhoods in this data list(Final Total: 147 neighborhoods)");
            var neighborhoods = neighborhood.features.Select(x => x.properties.neighborhood);

            int counter = 1;
            foreach (var item in neighborhoods)
            {
                Console.WriteLine($"{counter}. {item}");
                counter++;
            }
            Console.WriteLine("");
        }

        static void FilterNoName(Neighborhood neighborhood)
        {
            Console.WriteLine("Filter out all the neighborhoods that do not have any names (Final Total: 143)");
            var neighborhoods = neighborhood.features
                .Where(x => x.properties.neighborhood != "")
                .Select(x => x.properties.neighborhood);

            int counter = 1;
            foreach (var item in neighborhoods)
            {
                Console.WriteLine($"{counter}. {item}");
                counter++;
            }
            Console.WriteLine("");
        }

        static void RemoveDuplicates(Neighborhood neighborhood)
        {
            Console.WriteLine("Remove the duplicates (Final Total: 39 neighborhoods)");
            var neighborhoods = neighborhood.features
                .Where(x => x.properties.neighborhood != "")
                .Select(x => x.properties.neighborhood)
                .Distinct();

            int counter = 1;
            foreach (var item in neighborhoods)
            {
                Console.WriteLine($"{counter}. {item}");
                counter++;
            }
            Console.WriteLine("");
        }

        static void OpposingMethod(Neighborhood neighborhood)
        {
            Console.WriteLine("Write at least one of these questions only using the opposing method");
            var neighborhoods =
                from x in neighborhood.features
                where x.properties.neighborhood != ""
                select x.properties.neighborhood;
            
            int counter = 1;
            foreach (var item in neighborhoods)
            {
                Console.WriteLine($"{counter}. {item}");
                counter++;
            }
            Console.WriteLine();
        }
    }
}
