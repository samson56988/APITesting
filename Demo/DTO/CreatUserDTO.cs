using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    public class CreatUserDTO
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public long Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
