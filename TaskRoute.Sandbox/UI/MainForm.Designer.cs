using TaskRoute.Sandbox.UI;

namespace TaskRoute.Sandbox
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.run1TourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRunAlg = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudColonySize = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudQ = new System.Windows.Forms.NumericUpDown();
            this.nudRho = new System.Windows.Forms.NumericUpDown();
            this.nudBeta = new System.Windows.Forms.NumericUpDown();
            this.nudAlpha = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.visualizerSurface1 = new TaskRoute.Sandbox.UI.VisualizerSurface();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblProfit = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudColonySize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlpha)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.simulationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit...";
            // 
            // simulationToolStripMenuItem
            // 
            this.simulationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.run1TourToolStripMenuItem});
            this.simulationToolStripMenuItem.Name = "simulationToolStripMenuItem";
            this.simulationToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.simulationToolStripMenuItem.Text = "Simulation";
            // 
            // run1TourToolStripMenuItem
            // 
            this.run1TourToolStripMenuItem.Name = "run1TourToolStripMenuItem";
            this.run1TourToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.run1TourToolStripMenuItem.Text = "Run 1 Tour...";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(969, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(283, 642);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.btnClear);
            this.tabPage1.Controls.Add(this.btnRunAlg);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(275, 616);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Simulation";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.trackBar1);
            this.groupBox2.Controls.Add(this.lblValue);
            this.groupBox2.Controls.Add(this.lblId);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(6, 134);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(263, 134);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selection";
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.Color.White;
            this.trackBar1.Location = new System.Drawing.Point(6, 80);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(251, 45);
            this.trackBar1.TabIndex = 17;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblValue.Location = new System.Drawing.Point(84, 57);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(31, 20);
            this.lblValue.TabIndex = 16;
            this.lblValue.Text = "1.0";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblId.Location = new System.Drawing.Point(82, 23);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(35, 20);
            this.lblId.TabIndex = 15;
            this.lblId.Text = "N/A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(11, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Profit = ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(24, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "ID# = ";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(6, 587);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRunAlg
            // 
            this.btnRunAlg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunAlg.Location = new System.Drawing.Point(194, 587);
            this.btnRunAlg.Name = "btnRunAlg";
            this.btnRunAlg.Size = new System.Drawing.Size(75, 23);
            this.btnRunAlg.TabIndex = 3;
            this.btnRunAlg.Text = "Run";
            this.btnRunAlg.UseVisualStyleBackColor = true;
            this.btnRunAlg.Click += new System.EventHandler(this.btnRunAlg_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudColonySize);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.nudQ);
            this.groupBox1.Controls.Add(this.nudRho);
            this.groupBox1.Controls.Add(this.nudBeta);
            this.groupBox1.Controls.Add(this.nudAlpha);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ACO Parameters";
            // 
            // nudColonySize
            // 
            this.nudColonySize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudColonySize.Location = new System.Drawing.Point(58, 88);
            this.nudColonySize.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudColonySize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudColonySize.Name = "nudColonySize";
            this.nudColonySize.Size = new System.Drawing.Size(55, 20);
            this.nudColonySize.TabIndex = 12;
            this.nudColonySize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(5, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "|A| = ";
            this.toolTip1.SetToolTip(this.label5, "Ant set cardinality.");
            // 
            // nudQ
            // 
            this.nudQ.Location = new System.Drawing.Point(176, 56);
            this.nudQ.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudQ.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQ.Name = "nudQ";
            this.nudQ.Size = new System.Drawing.Size(55, 20);
            this.nudQ.TabIndex = 10;
            this.nudQ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudRho
            // 
            this.nudRho.DecimalPlaces = 2;
            this.nudRho.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudRho.Location = new System.Drawing.Point(58, 56);
            this.nudRho.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.nudRho.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudRho.Name = "nudRho";
            this.nudRho.Size = new System.Drawing.Size(55, 20);
            this.nudRho.TabIndex = 9;
            this.nudRho.Value = new decimal(new int[] {
            9,
            0,
            0,
            65536});
            // 
            // nudBeta
            // 
            this.nudBeta.DecimalPlaces = 2;
            this.nudBeta.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudBeta.Location = new System.Drawing.Point(176, 23);
            this.nudBeta.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            65536});
            this.nudBeta.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudBeta.Name = "nudBeta";
            this.nudBeta.Size = new System.Drawing.Size(55, 20);
            this.nudBeta.TabIndex = 8;
            this.nudBeta.Value = new decimal(new int[] {
            20,
            0,
            0,
            65536});
            // 
            // nudAlpha
            // 
            this.nudAlpha.DecimalPlaces = 2;
            this.nudAlpha.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudAlpha.Location = new System.Drawing.Point(58, 23);
            this.nudAlpha.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            65536});
            this.nudAlpha.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudAlpha.Name = "nudAlpha";
            this.nudAlpha.Size = new System.Drawing.Size(55, 20);
            this.nudAlpha.TabIndex = 7;
            this.nudAlpha.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(132, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Q = ";
            this.toolTip1.SetToolTip(this.label4, "Pheromone deposit coefficient.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(17, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "ρ = ";
            this.toolTip1.SetToolTip(this.label3, "Pheromone decay factor.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(135, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "β = ";
            this.toolTip1.SetToolTip(this.label2, "Weight of Visibility during optimization.");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "α = ";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(275, 616);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tasks";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // visualizerSurface1
            // 
            this.visualizerSurface1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.visualizerSurface1.BackColor = System.Drawing.Color.White;
            this.visualizerSurface1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.visualizerSurface1.Location = new System.Drawing.Point(12, 27);
            this.visualizerSurface1.Name = "visualizerSurface1";
            this.visualizerSurface1.Size = new System.Drawing.Size(951, 642);
            this.visualizerSurface1.TabIndex = 1;
            this.visualizerSurface1.Text = "visualizerSurface1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTime);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblProfit);
            this.groupBox3.Controls.Add(this.lblCost);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(6, 274);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(263, 132);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Solution";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(17, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "Cost = ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(17, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "Profit = ";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCost.Location = new System.Drawing.Point(84, 26);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(35, 20);
            this.lblCost.TabIndex = 18;
            this.lblCost.Text = "N/A";
            // 
            // lblProfit
            // 
            this.lblProfit.AutoSize = true;
            this.lblProfit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProfit.Location = new System.Drawing.Point(86, 61);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.Size = new System.Drawing.Size(35, 20);
            this.lblProfit.TabIndex = 20;
            this.lblProfit.Text = "N/A";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTime.Location = new System.Drawing.Point(86, 96);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(35, 20);
            this.lblTime.TabIndex = 22;
            this.lblTime.Text = "N/A";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(20, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 20);
            this.label9.TabIndex = 21;
            this.label9.Text = "Time = ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.visualizerSurface1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "MainForm";
            this.Text = "CBRO Algorithm Demo";
            this.toolTip1.SetToolTip(this, "Weight of Pheromone during optimization.");
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudColonySize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudBeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAlpha)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationToolStripMenuItem;
        private VisualizerSurface visualizerSurface1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem run1TourToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudQ;
        private System.Windows.Forms.NumericUpDown nudRho;
        private System.Windows.Forms.NumericUpDown nudBeta;
        private System.Windows.Forms.NumericUpDown nudAlpha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudColonySize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRunAlg;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblProfit;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label9;
    }
}