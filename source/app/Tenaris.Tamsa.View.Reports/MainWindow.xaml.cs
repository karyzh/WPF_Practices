using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tenaris.Tamsa.View.Reports
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{

        //    Tenaris.Tamsa.View.Reports.TenarisPipesDataSet1 tenarisPipesDataSet1 = ((Tenaris.Tamsa.View.Reports.TenarisPipesDataSet1)(this.FindResource("tenarisPipesDataSet1")));
        //    {
        //        // Load data into the table InformationPipes. You can modify this code as needed.
        //        Tenaris.Tamsa.View.Reports.TenarisPipesDataSet1TableAdapters.InformationPipesTableAdapter tenarisPipesDataSet1InformationPipesTableAdapter = new Tenaris.Tamsa.View.Reports.TenarisPipesDataSet1TableAdapters.InformationPipesTableAdapter();
        //        tenarisPipesDataSet1InformationPipesTableAdapter.Fill(tenarisPipesDataSet1.InformationPipes);
        //    }

        //    System.Windows.Data.CollectionViewSource informationPipesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("informationPipesViewSource")));
        //    informationPipesViewSource.View.MoveCurrentToFirst();
        //}

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
