namespace FinishLine
{
    partial class RaceProperties
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.numOfLaps = new System.Windows.Forms.NumericUpDown();
            this.numlapLength = new System.Windows.Forms.NumericUpDown();
            this.numWinners = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numOfLaps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numlapLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWinners)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(55, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number Of Laps";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(53, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lap Length (Km)";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(22, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number Of Winners";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnConfirm.Location = new System.Drawing.Point(117, 201);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(229, 45);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // numOfLaps
            // 
            this.numOfLaps.Location = new System.Drawing.Point(284, 28);
            this.numOfLaps.Maximum = new decimal(new int[] {
            916128693,
            60037,
            0,
            0});
            this.numOfLaps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numOfLaps.Name = "numOfLaps";
            this.numOfLaps.Size = new System.Drawing.Size(120, 20);
            this.numOfLaps.TabIndex = 7;
            this.numOfLaps.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numlapLength
            // 
            this.numlapLength.Location = new System.Drawing.Point(284, 88);
            this.numlapLength.Name = "numlapLength";
            this.numlapLength.Size = new System.Drawing.Size(120, 20);
            this.numlapLength.TabIndex = 8;
            // 
            // numWinners
            // 
            this.numWinners.Location = new System.Drawing.Point(284, 151);
            this.numWinners.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWinners.Name = "numWinners";
            this.numWinners.Size = new System.Drawing.Size(120, 20);
            this.numWinners.TabIndex = 9;
            this.numWinners.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RaceProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 258);
            this.Controls.Add(this.numWinners);
            this.Controls.Add(this.numlapLength);
            this.Controls.Add(this.numOfLaps);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RaceProperties";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.RaceProperties_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numOfLaps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numlapLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWinners)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.NumericUpDown numOfLaps;
        private System.Windows.Forms.NumericUpDown numlapLength;
        private System.Windows.Forms.NumericUpDown numWinners;
    }
}