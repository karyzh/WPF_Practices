using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tenaris.Tamsa.View.Reports.Model;
using Tenaris.Tamsa.View.Reports.Model.DataAccess;
using Tenaris.Tamsa.View.Reports.Model.Models;
using Tenaris.Tamsa.View.Reports.ViewModel.Entities;
using Tenaris.Tamsa.View.ViewModel.Views;

namespace Tenaris.Tamsa.View.Reports.ViewModel.Views
{
    public class MainWindowViewModel : NotificationObject
    {
            public MainModel MainModel { get; set; }
       
        public ComponentsWindows Components { get; set; }

    

        public ICommand BtnCargarTubos { get; set; }

        public ICommand BtnInsertar {  get; set; }

        public ICommand BtnActualizar { get; set; }

        public ICommand BtnEliminar { get; set; }

        public DataAccess DataAccess { get; set; }

        public MainWindowViewModel()
        {
                    MainModel = MainModel.Instance;
                    DataAccess = new DataAccess();
                    MainModel.Instance.ConnectionTest();
                    BtnInsertar = new DelegateCommand(InsertarTubos);
                    BtnCargarTubos = new DelegateCommand(CargarTubos);
                    BtnActualizar = new DelegateCommand(ActualizarTubos);
                    BtnEliminar = new DelegateCommand(EliminarTubos);
                    Components = new ComponentsWindows
                    {
                        Title = ""
                    };
            pipes = new ObservableCollection<Pipe>(); //inicializando la colección observable vacía 
         
        }
        private static ObservableCollection<Pipe>  pipes;
        public ObservableCollection<Pipe> Pipes
        {
            get { return pipes; }
            set
            {
                pipes = value;
                RaisePropertyChanged(nameof(Pipes));
            }
        }
        public void CargarTubos()
        {
            Pipes = new ObservableCollection<Pipe>(DataAccess.getPipes()); //Casteo de una colección observable de tubos
            Console.WriteLine($"Número de tubos cargados: {Pipes.Count}");
            
        }

        public void LoadData()
        {
            Pipes = new ObservableCollection<Pipe>(DataAccess.getPipes());
        }
        public void InsertarTubos()
        {
           
            DataAccess.insertPipes(Pipes.ToList());
            Pipes.Clear();
            CargarTubos();
            Console.WriteLine($"Numero de tubos insertados: {Pipes.Count}");
        
        }

        public void ActualizarTubos()
        {

        }

        public void EliminarTubos()
        {

        }
    }
}

