using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel;
using ModularWPFTest.MvvmUtils;

namespace ModularWPFTest
{
    class MainWindowViewModel : ViewModelBase
    {
        private IModule selectedModule;

        public MainWindowViewModel(IEnumerable<IModule> modules)
        {
            this.Modules = modules.OrderBy(m => m.Name).ToList();
            if (this.Modules.Count > 0)
            {
                this.SelectedModule = this.Modules[0];
            }
        }

        public List<IModule> Modules { get; private set; }
        
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
                    if (selectedModule == null || selectedModule.CanExit)
                    {
                        selectedModule = value;
                        RaisePropertyChanged("SelectedModule");
                        RaisePropertyChanged("UserInterface");
                    }
                }
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
    }
}
