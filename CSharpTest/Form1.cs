using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using clrTest1;

namespace CSharpTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        clrTest1.Class1 Class1 = new Class1();
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Class1.GetPathOfProcess().ToString();
        }
    }
}
