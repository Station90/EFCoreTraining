using EFCoreTraining.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTraining
{
    class GeoJson
    {
        public string type { get; set; }
        public Properties properties { get; set; }
    }
    class Properties
    {
        public string street { get; set; }
        public string postcode { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //InsertFromFile();
            //Insert();
            StoredProcedure("32-400");
        }

        private static void StoredProcedure(string ZipCode)
        {
            var factory = new ConsoleAppFactory();
            var context = factory.CreateDbContext();
            var result = 
                context.SPResult.FromSqlInterpolated($"GetStreets {ZipCode}");

            foreach(var r in result)
            {
                Console.WriteLine($"{r.Name}");
            }
        }


        private static void Insert()
        {
            Console.WriteLine("Inserting");
            var factory = new ConsoleAppFactory();
            var context = factory.CreateDbContext();
            var postalCode = new PostalCode {Code = "Test code"};
            var street = new Street {Name = "Test street", PostalCodes = new List<PostalCode> {postalCode}};
            context.PostalCodes.Add(postalCode);
            context.Streets.Add(street);
            var result = context.SaveChanges();
            Console.WriteLine("OK " + result);
        }


        private static void InsertFromFile()
        {
            Console.WriteLine("Inserting form file");
            List<GeoJson> items = new List<GeoJson>();
            using (StreamReader r = new StreamReader("C:\\pl_malopolskie-addresses-state.json"))
            {
                string json;
                while ((json = r.ReadLine()) != null)
                {
                    items.Add(JsonConvert.DeserializeObject<GeoJson>(json));
                }
            }

            var factory = new ConsoleAppFactory();
            var context = factory.CreateDbContext();
            var postalList = new List<PostalCode>();
            var streets = new List<Street>();

            foreach (var item in items)
            {
                var postalCode = new PostalCode();
                var street = new Street();
                if (postalList.All(x => x.Code != item.properties.postcode))
                {
                    postalCode = new PostalCode {Code = item.properties.postcode};
                    postalList.Add(postalCode);
                }
                else
                {
                    postalCode = postalList.First(x => x.Code == item.properties.postcode);
                }

                if (streets.All(x => x.Name != item.properties.street))
                {
                    street = new Street {Name = item.properties.street, PostalCodes = new List<PostalCode>()};
                    streets.Add(street);
                }
                else
                {
                    street = streets.First(x => x.Name == item.properties.street);
                }

                street.PostalCodes.Add(postalCode);
            }

            context.PostalCodes.AddRange(postalList);
            context.Streets.AddRange(streets);
            var result = context.SaveChanges();
            Console.WriteLine("OK " + result);
        }
    }
}
