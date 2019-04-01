using System;
using System.Windows.Forms;
using FinishLine.Core;

namespace FinishLine
{
    /// <summary>
    /// Form for working with Data of Racers
    /// </summary>
    public partial class RacerForm : Form
    {
        #region fields and constructor
        private RacerFactory _raceFac;
        private CountryFactory _countryFac ;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="racerFactory"></param>
        /// <param name="countryFactory"></param>
        public RacerForm(RacerFactory racerFactory,CountryFactory countryFactory)
        {
            _raceFac = racerFactory;
            _countryFac = countryFactory;           
            InitializeComponent();            
            fillGrid();
        }
        #endregion

        /// <summary>
        /// button for add Racer, go into next Form where user
        /// can create a new racer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRacer_Click(object sender, EventArgs e)
        {       
            NewRacerForm nrf = new NewRacerForm(_raceFac,_countryFac);
            nrf.ShowDialog();
            fillGrid();
        }

        /// <summary>
        /// method for filling the dataGridView with existing racers
        /// </summary>
        private void fillGrid()
        {

            dataGridView1.Rows.Clear();
            if (_raceFac.RacerMap != null)
            {
                foreach (var racer in _raceFac.RacerMap)
                {

                    dataGridView1.Rows.Add(_raceFac.RacerMap[racer.Key].ID, _raceFac.RacerMap[racer.Key].Name,
                        _raceFac.RacerMap[racer.Key].Country.EnglishShortName, _raceFac.RacerMap[racer.Key].Age,
                        _raceFac.RacerMap[racer.Key].Sex);
                }
            }
        }

        /// <summary>
        /// remove selected racer from a DataGridVIew and 
        /// collection holdings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnDeleteRacer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 1)
            {             
                            
           
                _raceFac.RacerMap.Remove(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                fillGrid();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// calls window for a adding new player with slightly edited mode
        /// for Editing players (old is deleted and new is created as a replace)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            NewRacerForm newRacerForm = new NewRacerForm(_raceFac, _countryFac, Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            newRacerForm.ShowDialog();
            fillGrid();
        }

        /// <summary>
        /// button for going back to mainwindow and confirming changes
        /// there needs to be atleast 2 runners/racers for the race
        /// to be able continue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (_raceFac.RacerMap.Count > 1)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Add Some More Runners");
            }
        }
    }
}
