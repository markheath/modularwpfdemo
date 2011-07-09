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

        [TestMethod]
        public void ShowsUserInterfaceOfSelectedModule()
        {
            var mock = new Mock<IModule>();
            var ui = new Mock<System.Windows.Controls.UserControl>();
            mock.Setup(m => m.UserInterface).Returns(ui.Object);
            MainWindowViewModel vm = new MainWindowViewModel(new IModule[] { mock.Object });
            Assert.AreSame(ui.Object, vm.UserInterface); 
        }

        [TestMethod]
        public void IfNoModulesUserInterfaceReturnsNull()
        {
            MainWindowViewModel vm = new MainWindowViewModel(new IModule[] { });
            Assert.IsNull(vm.UserInterface);
        }

        [TestMethod]
        public void WhenSelectedModuleChangesPropertyChangedEventFires()
        {
            var module1Mock = new Mock<IModule>();
            IModule module2 = new Mock<IModule>().Object;
            module1Mock.SetupGet((x) => x.CanExit).Returns(true);
            var module1 = module1Mock.Object;
            
            MainWindowViewModel vm = new MainWindowViewModel(new IModule[] { module1, module2 });
            List<string> propertiesChanged = new List<string>();
            vm.PropertyChanged += (sender, args) => propertiesChanged.Add(args.PropertyName);

            vm.SelectedModule = vm.Modules[1];

            Assert.AreEqual(2, propertiesChanged.Count);
            Assert.IsTrue(propertiesChanged.Contains("SelectedModule"));
            Assert.IsTrue(propertiesChanged.Contains("UserInterface"));
        }

        [TestMethod]
        public void WhenUserChangesModuleButCurrentlySelectedModuleRefusesChangeSelectedModuleShouldStayPut()
        {
            // setup a viewmodel with two modules
            var module1Mock = new Mock<IModule>();
            IModule module2 = new Mock<IModule>().Object;
            var module1 = module1Mock.Object;
            MainWindowViewModel vm = new MainWindowViewModel(new IModule[] { module1, module2 });

            // change selection to the second module
            vm.SelectedModule = module2;

            // we want the first module still to be selected
            Assert.AreSame(module1, vm.SelectedModule);
        }
    }
}
