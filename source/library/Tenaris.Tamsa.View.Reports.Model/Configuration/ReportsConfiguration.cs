using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenaris.Tamsa.View.ViewModel.Configuration.Config
{
    public class ReportsConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("Connection", IsRequired = true)]
        public string Connection
        {
            get { return this["Connection"].ToString(); }
            set { this["Connection"] = value; }
        }

        [ConfigurationProperty("ConnectionTimeOut", DefaultValue = 10)]
        public int ConnectionTimeOut
        {
            get { return (int)this["ConnectionTimeOut"]; }
            set { this["ConnectionTimeOut"] = value; }
        }
    }
}

