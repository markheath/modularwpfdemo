using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.ComponentModel.Composition;
using System.Windows;

namespace ModularWPFTest
{
    [Export(typeof(IModule))]
    class Module1 : IModule
    {
        private readonly Module1ViewModel viewModel = new Module1ViewModel();
        private Module1View ui;

        public string Name
        {
            get { return "Module 1"; }
        }

        public UserControl UserInterface
        {
            get 
            { 
                return ui;
            }
        }

        public bool CanExit
        {
            get 
            {
                bool canExit = true;
                if (!String.IsNullOrEmpty(viewModel.UserName))
                {
                    var dialogResult = MessageBox.Show("You have not saved your changes, are you sure you want to navigate away?",
                        "Exiting Module 1",
                        MessageBoxButton.YesNoCancel);
                    if (dialogResult != MessageBoxResult.Yes)
                    {
                        canExit = false;
                    }
                }
                return canExit;
            }
        }

        public void Load()
        {
            if (ui == null)
            {
                ui = new Module1View();
                ui.DataContext = viewModel;
            }
        }


        public bool IsSelected { get; set; }
    }
}
