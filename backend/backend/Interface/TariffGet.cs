using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Interface
{
    public class TariffGet
    {
        public string ServiceName { get; set; }
        public int ServicePrice { get; set; }
        public string ServiceDescription { get; set; }
    }
}
