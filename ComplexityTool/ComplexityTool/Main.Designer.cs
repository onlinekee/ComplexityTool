namespace ComplexityTool
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCode = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.txtCp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Statement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ctc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cnc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tokens = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.AcceptsTab = true;
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(38, 199);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(519, 434);
            this.txtCode.TabIndex = 0;
            this.txtCode.Text = "";
            this.txtCode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtCode_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Insert code here :";
            // 
            // btnCalculate
            // 
            this.btnCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalculate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(1086, 651);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(108, 37);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNo,
            this.Statement,
            this.Cs,
            this.Ctc,
            this.Cnc,
            this.Ci,
            this.TW,
            this.Cps,
            this.Cr,
            this.Tokens});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Location = new System.Drawing.Point(609, 199);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(630, 434);
            this.dataGridView.TabIndex = 5;
            // 
            // txtCp
            // 
            this.txtCp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCp.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtCp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCp.Location = new System.Drawing.Point(838, 651);
            this.txtCp.Name = "txtCp";
            this.txtCp.ReadOnly = true;
            this.txtCp.Size = new System.Drawing.Size(139, 26);
            this.txtCp.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(605, 653);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Complexity of the program (Cp) :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Square Serif Black", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(707, 46);
            this.label2.TabIndex = 10;
            this.label2.Text = "C++ and Java Complexity Tool";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift SemiCondensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(604, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Results :";
            // 
            // LineNo
            // 
            this.LineNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LineNo.HeaderText = "Line No";
            this.LineNo.MinimumWidth = 50;
            this.LineNo.Name = "LineNo";
            this.LineNo.Width = 69;
            // 
            // Statement
            // 
            this.Statement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Statement.HeaderText = "Program Statement";
            this.Statement.MinimumWidth = 100;
            this.Statement.Name = "Statement";
            this.Statement.Width = 112;
            // 
            // Cs
            // 
            this.Cs.HeaderText = "Cs";
            this.Cs.MinimumWidth = 50;
            this.Cs.Name = "Cs";
            // 
            // Ctc
            // 
            this.Ctc.HeaderText = "Ctc";
            this.Ctc.MinimumWidth = 50;
            this.Ctc.Name = "Ctc";
            // 
            // Cnc
            // 
            this.Cnc.HeaderText = "Cnc";
            this.Cnc.MinimumWidth = 50;
            this.Cnc.Name = "Cnc";
            // 
            // Ci
            // 
            this.Ci.HeaderText = "Ci";
            this.Ci.MinimumWidth = 50;
            this.Ci.Name = "Ci";
            // 
            // TW
            // 
            this.TW.HeaderText = "TW";
            this.TW.MinimumWidth = 50;
            this.TW.Name = "TW";
            // 
            // Cps
            // 
            this.Cps.HeaderText = "Cps";
            this.Cps.MinimumWidth = 50;
            this.Cps.Name = "Cps";
            // 
            // Cr
            // 
            this.Cr.HeaderText = "Cr";
            this.Cr.MinimumWidth = 50;
            this.Cr.Name = "Cr";
            // 
            // Tokens
            // 
            this.Tokens.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Tokens.HeaderText = "Tokens identified under the size factor";
            this.Tokens.MinimumWidth = 300;
            this.Tokens.Name = "Tokens";
            this.Tokens.Width = 300;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1251, 712);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCode);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox txtCp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Statement;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ctc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cnc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ci;
        private System.Windows.Forms.DataGridViewTextBoxColumn TW;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cps;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tokens;
    }
}

