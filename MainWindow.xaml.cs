using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModularWPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.listBox.SelectionChanged += (sender, args) => LoadModule((IModule)this.listBox.SelectedItem);
            this.listBox.SelectedIndex = 0;
        }

        private void LoadModule(IModule module)
        {
            this.contentPresenter.Content = module.UserInterface;
        }
    }
}
