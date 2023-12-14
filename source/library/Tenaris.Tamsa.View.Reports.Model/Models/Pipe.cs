using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenaris.Tamsa.View.Reports.Model.Models
{
    public class Pipe
    {
        public int Id { get; set; }
        public string Heat { get; set; }
        public string WO { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
    }
}
