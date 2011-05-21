using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ModularWPFTest
{
    class Module2 : IModule
    {
        public string Name
        {
            get { return "Module 2"; }
        }

        public UserControl UserInterface
        {
            get { return new Module2View(); }
        }
    }
}
