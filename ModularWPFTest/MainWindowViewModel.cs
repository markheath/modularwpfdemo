using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel;
using ModularWPFTest.MvvmUtils;
using System.Windows.Input;

namespace ModularWPFTest
{
    class MainWindowViewModel : ViewModelBase
    {
        private IModule selectedModule;
        private readonly ICommand selectModuleCommand;

        public MainWindowViewModel(IEnumerable<IModule> modules)
        {
            this.Modules = modules.OrderBy(m => m.Name).ToList();
            this.selectModuleCommand = new RelayCommand((x) => SelectModule((IModule)x));
            if (this.Modules.Count > 0)
            {
                SelectModule(this.Modules[0]);
            }            
        }

        public ICommand SelectModuleCommand { get { return selectModuleCommand; } }

        private void SelectModule(IModule module)
        {
            if (selectedModule != module)
            {
                if (selectedModule == null || selectedModule.CanExit)
                {
                    selectedModule = module;
                }
                RaisePropertyChanged("UserInterface");
            }
        }

        public List<IModule> Modules { get; private set; }
        
        public IModule SelectedModule 
        {
            get 
            { 
                return selectedModule; 
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
