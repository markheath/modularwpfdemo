using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ModularWPFTest
{
    class Module1 : IModule
    {
        public string Name
        {
            get { return "Module 1"; }
        }

        public UserControl UserInterface
        {
            get { return new Module1View(); }
        }
    }
}
