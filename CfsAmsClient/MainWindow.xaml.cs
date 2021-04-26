using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CfsAmsClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var accumulator = new Models.Accumulator();
            DataContext = accumulator;

            stack0.DataContext = accumulator.CellStacks[0];
            stack1.DataContext = accumulator.CellStacks[1];
            stack2.DataContext = accumulator.CellStacks[2];
            stack3.DataContext = accumulator.CellStacks[3];
            stack4.DataContext = accumulator.CellStacks[4];
            stack5.DataContext = accumulator.CellStacks[5];
        }
    }
}
