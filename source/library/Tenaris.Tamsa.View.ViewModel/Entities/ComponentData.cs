using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenaris.Tamsa.View.ViewModel.Entities
{
        //Implementamos la Interfaz INotifyPropertyChanged para notificar a nuestros controles enlazados que una propiedad de
        // esta clase ha cambiado.
    public class ComponentData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        private int _id;

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Id"));
            }
        }

        private int _heat;

        public int Heat
        {
            get
            {
                return _heat;
            }
            set
            {
                _heat = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Heat"));
            }
        }

        private int _wo;

        public int WO
        {
            get
            {
                return _wo;
            }
            set
            {
                _wo = value;
                OnPropertyChanged(new PropertyChangedEventArgs("WO"));
            }
        }

        private DateTime _createdate;

        public DateTime CreateDate
        {
            get
            {
                return _createdate;
            }
            set
            {
                _createdate = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CreateDate"));
            }
        }

        private DateTime _updatedate;

        public DateTime UpdateDate
        {
            get
            {
                return _updatedate;
            } set
            {
                _updatedate = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UpdateDate"));
            }
        }

        public void Tubos(int id, int heat, int wo, DateTime createdate, DateTime updatedate) //no retorna a nada por eso se le pone void
        {
            
            this.Id = id;
            this.Heat = heat;
            this.WO = wo;
            this.CreateDate = createdate;
            this.UpdateDate = updatedate;  
        }
    }
}
