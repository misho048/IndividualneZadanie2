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
    public partial class NewRacerForm : Form
    {
        RacerFactory RacerFac;
        CountryFactory CountryFac;  


        public NewRacerForm(RacerFactory racerFactory, CountryFactory countryFactory)
        {

            ControlBox = true;
            RacerFac = racerFactory;
            CountryFac = countryFactory;
            InitializeComponent();           
            btnDoStuff.Text = "Add Racer";
            FillCountryBox();

        }

        public NewRacerForm(RacerFactory racerFactory, CountryFactory countryFactory, int ID)
        {
            ControlBox = false;
            RacerFac = racerFactory;
            CountryFac = countryFactory;
            InitializeComponent();           
            btnDoStuff.Text = "Edit Racer";
            FillCountryBox();
            EditRacer(ID);
        }

        private void EditRacer(int id)
        {
            txtBoxName.Text = RacerFac.RacerMap[id].Name;
            txtBoxAge.Text = RacerFac.RacerMap[id].Age.ToString();
            txtBoxID.SelectedText = Convert.ToString(id);
            if (RacerFac.RacerMap[id].Sex.Equals("Male"))
            {
                radioBtnMale.Checked = true;
            }
            else
            {
                radioBtnFemale.Checked = true;
            }           
            RacerFac.RacerMap.Remove(id);


        }

        private void NewRacerForm_Load(object sender, EventArgs e)
        {

        }

        private void FillCountryBox()
        {

            radioBtnMale.Checked = true;
           

            foreach (var key in CountryFac.MapOfCountries)
            {


                cmbBoxCountry.Items.Add($"{key.Key.ToString()} :{CountryFac.MapOfCountries[key.Key].SlovakName} " +
                    $":{CountryFac.MapOfCountries[key.Key].OfficialShortName} :{CountryFac.MapOfCountries[key.Key].EnglishShortName}");

            }
            cmbBoxCountry.SelectedIndex = 0;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private bool CheckName()
        {
            if (txtBoxName.Text.Length == 0)
            {
                MessageBox.Show("Enter Name!!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckID()
        {
            if (int.TryParse(txtBoxID.Text, out int result))
            {
                if (RacerFac.RacerMap.ContainsKey(result))
                {
                    MessageBox.Show("Starting Number Already in use try another number");
                    return false;
                }
                else
                {
                    if (result > 999)
                    {
                        MessageBox.Show("Max Starting number is 999");
                        return false;
                    }
                    return true;
                }

            }
            else
            {

                MessageBox.Show("Wrong Starting Number Input");
                return false;
            }
        }

        private bool CheckAge()
        {
            if (int.TryParse(txtBoxAge.Text, out int result))
            {
                if ((result < 120) && (result > 5))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Age needs to be between 5 and 120");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Wrong Age Format Input");
                return false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddRacer_Click(object sender, EventArgs e)
        {
            string isMale = (radioBtnMale.Checked) ? "Male" : "Female";

            if (!checkBoxID.Checked)
            {
                if (CheckAge() && CheckName())
                {
                    RacerFac.CreateRacer(txtBoxName.Text, CountryFac.MapOfCountries
                        [$"{cmbBoxCountry.GetItemText(cmbBoxCountry.SelectedItem)[0]}" +
                        $"{cmbBoxCountry.GetItemText(cmbBoxCountry.SelectedItem)[1]}"],
                    Convert.ToInt32(txtBoxAge.Text), isMale);
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {

                if (CheckID() && CheckAge() && CheckName())
                {
                    RacerFac.CreateRacerWithID(Convert.ToInt32(txtBoxID.Text), txtBoxName.Text,
                        CountryFac.MapOfCountries[$"{cmbBoxCountry.GetItemText(cmbBoxCountry.SelectedItem)[0]}" +
                        $"{cmbBoxCountry.GetItemText(cmbBoxCountry.SelectedItem)[1]}"],
                    Convert.ToInt32(txtBoxAge.Text), isMale);

                    DialogResult = DialogResult.OK;
                }
            }


        }

        private void checkBoxID_CheckedChanged(object sender, EventArgs e)
        {

            labelID.Enabled = txtBoxID.Enabled = checkBoxID.Checked;

        }
    }
}
