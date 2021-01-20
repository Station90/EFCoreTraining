using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTraining.Models
{
    public class Street
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<PostalCode> PostalCodes { get; set; }
    }
}
