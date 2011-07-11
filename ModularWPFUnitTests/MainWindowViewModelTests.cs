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
            var builder = new MainWindowViewModelBuilder(2);
            MainWindowViewModel vm = builder.Build();
            
            List<string> propertiesChanged = new List<string>();
            vm.PropertyChanged += (sender, args) => propertiesChanged.Add(args.PropertyName);

            vm.SelectModuleCommand.Execute(vm.Modules[1]);

            Assert.AreEqual(1, propertiesChanged.Count);
            Assert.IsTrue(propertiesChanged.Contains("UserInterface"));
        }

        [TestMethod]
        public void WhenAModuleIsSelectedItsLoadMethodMustBeCalled()
        {
            var builder = new MainWindowViewModelBuilder(2);
            MainWindowViewModel vm = builder.Build();

            // change selection to the second module
            vm.SelectModuleCommand.Execute(builder.MockModules[1].Object);

            // check load was called on it
            builder.MockModules[1].Verify(x => x.Load());
        }

        [TestMethod]
        public void WhenAModuleIsSelectectedItsIsSelectedPropertyMustGetSet()
        {
            var builder = new MainWindowViewModelBuilder(2);
            MainWindowViewModel vm = builder.Build();

            // change selection to the second module
            vm.SelectModuleCommand.Execute(vm.Modules[1]);

            builder.MockModules[1].VerifySet(x => x.IsSelected = true);            
        }

        [TestMethod]
        public void WhenAModuleIsDeselectectedItsIsSelectedPropertyMustGetUnset()
        {
            var builder = new MainWindowViewModelBuilder(2);
            MainWindowViewModel vm = builder.Build();

            // change selection to the second module
            vm.SelectModuleCommand.Execute(vm.Modules[1]);

            // check the first module gets unset
            builder.MockModules[0].VerifySet(x => x.IsSelected = false);
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
            vm.SelectModuleCommand.Execute(module2);

            // we want the first module still to be selected
            Assert.AreSame(module1, vm.SelectedModule);
        }
    }

    class MainWindowViewModelBuilder
    {
        public MainWindowViewModelBuilder(int numberOfMockModules)
        {
            this.MockModules = new List<Mock<IModule>>();
            for (int n = 0; n < numberOfMockModules; n++)
            {
                var mock = new Mock<IModule>();
                mock.SetupGet((x) => x.CanExit).Returns(true);
                this.MockModules.Add(mock);
            }            
        }

        public List<Mock<IModule>> MockModules { get; private set; }

        public MainWindowViewModel Build()
        {
            return new MainWindowViewModel(from m in this.MockModules select m.Object);
        }
    }

}
