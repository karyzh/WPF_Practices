using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenaris.Tamsa.View.Reports.Model;
using Tenaris.Tamsa.View.Reports.ViewModel.Entities;

namespace Tenaris.Tamsa.View.Reports.ViewModel.Views
{
    public class MainWindowViewModel
    {
            public MainModel MainModel { get; set; }
            public ComponentsWindows Components { get; set; }

            public MainWindowViewModel()
            {
                    MainModel = MainModel.Instance;
                    Components = new ComponentsWindows
                    {
                        Title = ""
                    };
            }
    }
}

namespace System.Windows.Controls
{
    public class DataGridTextColumn
    {
    }

    public class DataGridTemplateColumn
    {
    }
}