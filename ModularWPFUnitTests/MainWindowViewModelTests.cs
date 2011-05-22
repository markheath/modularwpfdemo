using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModularWPFTest;

namespace ModularWPFUnitTests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        class FakeModule : IModule
        {

            public string Name
            {
                get { return "Fake Module"; }
            }

            public System.Windows.Controls.UserControl UserInterface
            {
                get { throw new NotImplementedException(); }
            }
        }
        [TestMethod]
        public void FirstModuleShouldBeSelectedByDefault()
        {
            FakeModule module = new FakeModule();
            MainWindowViewModel vm = new MainWindowViewModel(new FakeModule[] { module });

        }
    }
}
