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
{/// <summary>
/// main win form when all race is happening
/// </summary>
    public partial class MainWindow : Form
    {
        #region fields  and constructor
       
        private Logic _logic = new Logic();
        private System.Timers.Timer _aTimer = new System.Timers.Timer();       
        private DateTime _startTime;

        public MainWindow()
        {
            InitializeComponent();
            _aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            _aTimer.Interval = 10;
            FormBorderStyle = FormBorderStyle.FixedSingle;                  
            
        }
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Timer, every tick (1ms rewrite textBox)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTimedEvent(object sender, EventArgs e)
        {
            TimeSpan t = DateTime.Now - _startTime;
            string answer = $"{t.Hours:00}:{t.Minutes:00}:{t.Seconds:00}.{t.Milliseconds:000}";
            MethodInvoker invoker = () => txtBoxtimer.Text = answer;
            BeginInvoke(invoker);
        }        
          
        /// <summary>
        /// create new window where user can check and edit/add/delete racers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRacer_Click(object sender, EventArgs e)
        {
            RacerForm rf = new RacerForm(_logic.RacerFac, _logic.CountryFac);
            rf.ShowDialog();
            if (rf.DialogResult == DialogResult.OK)
            {
                
                FillComboBoxRunners(0);
                FillDataGridView();
                btnStartStop.Enabled = true;
                btnSave.Enabled = true;
                label1.Hide();
            }

        }
        
        /// <summary>
        /// Set data for a race (num of laps, laps length,)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            RaceProperties rp = new RaceProperties();
            rp.ShowDialog();
            _logic.RaceSetProperties(rp.NumOfLaps, rp.LapLength, rp.NumOfWinners);

        }

        /// <summary>
        /// start/pause buttton, text changes after click, and others control buttons are 
        /// enabled / disabled acordingly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartStop.Text.Equals("Start"))
            {
                _aTimer.Start();
                _startTime = _logic.GetTime();
                btnStartStop.Text = "Pause";
                btnAddLap.Enabled = true;
                btnAddRacer.Enabled = false;
                btnEditRace.Enabled = false;
                btnRemove.Enabled = true;
                cmbBoxRunners.Enabled = true;
                btnRestart.Enabled = false;
                btnSave.Enabled = false;
            }
           
            else if (btnStartStop.Text.Equals("Exit"))
            {
                Close();
            }
                 else
            {
                _aTimer.Stop();
                _logic.SetTime((DateTime.Now - _startTime).ToString());
                btnStartStop.Text = "Start";
                btnAddLap.Enabled = false;
                btnRemove.Enabled = false;
                btnAddRacer.Enabled = true;
                btnEditRace.Enabled = true;
                cmbBoxRunners.Enabled = false;
                btnRestart.Enabled = true;
                btnSave.Enabled = true;

            }

        }

    

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// fill comboBox with data
        /// </summary>
        /// <param name="unSelect"></param>
        private void FillComboBoxRunners(int unSelect)
        {
            cmbBoxRunners.Items.Clear();
            foreach (var racer in _logic.ComboMap())
            {
                cmbBoxRunners.Items.Add($"{racer.Value.ID} : {racer.Value.Name}");
            }
            cmbBoxRunners.SelectedItem = unSelect;
        }

        /// <summary>
        /// fill comboBox with data
        /// </summary>
        /// <param name="obj"></param>
        private void FillComboBoxRunners(object obj)
        {
            cmbBoxRunners.Items.Clear();
            foreach (var racer in _logic.ComboMap())
            {
                cmbBoxRunners.Items.Add($"{racer.Value.ID} : {racer.Value.Name}");
            }
            cmbBoxRunners.SelectedItem = obj;

        }

        /// <summary>
        /// fill DataFridView with data and sort them by laps
        /// </summary>
        //TODO: better sorting and/or grouper
        private void FillDataGridView()
        {

            dataGridViewRace.Rows.Clear();
            raceGrouper.ResetGrouping();
            raceGrouper.SetGroupOn(dataGridViewRace.Columns["Lap"]);
            string laptime;

            foreach (var racer in _logic.RacerFac.RacerMap)
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

        /// <summary>
        /// Add lap to a specific runner
        /// add time which took the runner to complete the lap
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnAddLap_Click(object sender, EventArgs e)
        {
            if (cmbBoxRunners.GetItemText(cmbBoxRunners.SelectedItem).ToString().Count() != 0)
            {
                int id = Convert.ToInt32(cmbBoxRunners.GetItemText(cmbBoxRunners.SelectedItem).Split(' ')[0]);

                _logic.DoLap(id, _startTime);
                FillDataGridView();
                labelWinner.Text = _logic.PrintAttendants(id);
                FillComboBoxRunners(cmbBoxRunners.SelectedItem);

            }
            if (!_logic.RaceStatus())
            {
                EndOfTheRace();
            }
        }

        /// <summary>
        /// when race is finished this method will run
        /// and give user option between exit and restart
        /// </summary>

        private void EndOfTheRace()
        {
            
            MessageBox.Show("All racers finished\n" +
                "Race is Over\n" +
                $"Race took {DateTime.Now - _startTime}");
            btnStartStop.PerformClick();
            btnStartStop.Text = "Exit";
            cmbBoxRunners.Enabled = false;
            btnAddLap.Enabled = false;
            btnAddRacer.Enabled = false;
            btnEditRace.Enabled = false;
            btnLoad.Enabled = false;
            btnRemove.Enabled = false;
            btnSave.Enabled = false;
            btnStartStop.Enabled = true;
            btnRestart.Enabled = true;

            
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
                _logic.RemoveRunner(id);
                FillDataGridView();
                FillComboBoxRunners(-1);
            }
            if (!_logic.RaceStatus())
            {
                EndOfTheRace();
            }
        }

        /// <summary>
        /// save current progress to the file
        /// only avaliable during pause
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            DataLayer.SaveProgress(_logic,DateTime.Now-_startTime);
        }

        /// <summary>
        /// load Race progress froma  file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            _logic = DataLayer.LoadProgress();
            FillDataGridView();
            FillComboBoxRunners(-1);
            btnEditRace.Enabled = false;
            btnStartStop.Enabled = true;
            label1.Hide();
            btnStartStop.Text = "Start";
            btnRestart.Enabled = true;
            if (!_logic.RaceStatus())
            {
                EndOfTheRace();
            }
        }

        /// <summary>
        /// reset all properties and fields to default, except countrymap and racer map
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestart_Click(object sender, EventArgs e)
        {
            _aTimer.Stop();
            _logic.Reset();
            FillComboBoxRunners(-1);
            FillDataGridView();
            txtBoxtimer.Text = TimeSpan.Zero.ToString();
            btnEditRace.Enabled = true;
            btnStartStop.Text = "Start";
            btnStartStop.Enabled = true;
            btnAddRacer.Enabled = true;
           
            labelWinner.Text = "";

        }
    }
}
