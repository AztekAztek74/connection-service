using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Interface
{
    public class UsersDataPost
    {
        public string Address { get; set; }
        public string FullName { get; set; }
        public int Phone { get; set; }
        public int AdditionalPhone { get; set; }
        public string HandlingReason { get; set; }
        public string Coment { get; set; }
        public string SelectedTariffs { get; set; }
    }
}
