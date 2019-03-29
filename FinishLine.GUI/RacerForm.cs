using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinishLine.Core;

namespace FinishLine
{
    public partial class RacerForm : Form
    {

        RacerFactory RacerFac = new RacerFactory();
        CountryFactory CountryFac = new CountryFactory();

        public RacerForm()
        {

            RacerFac.CreateRacer("Misko", CountryFac.MapOfCountries["SK"], 26, "Male");
            RacerFac.CreateRacerWithID(25, "Misko", CountryFac.MapOfCountries["SK"], 26, "Male");
            RacerFac.CreateRacer("Misko", CountryFac.MapOfCountries["SK"], 26, "Male");
            RacerFac.CreateRacer("Misko", CountryFac.MapOfCountries["SK"], 26, "Male");
            InitializeComponent();
            fillGrid();
        }
        


        private void btnAddRacer_Click(object sender, EventArgs e)
        {
            
           

            NewRacerForm nrf = new NewRacerForm(RacerFac,CountryFac);
            nrf.ShowDialog();
            fillGrid();
        }


        private void fillGrid()
        {

            dataGridView1.Rows.Clear();
            if (RacerFac.RacerMap != null)
            {
                foreach (var racer in RacerFac.RacerMap)
                {

                    dataGridView1.Rows.Add(RacerFac.RacerMap[racer.Key].ID, RacerFac.RacerMap[racer.Key].Name,
                        RacerFac.RacerMap[racer.Key].Country.EnglishShortName, RacerFac.RacerMap[racer.Key].Age,
                        RacerFac.RacerMap[racer.Key].Sex);
                }
            }
        }


        private void btnDeleteRacer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 1)
            {             
                            
           
                RacerFac.RacerMap.Remove(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                fillGrid();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            NewRacerForm newRacerForm = new NewRacerForm(RacerFac, CountryFac, Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            newRacerForm.ShowDialog();
            fillGrid();
        }
    }
}
