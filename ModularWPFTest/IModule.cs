﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ModularWPFTest
{
    public interface IModule
    {
        void Load();
        string Name { get; }
        UserControl UserInterface { get; }
        bool CanExit { get; }
    }
}
