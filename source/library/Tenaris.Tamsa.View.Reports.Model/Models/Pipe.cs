using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenaris.Tamsa.View.Reports.Model.Models
{

    //BINDING PATH EN MAINWINDOW.XAML
    public class Pipe
    {
        public int id { get; set; }
        public int heat { get; set; }
        public int wo { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public DateTimeOffset UpdateDate { get; set; }
    }
}
