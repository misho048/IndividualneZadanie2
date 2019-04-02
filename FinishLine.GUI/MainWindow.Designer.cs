namespace FinishLine
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAddRacer = new System.Windows.Forms.Button();
            this.btnEditRace = new System.Windows.Forms.Button();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.labelWinner = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddLap = new System.Windows.Forms.Button();
            this.cmbBoxRunners = new System.Windows.Forms.ComboBox();
            this.dataGridViewRace = new System.Windows.Forms.DataGridView();
            this.Lap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.RunnerName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Country = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Time = new System.Windows.Forms.DataGridViewLinkColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtBoxtimer = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.raceGrouper = new Subro.Controls.DataGridViewGrouper(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRace)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddRacer
            // 
            this.btnAddRacer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnAddRacer.Location = new System.Drawing.Point(2, 1);
            this.btnAddRacer.Name = "btnAddRacer";
            this.btnAddRacer.Size = new System.Drawing.Size(197, 28);
            this.btnAddRacer.TabIndex = 0;
            this.btnAddRacer.Text = "Edit Racers";
            this.btnAddRacer.UseVisualStyleBackColor = true;
            this.btnAddRacer.Click += new System.EventHandler(this.btnAddRacer_Click);
            // 
            // btnEditRace
            // 
            this.btnEditRace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEditRace.Location = new System.Drawing.Point(195, 1);
            this.btnEditRace.Name = "btnEditRace";
            this.btnEditRace.Size = new System.Drawing.Size(197, 28);
            this.btnEditRace.TabIndex = 1;
            this.btnEditRace.Text = "Edit Race";
            this.btnEditRace.UseVisualStyleBackColor = true;
            this.btnEditRace.Click += new System.EventHandler(this.Button2_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Enabled = false;
            this.btnStartStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStartStop.Location = new System.Drawing.Point(603, 1);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(182, 28);
            this.btnStartStop.TabIndex = 2;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.labelWinner);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnAddLap);
            this.panel1.Controls.Add(this.cmbBoxRunners);
            this.panel1.Controls.Add(this.dataGridViewRace);
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1102, 569);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(754, 109);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(307, 41);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Remove From  Race";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // labelWinner
            // 
            this.labelWinner.AutoSize = true;
            this.labelWinner.Location = new System.Drawing.Point(742, 169);
            this.labelWinner.Name = "labelWinner";
            this.labelWinner.Size = new System.Drawing.Size(0, 13);
            this.labelWinner.TabIndex = 4;
            this.labelWinner.Click += new System.EventHandler(this.labelWinner_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(739, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "There needs to be atleast 2 Runners before starting the race";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnAddLap
            // 
            this.btnAddLap.Enabled = false;
            this.btnAddLap.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddLap.Location = new System.Drawing.Point(754, 67);
            this.btnAddLap.Name = "btnAddLap";
            this.btnAddLap.Size = new System.Drawing.Size(307, 36);
            this.btnAddLap.TabIndex = 2;
            this.btnAddLap.Text = "Add Lap";
            this.btnAddLap.UseVisualStyleBackColor = true;
            this.btnAddLap.Click += new System.EventHandler(this.btnAddLap_Click);
            // 
            // cmbBoxRunners
            // 
            this.cmbBoxRunners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxRunners.Enabled = false;
            this.cmbBoxRunners.FormattingEnabled = true;
            this.cmbBoxRunners.Location = new System.Drawing.Point(754, 40);
            this.cmbBoxRunners.Name = "cmbBoxRunners";
            this.cmbBoxRunners.Size = new System.Drawing.Size(307, 21);
            this.cmbBoxRunners.TabIndex = 1;
            // 
            // dataGridViewRace
            // 
            this.dataGridViewRace.AllowUserToAddRows = false;
            this.dataGridViewRace.AllowUserToDeleteRows = false;
            this.dataGridViewRace.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRace.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRace.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lap,
            this.ID,
            this.RunnerName,
            this.Country,
            this.Time});
            this.dataGridViewRace.Enabled = false;
            this.dataGridViewRace.EnableHeadersVisualStyles = false;
            this.dataGridViewRace.Location = new System.Drawing.Point(2, 0);
            this.dataGridViewRace.Name = "dataGridViewRace";
            this.dataGridViewRace.ReadOnly = true;
            this.dataGridViewRace.Size = new System.Drawing.Size(734, 498);
            this.dataGridViewRace.TabIndex = 0;
            this.dataGridViewRace.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Lap
            // 
            this.Lap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Lap.HeaderText = "Lap";
            this.Lap.Name = "Lap";
            this.Lap.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.HeaderText = "Runner Number";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // RunnerName
            // 
            this.RunnerName.HeaderText = "Name";
            this.RunnerName.Name = "RunnerName";
            this.RunnerName.ReadOnly = true;
            // 
            // Country
            // 
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            // 
            // Time
            // 
            this.Time.HeaderText = "Lap Time";
            this.Time.Name = "Time";
            this.Time.ReadOnly = true;
            // 
            // txtBoxtimer
            // 
            this.txtBoxtimer.Enabled = false;
            this.txtBoxtimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtBoxtimer.Location = new System.Drawing.Point(398, 5);
            this.txtBoxtimer.Name = "txtBoxtimer";
            this.txtBoxtimer.Size = new System.Drawing.Size(208, 22);
            this.txtBoxtimer.TabIndex = 4;
            this.txtBoxtimer.Text = "00:00:00.000";
            this.txtBoxtimer.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSave.Location = new System.Drawing.Point(791, 1);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 26);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLoad.Location = new System.Drawing.Point(896, 1);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(99, 26);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Enabled = false;
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRestart.Location = new System.Drawing.Point(1001, 1);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(99, 26);
            this.btnRestart.TabIndex = 7;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // raceGrouper
            // 
            this.raceGrouper.DataGridView = this.dataGridViewRace;
            this.raceGrouper.SortOrder = System.Windows.Forms.SortOrder.Descending;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 603);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBoxtimer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.btnEditRace);
            this.Controls.Add(this.btnAddRacer);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddRacer;
        private System.Windows.Forms.Button btnEditRace;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtBoxtimer;
        private System.Windows.Forms.DataGridView dataGridViewRace;
        private System.Windows.Forms.Button btnAddLap;
        private System.Windows.Forms.ComboBox cmbBoxRunners;
        private System.Windows.Forms.Label label1;
        public Subro.Controls.DataGridViewGrouper raceGrouper;
        private System.Windows.Forms.Label labelWinner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lap;
        private System.Windows.Forms.DataGridViewLinkColumn ID;
        private System.Windows.Forms.DataGridViewLinkColumn RunnerName;
        private System.Windows.Forms.DataGridViewLinkColumn Country;
        private System.Windows.Forms.DataGridViewLinkColumn Time;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnRestart;
    }
}

