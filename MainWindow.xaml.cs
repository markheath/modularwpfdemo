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
            this.listBox.Items.Add("Module 1");
            this.listBox.Items.Add("Module 2");
            this.listBox.SelectionChanged += (sender, args) => LoadModule(this.listBox.SelectedIndex);
            this.listBox.SelectedIndex = 0;
        }

        private void LoadModule(int moduleIndex)
        {
            this.contentPresenter.Content = GetModuleContent(moduleIndex);
        }

        private UserControl GetModuleContent(int moduleIndex)
        {
            if (moduleIndex == 0) return new Module1View();
            return new Module2View();
        }
    }
}
