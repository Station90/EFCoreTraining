﻿using EFCoreTraining.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            Console.WriteLine("Hello World!");
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
                if (!postalList.Any(x => x.Code == item.properties.postcode))
                {
                     postalCode = new PostalCode { Code = item.properties.postcode};
                     postalList.Add(postalCode);
                }
                else
                {
                    postalCode = postalList.First(x => x.Code == item.properties.postcode);
                }
                if (!streets.Any(x => x.Name == item.properties.street))
                {
                    street = new Street { Name = item.properties.street, PostalCodes = new List<PostalCode>()};
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
