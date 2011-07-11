using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModularWPFTest.MvvmUtils;

namespace ModularWPFTest
{
    class ModuleViewModel : ViewModelBase
    {
        private readonly IModule module;
        private bool isSelected;

        public ModuleViewModel(IModule module)
        {
            this.module = module;
        }

        public string Name
        {
            get { return module.Name; }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    RaisePropertyChanged("IsSelected");
                }
            }
        }

        public bool CanExit
        {
            get { return module.CanExit; }
        }

        public IModule Module { get { return module; } }
    }
}
