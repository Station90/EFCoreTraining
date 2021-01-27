using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTraining.Models
{
    [Keyless]
    public class StoredProcResult
    {
        public string Name { get; set; }  
    }
}
