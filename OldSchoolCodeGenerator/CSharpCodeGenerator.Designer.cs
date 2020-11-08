namespace OldSchoolCodeGenerator
{
    partial class CSharpCodeGenerator
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtStoredProcedures = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCRUD = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtModelClass = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFieldNames = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtView = new System.Windows.Forms.TextBox();
            this.txtArrayLength = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtAJAXScripts = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrepend = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(13, 13);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(81, 28);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtStoredProcedures);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(877, 53);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.groupBox4.Size = new System.Drawing.Size(258, 719);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Stored Procedures";
            // 
            // txtStoredProcedures
            // 
            this.txtStoredProcedures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStoredProcedures.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStoredProcedures.Location = new System.Drawing.Point(3, 23);
            this.txtStoredProcedures.Multiline = true;
            this.txtStoredProcedures.Name = "txtStoredProcedures";
            this.txtStoredProcedures.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStoredProcedures.Size = new System.Drawing.Size(252, 693);
            this.txtStoredProcedures.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCRUD);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(588, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.groupBox3.Size = new System.Drawing.Size(283, 719);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "CRUD";
            // 
            // txtCRUD
            // 
            this.txtCRUD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCRUD.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCRUD.Location = new System.Drawing.Point(3, 23);
            this.txtCRUD.Multiline = true;
            this.txtCRUD.Name = "txtCRUD";
            this.txtCRUD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCRUD.Size = new System.Drawing.Size(277, 693);
            this.txtCRUD.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtModelClass);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(299, 53);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.groupBox2.Size = new System.Drawing.Size(283, 719);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Model Class";
            // 
            // txtModelClass
            // 
            this.txtModelClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtModelClass.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelClass.Location = new System.Drawing.Point(3, 23);
            this.txtModelClass.Multiline = true;
            this.txtModelClass.Name = "txtModelClass";
            this.txtModelClass.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtModelClass.Size = new System.Drawing.Size(277, 693);
            this.txtModelClass.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFieldNames);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(282, 719);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Field Names";
            // 
            // txtFieldNames
            // 
            this.txtFieldNames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFieldNames.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFieldNames.Location = new System.Drawing.Point(3, 23);
            this.txtFieldNames.Multiline = true;
            this.txtFieldNames.Name = "txtFieldNames";
            this.txtFieldNames.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFieldNames.Size = new System.Drawing.Size(276, 693);
            this.txtFieldNames.TabIndex = 4;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtView);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(1141, 53);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.groupBox5.Size = new System.Drawing.Size(297, 719);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "View";
            // 
            // txtView
            // 
            this.txtView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtView.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtView.Location = new System.Drawing.Point(3, 23);
            this.txtView.Multiline = true;
            this.txtView.Name = "txtView";
            this.txtView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtView.Size = new System.Drawing.Size(291, 693);
            this.txtView.TabIndex = 4;
            // 
            // txtArrayLength
            // 
            this.txtArrayLength.Location = new System.Drawing.Point(174, 12);
            this.txtArrayLength.Name = "txtArrayLength";
            this.txtArrayLength.Size = new System.Drawing.Size(54, 22);
            this.txtArrayLength.TabIndex = 15;
            this.txtArrayLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Array Count";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtAJAXScripts);
            this.groupBox6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(1453, 53);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.groupBox6.Size = new System.Drawing.Size(297, 719);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Ajax Scripts";
            // 
            // txtAJAXScripts
            // 
            this.txtAJAXScripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAJAXScripts.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAJAXScripts.Location = new System.Drawing.Point(3, 23);
            this.txtAJAXScripts.Multiline = true;
            this.txtAJAXScripts.Name = "txtAJAXScripts";
            this.txtAJAXScripts.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAJAXScripts.Size = new System.Drawing.Size(291, 693);
            this.txtAJAXScripts.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Prepend";
            // 
            // txtPrepend
            // 
            this.txtPrepend.Location = new System.Drawing.Point(314, 12);
            this.txtPrepend.Name = "txtPrepend";
            this.txtPrepend.Size = new System.Drawing.Size(92, 22);
            this.txtPrepend.TabIndex = 18;
            this.txtPrepend.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CSharpCodeGenerator
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1759, 899);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPrepend);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtArrayLength);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGenerate);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CSharpCodeGenerator";
            this.Text = "CSharp Code Generator";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtStoredProcedures;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtCRUD;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtModelClass;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFieldNames;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtView;
        private System.Windows.Forms.TextBox txtArrayLength;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtAJAXScripts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrepend;
    }
}