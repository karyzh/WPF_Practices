using Microsoft.Practices.Prism.Commands;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tenaris.Tamsa.View.Reports.Model;
using Tenaris.Tamsa.View.Reports.Model.DataAccess;
using Tenaris.Tamsa.View.Reports.Model.Models;
using Tenaris.Tamsa.View.Reports.ViewModel.Entities;

namespace Tenaris.Tamsa.View.Reports.ViewModel.Views
{
    public class MainWindowViewModel
    {
            public MainModel MainModel { get; set; }
       
        public ComponentsWindows Components { get; set; }
        public ICommand BtnCargarTubos { get; set; }

        public DataAccess DataAccess { get; set; }

        public MainWindowViewModel()
        {
                    MainModel = MainModel.Instance;
                    DataAccess = new DataAccess();
                    MainModel.Instance.ConnectionTest();
                    BtnCargarTubos = new DelegateCommand(CargarTubos);
                    Components = new ComponentsWindows
                    {
                        Title = ""
                    };
        }
        private void CargarTubos()
        {
            List<Pipe> pipes = DataAccess.CargarPipes();
            foreach (var pipe in pipes)
            {
                Console.WriteLine(pipe.Id);
            }
        }
    }
}

