﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tenaris.Tamsa.View.Reports.Model.DataAccess;
using Tenaris.Tamsa.View.ViewModel;

namespace Tenaris.Tamsa.View.Reports
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static DataAccess accesoDatos = new DataAccess();

        public static DataAccess AccesoDatos
        {
            get
            {
                return App.accesoDatos;
            }

            // Creamos una instancia de la clase DataAcess en el App por que asi
            // estará disponible para cualquier ventana que agreguemos a la aplicación.
        }
    }
}
