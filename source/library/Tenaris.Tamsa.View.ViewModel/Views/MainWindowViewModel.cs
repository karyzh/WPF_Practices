﻿using Microsoft.Practices.Prism.Commands;
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

            if (Pipes != null && Pipes.Count > 0)
            {
                var pipeToUpdate = Pipes[0]; // Obtiene el primer elemento de la lista
                DataAccess.updatePipe(pipeToUpdate); // Actualiza en la base de datos

                // Refrescar el objeto Pipe con los datos actualizados desde la base de datos
                var updatedPipe = DataAccess.getPipes().FirstOrDefault(Pipes => Pipes.id == pipeToUpdate.id);

                if (updatedPipe != null)
                {
                    // Encuentra el índice del objeto Pipe original en la lista Pipes
                    var index = Pipes.IndexOf(pipeToUpdate);
                    if (index != -1)
                    {
                        // Reemplaza el objeto Pipe original en la lista con el objeto actualizado
                        Pipes[index] = updatedPipe;

                        // Notifica a la vista que ha habido cambios en los datos
                        RaisePropertyChanged(nameof(Pipes));

                        Console.WriteLine("Tubo actualizado correctamente");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontró el tubo actualizado");
                }
            }

          

            //  DataAccess.updatePipe(Pipe);
            //Pipes.Clear();
            //LoadData();

            Console.WriteLine($"Número de tubos actualizados: {Pipes.Count}");
        }

        public void EliminarTubos()
        {
            if (Pipes != null && Pipes.Count > 0)
            {
                var pipeToDelete = Pipes[0]; // Obtener el primer elemento de la lista (o el que desees eliminar)
                DataAccess.deletePipe(pipeToDelete); // Elimina el tubo de la base de datos por su ID

                // Remover el tubo de la lista local
                Pipes.Remove(pipeToDelete);

                // Notificar a la vista que hubo cambios en los datos
                RaisePropertyChanged(nameof(Pipes));

                Console.WriteLine("Tubo eliminado correctamente");
            }
            else
            {
                Console.WriteLine("No hay tubos para eliminar");
            }



            //DataAccess.deletePipe(Pipes.ToList());

            //Console.WriteLine($"Número de tubos eliminados: {Pipes.Count}");
        }
    }
}

