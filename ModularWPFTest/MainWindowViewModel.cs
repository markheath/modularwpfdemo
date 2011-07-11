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
        private ModuleViewModel selectedModule;
        private readonly ICommand selectModuleCommand;

        public MainWindowViewModel(IEnumerable<IModule> modules)
        {
            this.Modules = modules.OrderBy(m => m.Name).Select(m => new ModuleViewModel(m)).ToList();
            this.selectModuleCommand = new RelayCommand((x) => SelectModule((ModuleViewModel)x));
            if (this.Modules.Count > 0)
            {
                SelectModule(this.Modules[0]);
            }            
        }

        public ICommand SelectModuleCommand { get { return selectModuleCommand; } }

        private void SelectModule(ModuleViewModel module)
        {
            if (selectedModule != module)
            {
                if (selectedModule == null || selectedModule.CanExit)
                {
                    module.Module.Load();
                    module.IsSelected = true;
                    if (selectedModule != null)
                        selectedModule.IsSelected = false;
                    selectedModule = module;
                    RaisePropertyChanged("UserInterface");
                }
            }
        }

        public List<ModuleViewModel> Modules { get; private set; }
        
        public IModule SelectedModule 
        {
            get 
            { 
                return selectedModule == null ? null : selectedModule.Module; 
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
