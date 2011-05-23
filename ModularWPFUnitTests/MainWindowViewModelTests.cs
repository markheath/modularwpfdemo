using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModularWPFTest;
using Moq;

namespace ModularWPFUnitTests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void FirstModuleShouldBeSelectedByDefault()
        {
            IModule module = new Mock<IModule>().Object;
            MainWindowViewModel vm = new MainWindowViewModel(new IModule[] { module });
            Assert.AreSame(vm.SelectedModule, module);
        }
    }
}
