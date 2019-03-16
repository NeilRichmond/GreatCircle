namespace GreatCircle
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbEndLongHemi = new System.Windows.Forms.ComboBox();
            this.txtEndLong = new System.Windows.Forms.TextBox();
            this.cmbEndLatHemi = new System.Windows.Forms.ComboBox();
            this.txtEndLat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStartLongHemi = new System.Windows.Forms.ComboBox();
            this.txtStartLong = new System.Windows.Forms.TextBox();
            this.cmbStartLatHemi = new System.Windows.Forms.ComboBox();
            this.txtStartLat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblOutVert2 = new System.Windows.Forms.Label();
            this.lblOutVert1 = new System.Windows.Forms.Label();
            this.lblOutCourse = new System.Windows.Forms.Label();
            this.lblOutDist = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbEndLongHemi);
            this.groupBox1.Controls.Add(this.txtEndLong);
            this.groupBox1.Controls.Add(this.cmbEndLatHemi);
            this.groupBox1.Controls.Add(this.txtEndLat);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbStartLongHemi);
            this.groupBox1.Controls.Add(this.txtStartLong);
            this.groupBox1.Controls.Add(this.cmbStartLatHemi);
            this.groupBox1.Controls.Add(this.txtStartLat);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inputs";
            // 
            // cmbEndLongHemi
            // 
            this.cmbEndLongHemi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndLongHemi.FormattingEnabled = true;
            this.cmbEndLongHemi.Location = new System.Drawing.Point(420, 44);
            this.cmbEndLongHemi.Name = "cmbEndLongHemi";
            this.cmbEndLongHemi.Size = new System.Drawing.Size(121, 21);
            this.cmbEndLongHemi.TabIndex = 9;
            // 
            // txtEndLong
            // 
            this.txtEndLong.Location = new System.Drawing.Point(314, 44);
            this.txtEndLong.Name = "txtEndLong";
            this.txtEndLong.Size = new System.Drawing.Size(100, 20);
            this.txtEndLong.TabIndex = 8;
            // 
            // cmbEndLatHemi
            // 
            this.cmbEndLatHemi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndLatHemi.FormattingEnabled = true;
            this.cmbEndLatHemi.Location = new System.Drawing.Point(187, 44);
            this.cmbEndLatHemi.Name = "cmbEndLatHemi";
            this.cmbEndLatHemi.Size = new System.Drawing.Size(121, 21);
            this.cmbEndLatHemi.TabIndex = 7;
            // 
            // txtEndLat
            // 
            this.txtEndLat.Location = new System.Drawing.Point(81, 44);
            this.txtEndLat.Name = "txtEndLat";
            this.txtEndLat.Size = new System.Drawing.Size(100, 20);
            this.txtEndLat.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "End Position";
            // 
            // cmbStartLongHemi
            // 
            this.cmbStartLongHemi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartLongHemi.FormattingEnabled = true;
            this.cmbStartLongHemi.Location = new System.Drawing.Point(420, 16);
            this.cmbStartLongHemi.Name = "cmbStartLongHemi";
            this.cmbStartLongHemi.Size = new System.Drawing.Size(121, 21);
            this.cmbStartLongHemi.TabIndex = 4;
            // 
            // txtStartLong
            // 
            this.txtStartLong.Location = new System.Drawing.Point(314, 16);
            this.txtStartLong.Name = "txtStartLong";
            this.txtStartLong.Size = new System.Drawing.Size(100, 20);
            this.txtStartLong.TabIndex = 3;
            // 
            // cmbStartLatHemi
            // 
            this.cmbStartLatHemi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartLatHemi.FormattingEnabled = true;
            this.cmbStartLatHemi.Location = new System.Drawing.Point(187, 16);
            this.cmbStartLatHemi.Name = "cmbStartLatHemi";
            this.cmbStartLatHemi.Size = new System.Drawing.Size(121, 21);
            this.cmbStartLatHemi.TabIndex = 2;
            // 
            // txtStartLat
            // 
            this.txtStartLat.Location = new System.Drawing.Point(81, 16);
            this.txtStartLat.Name = "txtStartLat";
            this.txtStartLat.Size = new System.Drawing.Size(100, 20);
            this.txtStartLat.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Position";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(199, 98);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(280, 98);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblOutVert2);
            this.groupBox2.Controls.Add(this.lblOutVert1);
            this.groupBox2.Controls.Add(this.lblOutCourse);
            this.groupBox2.Controls.Add(this.lblOutDist);
            this.groupBox2.Location = new System.Drawing.Point(12, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(551, 78);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Outputs";
            // 
            // lblOutVert2
            // 
            this.lblOutVert2.AutoSize = true;
            this.lblOutVert2.Location = new System.Drawing.Point(39, 55);
            this.lblOutVert2.Name = "lblOutVert2";
            this.lblOutVert2.Size = new System.Drawing.Size(52, 13);
            this.lblOutVert2.TabIndex = 3;
            this.lblOutVert2.Text = "Vertex 2: ";
            // 
            // lblOutVert1
            // 
            this.lblOutVert1.AutoSize = true;
            this.lblOutVert1.Location = new System.Drawing.Point(39, 42);
            this.lblOutVert1.Name = "lblOutVert1";
            this.lblOutVert1.Size = new System.Drawing.Size(52, 13);
            this.lblOutVert1.TabIndex = 2;
            this.lblOutVert1.Text = "Vertex 1: ";
            // 
            // lblOutCourse
            // 
            this.lblOutCourse.AutoSize = true;
            this.lblOutCourse.Location = new System.Drawing.Point(18, 29);
            this.lblOutCourse.Name = "lblOutCourse";
            this.lblOutCourse.Size = new System.Drawing.Size(73, 13);
            this.lblOutCourse.TabIndex = 1;
            this.lblOutCourse.Text = "Initial Course: ";
            // 
            // lblOutDist
            // 
            this.lblOutDist.AutoSize = true;
            this.lblOutDist.Location = new System.Drawing.Point(9, 16);
            this.lblOutDist.Name = "lblOutDist";
            this.lblOutDist.Size = new System.Drawing.Size(82, 13);
            this.lblOutDist.TabIndex = 0;
            this.lblOutDist.Text = "Total Distance: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 211);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Great Circle Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbEndLongHemi;
        private System.Windows.Forms.TextBox txtEndLong;
        private System.Windows.Forms.ComboBox cmbEndLatHemi;
        private System.Windows.Forms.TextBox txtEndLat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStartLongHemi;
        private System.Windows.Forms.TextBox txtStartLong;
        private System.Windows.Forms.ComboBox cmbStartLatHemi;
        private System.Windows.Forms.TextBox txtStartLat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblOutVert2;
        private System.Windows.Forms.Label lblOutVert1;
        private System.Windows.Forms.Label lblOutCourse;
        private System.Windows.Forms.Label lblOutDist;
    }
}

