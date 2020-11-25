using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTraining.Models
{
    public class PostalCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public IList<Street> Streets { get; set; }
    }
}
