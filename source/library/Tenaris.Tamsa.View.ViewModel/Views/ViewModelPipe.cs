using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenaris.Tamsa.View.Reports.Model.Configuration;
using Tenaris.Tamsa.View.Reports.Model.DataAccess;
using Tenaris.Tamsa.View.Reports.Model.Models;

namespace Tenaris.Tamsa.View.ViewModel.Views
{
    public class ViewModelPipe : NotificationObject { 
        
        private static ObservableCollection<Pipe> _pipes;
        public ReportsConfiguration Configuration { get; set; }

        public DataAccess DataAcess { get; set; }

        public ViewModelPipe()
         {
            //_pipes = new ObservableCollection<Pipe>();
            //Configuration = (ReportsConfiguration)ConfigurationManager.GetSection(Connectio);
            //DataAcess = new DataAccess(Configuration.Connection, Configuration.ConnectionTimeOut);
        }
    }
}
