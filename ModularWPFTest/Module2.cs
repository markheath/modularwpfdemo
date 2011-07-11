using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel.Composition;

namespace ModularWPFTest
{
    [Export(typeof(IModule))]
    class Module2 : IModule
    {
        private Module2View ui;

        public string Name
        {
            get { return "Module 2"; }
        }

        public UserControl UserInterface
        {
            get { return ui; }
        }


        public bool CanExit
        {
            get { return true; }
        }

        public void Load()
        {
            this.ui = new Module2View();
        }


        public bool IsSelected { get; set; }
    }
}
