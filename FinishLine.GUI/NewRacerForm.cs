using System;
using System.Windows.Forms;
using FinishLine.Core;

namespace FinishLine
{
    /// <summary>
    /// win form for filling data of new runners/racers
    /// also working like edit form
    /// </summary>
    public partial class NewRacerForm : Form
    {
        #region fields and constructors
        private RacerFactory _raceFac;
        private CountryFactory _countryFac;  

        /// <summary>
        /// this constructor is called whe user want to add
        /// new racer/runner
        /// </summary>
        /// <param name="racerFactory"></param>
        /// <param name="countryFactory"></param>
        public NewRacerForm(RacerFactory racerFactory, CountryFactory countryFactory)
        {

            ControlBox = true;
            _raceFac = racerFactory;
            _countryFac = countryFactory;
            InitializeComponent();           
            btnDoStuff.Text = "Add Racer";
            FillCountryBox();

        }
        /// <summary>
        /// this constructor is called whe user want to edit racer/runner
        /// </summary>
        /// <param name="racerFactory"></param>
        /// <param name="countryFactory"></param>
        /// <param name="ID"></param>
        public NewRacerForm(RacerFactory racerFactory, CountryFactory countryFactory, int ID)
        {
            ControlBox = false;
            _raceFac = racerFactory;
            _countryFac = countryFactory;
            InitializeComponent();           
            btnDoStuff.Text = "Edit Racer";
            FillCountryBox();
            EditRacer(ID);
        }
        #endregion

        /// <summary>
        /// When editing preselect value of controls with 
        /// last used values
        /// </summary>
        /// <param name="id"></param>
        private void EditRacer(int id)
        {
            txtBoxName.Text = _raceFac.RacerMap[id].Name;
            txtBoxAge.Text = _raceFac.RacerMap[id].Age.ToString();
            txtBoxID.SelectedText = Convert.ToString(id);
            if (_raceFac.RacerMap[id].Sex.Equals("Male"))
            {
                radioBtnMale.Checked = true;
            }
            else
            {
                radioBtnFemale.Checked = true;
            }           
            _raceFac.RacerMap.Remove(id);


        }

        private void NewRacerForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// fill comboBox with countries loaded froma  file
        /// </summary>
        private void FillCountryBox()
        {

            radioBtnMale.Checked = true;
           

            foreach (var key in _countryFac.MapOfCountries)
            {


                cmbBoxCountry.Items.Add($"{key.Key.ToString()} :{_countryFac.MapOfCountries[key.Key].SlovakName} " +
                    $":{_countryFac.MapOfCountries[key.Key].OfficialShortName} :{_countryFac.MapOfCountries[key.Key].EnglishShortName}");

            }
            cmbBoxCountry.SelectedIndex = 0;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Check Name input (just Length)
        /// </summary>
        /// <returns></returns>
        //TODO: remove numbers and special characters from name
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

        /// <summary>
        /// Checks if ID is in good format,range and not used.
        /// </summary>
        /// <returns></returns>
        private bool CheckID()
        {
            if (int.TryParse(txtBoxID.Text, out int result))
            {
                if (_raceFac.RacerMap.ContainsKey(result))
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

        /// <summary>
        /// checks for age, format and range
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// create new racer and put it in the dictionary
        /// ID is creating according to choice via checkBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRacer_Click(object sender, EventArgs e)
        {
            string isMale = (radioBtnMale.Checked) ? "Male" : "Female";

            if (!checkBoxID.Checked)
            {
                if (CheckAge() && CheckName())
                {
                    _raceFac.CreateRacer(txtBoxName.Text, _countryFac.MapOfCountries
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
                    _raceFac.CreateRacerWithID(Convert.ToInt32(txtBoxID.Text), txtBoxName.Text,
                        _countryFac.MapOfCountries[$"{cmbBoxCountry.GetItemText(cmbBoxCountry.SelectedItem)[0]}" +
                        $"{cmbBoxCountry.GetItemText(cmbBoxCountry.SelectedItem)[1]}"],
                    Convert.ToInt32(txtBoxAge.Text), isMale);

                    DialogResult = DialogResult.OK;
                }
            }


        }

        /// <summary>
        /// check if checkBox is checked and if yes allow user
        /// to enter his speciffic ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBoxID_CheckedChanged(object sender, EventArgs e)
        {

            labelID.Enabled = txtBoxID.Enabled = checkBoxID.Checked;

        }
    }
}
