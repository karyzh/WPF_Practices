using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenaris.Tamsa.View.Reports.Model
{
    public class MainModel
    {
        #region Fields

        private static MainModel _instance = null;
        private static readonly object Sync = new object();

        #endregion

        #region Properties

        public static MainModel Instance
        {
            get
            {
                lock (Sync) //lo que hace es bloquear la instancia
                {
                    if (_instance == null) // si la instancia es diferente a nula
                    {
                        _instance = new MainModel(); // creará una nueva instancia de lo contrario
                    }
                    return _instance; //retornará a la instancia y no se creará una nueva con diferentes datos
                }
            }
        }

        #endregion

        #region Methods


        #endregion
    }
}
