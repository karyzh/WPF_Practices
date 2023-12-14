using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenaris.Tamsa.View.Reports.ViewModel.Entities
{
    public class ComponentsWindows : NotificationObject
    {
        #region Fields
        private string title;

        #endregion

        #region Properties

        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        #endregion

        #region Methods

        #endregion
    }
}
