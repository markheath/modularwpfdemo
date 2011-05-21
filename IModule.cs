using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ModularWPFTest
{
    interface IModule
    {
        string Name { get; }
        UserControl UserInterface { get; }
    }
}
