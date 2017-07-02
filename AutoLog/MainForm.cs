using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoLog
{
    public partial class MainForm : Form
    {
        public MainForm()
        {

            InitializeComponent();
            
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

            Form1 f1 = new Form1();
            f1.Show();
            f1.MdiParent = this;
        }
    }
}
