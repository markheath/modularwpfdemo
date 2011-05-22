using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel;

namespace ModularWPFTest
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private IModule selectedModule;

        public List<IModule> Modules { get; set; }
        
        public IModule SelectedModule 
        {
            get 
            { 
                return selectedModule; 
            }
            set 
            {
                if (value != selectedModule)
                {
                    selectedModule = value;
                    RaisePropertyChanged("UserInterface");
                }
            } 
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public UserControl UserInterface 
        { 
            get 
            {
                if (SelectedModule == null) return null;
                return SelectedModule.UserInterface; 
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
