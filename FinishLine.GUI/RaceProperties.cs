using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinishLine
{
    public partial class RaceProperties : Form
    {
        public int NumOfLaps;
        public decimal LapLength;
        public int NumOfWinners;

        public RaceProperties()
        {
            InitializeComponent();
            numlapLength.Maximum = decimal.MaxValue;
            numOfLaps.Maximum = int.MaxValue;
            numWinners.Maximum = int.MaxValue;

        }


        private void label2_Click(object sender, EventArgs e)
        {
        
        }

        private void RaceProperties_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            NumOfLaps = Convert.ToInt32(numOfLaps.Value);
            LapLength = numlapLength.Value;
            NumOfWinners = Convert.ToInt32(numWinners.Value);
            DialogResult = DialogResult.OK;

        }
    }
}
