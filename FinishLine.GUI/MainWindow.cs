using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinishLine.Core;

namespace FinishLine
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            CountryFactory cf = new CountryFactory();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddRacer_Click(object sender, EventArgs e)
        {
            RacerForm rf = new RacerForm();
            rf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RaceProperties rp = new RaceProperties();
            rp.ShowDialog();
        }
    }
}
