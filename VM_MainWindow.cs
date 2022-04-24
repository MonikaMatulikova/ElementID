using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ElementID
{
    public class VM_MainWindow : INotifyPropertyChanged
    {
        #region PROPERTIES
        bool allObjects;
        bool selObjects;
        #endregion

        #region GETTERS, SETTERS
        public bool AllObjects
        {
            get { return allObjects; }
            set
            {
                if (allObjects != value) 
                {
                    allObjects = value;
                    NotifyPropertyChanged("AllObjects");
                    SelObjects = !allObjects;
                }
            }
        }
        public bool SelObjects
        {
            get { return selObjects; }
            set 
            {
                if (selObjects != value)
                {
                    selObjects = value;
                    NotifyPropertyChanged("SelObjects");
                }
            }
        }
        #endregion

        public VM_MainWindow()
        {
            InitializeProperties();
        }

        #region PRIVATE METHODS
        private void InitializeProperties()
        {
            allObjects = true;
        }
        #endregion

        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
