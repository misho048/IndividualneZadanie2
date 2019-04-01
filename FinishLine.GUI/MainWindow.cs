using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using FinishLine.Core;

namespace FinishLine
{
    public partial class MainWindow : Form
    {
        private Logic logic = new Logic();
        private System.Timers.Timer aTimer = new System.Timers.Timer();
        private Stopwatch stopwatch = new Stopwatch();
        private DateTime _startTime;

        public MainWindow()
        {
            InitializeComponent();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 10;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void OnTimedEvent(object sender, EventArgs e)
        {
            TimeSpan t = DateTime.Now - _startTime;
            string answer = $"{t.Hours:00}:{t.Minutes:00}:{t.Seconds:00}.{t.Milliseconds:000}";
            MethodInvoker invoker = () => txtBoxtimer.Text = answer;
            BeginInvoke(invoker);
        }

        private void btnAddRacer_Click(object sender, EventArgs e)
        {
            RacerForm rf = new RacerForm(logic.RacerFac, logic.CountryFac);
            rf.ShowDialog();
            if (rf.DialogResult == DialogResult.OK)
            {
                ChangeEnabled();
                FillComboBoxRunners(0);
                FillDataGridView();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RaceProperties rp = new RaceProperties();
            rp.ShowDialog();
            logic.RaceSetProperties(rp.NumOfLaps, rp.LapLength, rp.NumOfWinners);

        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text.Equals("Start"))
            {
                aTimer.Start();
                _startTime = DateTime.Now;
                btnStartStop.Text = "Stop";
                btnAddLap.Enabled = true;
            }
            else
            {
                aTimer.Stop();
                btnStartStop.Text = "Start";
                btnAddLap.Enabled = false;
            }

        }

        private void ChangeEnabled()
        {
            btnStartStop.Enabled = !btnStartStop.Enabled;
            cmbBoxRunners.Enabled = !cmbBoxRunners.Enabled;
            label1.Visible = !label1.Visible;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FillComboBoxRunners(int unSelect)
        {
            cmbBoxRunners.Items.Clear();
            foreach (var racer in logic.ComboMap())
            {
                cmbBoxRunners.Items.Add($"{racer.Value.ID} : {racer.Value.Name}");
            }
            cmbBoxRunners.SelectedItem = unSelect;
        }


        private void FillComboBoxRunners(object obj)
        {
            cmbBoxRunners.Items.Clear();
            foreach (var racer in logic.ComboMap())
            {
                cmbBoxRunners.Items.Add($"{racer.Value.ID} : {racer.Value.Name}");
            }
            cmbBoxRunners.SelectedItem = obj;

        }

        private void FillDataGridView()
        {

            dataGridViewRace.Rows.Clear();
            raceGrouper.ResetGrouping();
            raceGrouper.SetGroupOn(dataGridViewRace.Columns["Lap"]);
            string laptime;

            foreach (var racer in logic.RacerFac.RacerMap)
            {
                TimeSpan t = racer.Value.LapTimeList.Last();
                laptime = $"{t.Hours:00}:{t.Minutes:00}:{t.Seconds:00}.{t.Milliseconds:000}";

                dataGridViewRace.Rows.Add(racer.Value.LapTimeList.Count - 1, racer.Value.ID, racer.Value.Name,
                    racer.Value.Country.OfficialShortName, laptime);

            }
            dataGridViewRace.Sort(dataGridViewRace.Columns[0], ListSortDirection.Descending);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddLap_Click(object sender, EventArgs e)
        {
            if (cmbBoxRunners.GetItemText(cmbBoxRunners.SelectedItem).ToString().Count() != 0)
            {
                int id = Convert.ToInt32(cmbBoxRunners.GetItemText(cmbBoxRunners.SelectedItem).Split(' ')[0]);

                logic.DoLap(id, _startTime);
                FillDataGridView();
                labelWinner.Text = logic.PrintWinners(id);
                FillComboBoxRunners(cmbBoxRunners.SelectedItem);

            }
            if (!logic.RaceStatus())
            {
                EndOfTheRace();
            }
        }

        private void EndOfTheRace()
        {
            aTimer.Stop();
            MessageBox.Show("All racers finished\n" +
                "Race is Over\n" +
                $"Race took {DateTime.Now - _startTime}");
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelWinner_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// button for removing player during race, delete 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (cmbBoxRunners.GetItemText(cmbBoxRunners.SelectedItem).ToString().Count() != 0)
            {
                int id = Convert.ToInt32(cmbBoxRunners.GetItemText(cmbBoxRunners.SelectedItem).Split(' ')[0]);
                logic.RemoveRunner(id);
                FillDataGridView();
                FillComboBoxRunners(-1);
            }
            if (!logic.RaceStatus())
            {
                EndOfTheRace();
            }
        }
    }
}
