using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenaris.Tamsa.View.Reports.ViewModel.Views;


namespace Tenaris.Tamsa.View.Reports.ViewModel
{
    public class ViewModelInstance
    {
        public ViewModelInstance()
        {
            Instance = this;
            MainWindowVM = new MainWindowViewModel();
        }

        public static ViewModelInstance Instance { get; set; }
        public MainWindowViewModel MainWindowVM { get; set; }
    }
}
