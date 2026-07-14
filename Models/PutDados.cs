using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobAPI.Models
{
    public class PutDados
    {
        public int? ID { get; set;}
        public string? Empresa { get; set; }
        public string? Cargo { get; set; }

        public DateTime Data { get; set; }
        public string? Descrições { get; set;}
    }
}