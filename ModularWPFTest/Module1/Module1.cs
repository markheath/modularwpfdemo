using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel.Composition;

namespace ModularWPFTest
{
    [Export(typeof(IModule))]
    class Module1 : IModule
    {
        public string Name
        {
            get { return "Module 1"; }
        }

        public UserControl UserInterface
        {
            get 
            { 
                var view = new Module1View();
                view.DataContext = new Module1ViewModel();
                return view;
            }
        }
    }
}
