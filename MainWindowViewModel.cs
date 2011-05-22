using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ModularWPFTest
{
    class MainWindowViewModel
    {
        private IModule selectedModule;

        public List<IModule> Modules { get; set; }
        
        public IModule SelectedModule 
        {
            get { return selectedModule; }
            set { selectedModule = value; } 
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
