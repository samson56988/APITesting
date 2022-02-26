using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class ListOfUserDTO
    {

        public long Page { get; set; }
        public long PerPage { get; set; }
        public long Total { get; set; }
        public List<Data> Data { get; set; }

    }
        public partial class Data
        {
            public long Id { get; set; }
            public string Email { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public Uri Avatar { get; set; }
        }
    }

