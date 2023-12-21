using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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

        public Pipe SelectedPipe { get; set; }

        public Pipe SelectedPipeForDeletion { get; set; }



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
            //this.ActualizarTubos();
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
             
            Console.WriteLine($"Numero de tubos insertados: {Pipes.Count}");
        
        }


    

        public void ActualizarTubos()
        {
            if (SelectedPipe != null)
            {
                DataAccess.updatePipe(SelectedPipe);

                var index = Pipes.IndexOf(SelectedPipe);
                if (index != -1)
                {
                    var updatedPipe = DataAccess.getPipes().FirstOrDefault(p => p.id == SelectedPipe.id);
                    if (updatedPipe != null)
                    {
                        Pipes[index] = updatedPipe;
                        RaisePropertyChanged(nameof(Pipes));
                        Console.WriteLine("Tubo actualizado correctamente");
                    }
                }
            }
            else
            {
                Console.WriteLine("Ningún tubo seleccionado para actualizar");
            }

        }




        public void EliminarTubos()
        {
            if (Pipes != null)
            {
                DataAccess.deletePipe(SelectedPipe);
               Pipes.Remove(SelectedPipe);
                RaisePropertyChanged(nameof(Pipes));
                Console.WriteLine("Tubo eliminado correctamente");
            }
            else
            {
                Console.WriteLine("Ningún tubo seleccionado para eliminar");
            }

        }



        //if (Pipes != null && Pipes.Count > 0)
        //{
        //    var pipeToDelete = Pipes[0]; // Obtenemos el primer elemento de la lista (o el que desees eliminar)
        //    DataAccess.deletePipe(pipeToDelete); // Elimina el tubo de la base de datos por su ID

        //    // Remover el tubo de la lista local
        //    Pipes.Remove(pipeToDelete);

        //    // Notificar a la vista que hubo cambios en los datos
        //    RaisePropertyChanged(nameof(Pipes));

        //    Console.WriteLine("Tubo eliminado correctamente");
        //}
        //else
        //{
        //    Console.WriteLine("No hay tubos para eliminar");
        //}

   
    
    }
}

