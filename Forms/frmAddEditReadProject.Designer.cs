namespace CivilEngineeringManager.Forms
{
    partial class frmAddEditReadProject
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.chxIsSpecCompleted = new System.Windows.Forms.CheckBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.txtProjectType = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.txtProjectCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.tabAdresse = new System.Windows.Forms.TabPage();
            this.tabAdministration = new System.Windows.Forms.TabPage();
            this.dtpConstPermitDate = new System.Windows.Forms.DateTimePicker();
            this.dtpLandBookDate = new System.Windows.Forms.DateTimePicker();
            this.dtpSubdivisionPermitDate = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.txtLandBookBy = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtDeedFolio = new System.Windows.Forms.TextBox();
            this.txtLandBookNum = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtConstPermitNum = new System.Windows.Forms.TextBox();
            this.txtDeedNum = new System.Windows.Forms.TextBox();
            this.txtDeedVolume = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSubdivisionPermitNum = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtLandRegistry = new System.Windows.Forms.TextBox();
            this.tabBloc = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chxIsActive = new System.Windows.Forms.CheckBox();
            this.ctrlAddress1 = new CivilEngineeringManager.Controls.ctrlAddress();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabAdresse.SuspendLayout();
            this.tabAdministration.SuspendLayout();
            this.tabBloc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabAdresse);
            this.tabControl1.Controls.Add(this.tabAdministration);
            this.tabControl1.Controls.Add(this.tabBloc);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(130, 40);
            this.tabControl1.Location = new System.Drawing.Point(12, 51);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1025, 448);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 3;
            // 
            // tabGeneral
            // 
            this.tabGeneral.BackColor = System.Drawing.Color.Honeydew;
            this.tabGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabGeneral.Controls.Add(this.chxIsSpecCompleted);
            this.tabGeneral.Controls.Add(this.dtpStartDate);
            this.tabGeneral.Controls.Add(this.label26);
            this.tabGeneral.Controls.Add(this.txtProjectType);
            this.tabGeneral.Controls.Add(this.label5);
            this.tabGeneral.Controls.Add(this.label6);
            this.tabGeneral.Controls.Add(this.txtDuration);
            this.tabGeneral.Controls.Add(this.label4);
            this.tabGeneral.Controls.Add(this.label3);
            this.tabGeneral.Controls.Add(this.label2);
            this.tabGeneral.Controls.Add(this.label1);
            this.tabGeneral.Controls.Add(this.txtProgress);
            this.tabGeneral.Controls.Add(this.txtProjectCode);
            this.tabGeneral.Controls.Add(this.txtName);
            this.tabGeneral.Controls.Add(this.txtDescription);
            this.tabGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabGeneral.Location = new System.Drawing.Point(4, 44);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(1017, 400);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            // 
            // chxIsSpecCompleted
            // 
            this.chxIsSpecCompleted.Location = new System.Drawing.Point(739, 235);
            this.chxIsSpecCompleted.Name = "chxIsSpecCompleted";
            this.chxIsSpecCompleted.Size = new System.Drawing.Size(248, 42);
            this.chxIsSpecCompleted.TabIndex = 41;
            this.chxIsSpecCompleted.Text = "Cahier des charge valide";
            this.chxIsSpecCompleted.UseVisualStyleBackColor = true;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.AllowDrop = true;
            this.dtpStartDate.CustomFormat = "dd-MM-yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(165, 137);
            this.dtpStartDate.MaxDate = new System.DateTime(2999, 11, 21, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(1800, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.RightToLeftLayout = true;
            this.dtpStartDate.Size = new System.Drawing.Size(283, 29);
            this.dtpStartDate.TabIndex = 40;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(556, 27);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(126, 24);
            this.label26.TabIndex = 13;
            this.label26.Text = "Project Type :";
            // 
            // txtProjectType
            // 
            this.txtProjectType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectType.Location = new System.Drawing.Point(689, 25);
            this.txtProjectType.Name = "txtProjectType";
            this.txtProjectType.Size = new System.Drawing.Size(298, 29);
            this.txtProjectType.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(592, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 24);
            this.label5.TabIndex = 11;
            this.label5.Text = "Duration :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "Start date :";
            // 
            // txtDuration
            // 
            this.txtDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuration.Location = new System.Drawing.Point(689, 137);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(298, 29);
            this.txtDuration.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Description :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(567, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Progress % :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Project Code :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name :";
            // 
            // txtProgress
            // 
            this.txtProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProgress.Location = new System.Drawing.Point(689, 81);
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.Size = new System.Drawing.Size(298, 29);
            this.txtProgress.TabIndex = 3;
            // 
            // txtProjectCode
            // 
            this.txtProjectCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjectCode.Location = new System.Drawing.Point(165, 81);
            this.txtProjectCode.Name = "txtProjectCode";
            this.txtProjectCode.Size = new System.Drawing.Size(283, 29);
            this.txtProjectCode.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(165, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(283, 29);
            this.txtName.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(165, 193);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(525, 84);
            this.txtDescription.TabIndex = 0;
            // 
            // tabAdresse
            // 
            this.tabAdresse.BackColor = System.Drawing.Color.Lavender;
            this.tabAdresse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabAdresse.Controls.Add(this.ctrlAddress1);
            this.tabAdresse.Location = new System.Drawing.Point(4, 44);
            this.tabAdresse.Name = "tabAdresse";
            this.tabAdresse.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdresse.Size = new System.Drawing.Size(1018, 446);
            this.tabAdresse.TabIndex = 1;
            this.tabAdresse.Text = "Adresse";
            // 
            // tabAdministration
            // 
            this.tabAdministration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabAdministration.Controls.Add(this.dtpConstPermitDate);
            this.tabAdministration.Controls.Add(this.dtpLandBookDate);
            this.tabAdministration.Controls.Add(this.dtpSubdivisionPermitDate);
            this.tabAdministration.Controls.Add(this.label21);
            this.tabAdministration.Controls.Add(this.txtLandBookBy);
            this.tabAdministration.Controls.Add(this.label22);
            this.tabAdministration.Controls.Add(this.label23);
            this.tabAdministration.Controls.Add(this.label24);
            this.tabAdministration.Controls.Add(this.txtDeedFolio);
            this.tabAdministration.Controls.Add(this.txtLandBookNum);
            this.tabAdministration.Controls.Add(this.label13);
            this.tabAdministration.Controls.Add(this.label16);
            this.tabAdministration.Controls.Add(this.label19);
            this.tabAdministration.Controls.Add(this.label20);
            this.tabAdministration.Controls.Add(this.txtConstPermitNum);
            this.tabAdministration.Controls.Add(this.txtDeedNum);
            this.tabAdministration.Controls.Add(this.txtDeedVolume);
            this.tabAdministration.Controls.Add(this.label14);
            this.tabAdministration.Controls.Add(this.txtSubdivisionPermitNum);
            this.tabAdministration.Controls.Add(this.label17);
            this.tabAdministration.Controls.Add(this.label18);
            this.tabAdministration.Controls.Add(this.txtLandRegistry);
            this.tabAdministration.Location = new System.Drawing.Point(4, 44);
            this.tabAdministration.Name = "tabAdministration";
            this.tabAdministration.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdministration.Size = new System.Drawing.Size(1018, 446);
            this.tabAdministration.TabIndex = 2;
            this.tabAdministration.Text = "Administration";
            // 
            // dtpConstPermitDate
            // 
            this.dtpConstPermitDate.AllowDrop = true;
            this.dtpConstPermitDate.CustomFormat = "dd-MM-yyyy";
            this.dtpConstPermitDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpConstPermitDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpConstPermitDate.Location = new System.Drawing.Point(365, 115);
            this.dtpConstPermitDate.MaxDate = new System.DateTime(2999, 11, 21, 0, 0, 0, 0);
            this.dtpConstPermitDate.MinDate = new System.DateTime(1800, 12, 31, 0, 0, 0, 0);
            this.dtpConstPermitDate.Name = "dtpConstPermitDate";
            this.dtpConstPermitDate.RightToLeftLayout = true;
            this.dtpConstPermitDate.Size = new System.Drawing.Size(260, 29);
            this.dtpConstPermitDate.TabIndex = 41;
            // 
            // dtpLandBookDate
            // 
            this.dtpLandBookDate.AllowDrop = true;
            this.dtpLandBookDate.CustomFormat = "dd-MM-yyyy";
            this.dtpLandBookDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpLandBookDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLandBookDate.Location = new System.Drawing.Point(719, 187);
            this.dtpLandBookDate.Name = "dtpLandBookDate";
            this.dtpLandBookDate.RightToLeftLayout = true;
            this.dtpLandBookDate.Size = new System.Drawing.Size(260, 29);
            this.dtpLandBookDate.TabIndex = 40;
            // 
            // dtpSubdivisionPermitDate
            // 
            this.dtpSubdivisionPermitDate.AllowDrop = true;
            this.dtpSubdivisionPermitDate.CustomFormat = "dd-MM-yyyy";
            this.dtpSubdivisionPermitDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpSubdivisionPermitDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSubdivisionPermitDate.Location = new System.Drawing.Point(18, 187);
            this.dtpSubdivisionPermitDate.MaxDate = new System.DateTime(2999, 11, 21, 0, 0, 0, 0);
            this.dtpSubdivisionPermitDate.MinDate = new System.DateTime(1800, 12, 31, 0, 0, 0, 0);
            this.dtpSubdivisionPermitDate.Name = "dtpSubdivisionPermitDate";
            this.dtpSubdivisionPermitDate.RightToLeftLayout = true;
            this.dtpSubdivisionPermitDate.Size = new System.Drawing.Size(260, 29);
            this.dtpSubdivisionPermitDate.TabIndex = 39;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(719, 13);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(103, 24);
            this.label21.TabIndex = 38;
            this.label21.Text = "Deed Folio";
            // 
            // txtLandBookBy
            // 
            this.txtLandBookBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLandBookBy.Location = new System.Drawing.Point(719, 259);
            this.txtLandBookBy.Name = "txtLandBookBy";
            this.txtLandBookBy.Size = new System.Drawing.Size(260, 29);
            this.txtLandBookBy.TabIndex = 37;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(719, 85);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(170, 24);
            this.label22.TabIndex = 36;
            this.label22.Text = "Land book number";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(719, 230);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(125, 24);
            this.label23.TabIndex = 35;
            this.label23.Text = "Land book By";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(719, 158);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(140, 24);
            this.label24.TabIndex = 34;
            this.label24.Text = "Land book date";
            // 
            // txtDeedFolio
            // 
            this.txtDeedFolio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeedFolio.Location = new System.Drawing.Point(719, 43);
            this.txtDeedFolio.Name = "txtDeedFolio";
            this.txtDeedFolio.Size = new System.Drawing.Size(260, 29);
            this.txtDeedFolio.TabIndex = 33;
            // 
            // txtLandBookNum
            // 
            this.txtLandBookNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLandBookNum.Location = new System.Drawing.Point(719, 115);
            this.txtLandBookNum.Name = "txtLandBookNum";
            this.txtLandBookNum.Size = new System.Drawing.Size(260, 29);
            this.txtLandBookNum.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(365, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(213, 24);
            this.label13.TabIndex = 30;
            this.label13.Text = "Construction permit date";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(365, 158);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(127, 24);
            this.label16.TabIndex = 28;
            this.label16.Text = "Deed Volume";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(365, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(243, 24);
            this.label19.TabIndex = 27;
            this.label19.Text = "Construction permit number";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(365, 230);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(130, 24);
            this.label20.TabIndex = 26;
            this.label20.Text = "Deed Number";
            // 
            // txtConstPermitNum
            // 
            this.txtConstPermitNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConstPermitNum.Location = new System.Drawing.Point(365, 43);
            this.txtConstPermitNum.Name = "txtConstPermitNum";
            this.txtConstPermitNum.Size = new System.Drawing.Size(260, 29);
            this.txtConstPermitNum.TabIndex = 25;
            // 
            // txtDeedNum
            // 
            this.txtDeedNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeedNum.Location = new System.Drawing.Point(365, 259);
            this.txtDeedNum.Name = "txtDeedNum";
            this.txtDeedNum.Size = new System.Drawing.Size(260, 29);
            this.txtDeedNum.TabIndex = 24;
            // 
            // txtDeedVolume
            // 
            this.txtDeedVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeedVolume.Location = new System.Drawing.Point(365, 187);
            this.txtDeedVolume.Name = "txtDeedVolume";
            this.txtDeedVolume.Size = new System.Drawing.Size(260, 29);
            this.txtDeedVolume.TabIndex = 23;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(18, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(235, 24);
            this.label14.TabIndex = 22;
            this.label14.Text = "Subdivision permit number";
            // 
            // txtSubdivisionPermitNum
            // 
            this.txtSubdivisionPermitNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubdivisionPermitNum.Location = new System.Drawing.Point(18, 115);
            this.txtSubdivisionPermitNum.Name = "txtSubdivisionPermitNum";
            this.txtSubdivisionPermitNum.Size = new System.Drawing.Size(260, 29);
            this.txtSubdivisionPermitNum.TabIndex = 20;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(14, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(117, 24);
            this.label17.TabIndex = 17;
            this.label17.Text = "Land registry";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(18, 157);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(205, 24);
            this.label18.TabIndex = 16;
            this.label18.Text = "Subdivision permit date";
            // 
            // txtLandRegistry
            // 
            this.txtLandRegistry.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLandRegistry.Location = new System.Drawing.Point(18, 43);
            this.txtLandRegistry.Name = "txtLandRegistry";
            this.txtLandRegistry.Size = new System.Drawing.Size(260, 29);
            this.txtLandRegistry.TabIndex = 13;
            // 
            // tabBloc
            // 
            this.tabBloc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabBloc.Controls.Add(this.label7);
            this.tabBloc.Controls.Add(this.label8);
            this.tabBloc.Controls.Add(this.textBox7);
            this.tabBloc.Controls.Add(this.textBox8);
            this.tabBloc.Controls.Add(this.label9);
            this.tabBloc.Controls.Add(this.label10);
            this.tabBloc.Controls.Add(this.label11);
            this.tabBloc.Controls.Add(this.label12);
            this.tabBloc.Controls.Add(this.textBox9);
            this.tabBloc.Controls.Add(this.textBox10);
            this.tabBloc.Controls.Add(this.textBox11);
            this.tabBloc.Controls.Add(this.textBox12);
            this.tabBloc.Location = new System.Drawing.Point(4, 44);
            this.tabBloc.Name = "tabBloc";
            this.tabBloc.Padding = new System.Windows.Forms.Padding(3);
            this.tabBloc.Size = new System.Drawing.Size(1018, 446);
            this.tabBloc.TabIndex = 3;
            this.tabBloc.Text = "Bloc";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(742, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 24);
            this.label7.TabIndex = 35;
            this.label7.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(156, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 24);
            this.label8.TabIndex = 34;
            this.label8.Text = "label8";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(824, 128);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(83, 29);
            this.textBox7.TabIndex = 33;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(233, 128);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(108, 29);
            this.textBox8.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(159, 224);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 24);
            this.label9.TabIndex = 31;
            this.label9.Text = "label9";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(745, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 24);
            this.label10.TabIndex = 30;
            this.label10.Text = "label10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(159, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 24);
            this.label11.TabIndex = 29;
            this.label11.Text = "label11";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(159, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 24);
            this.label12.TabIndex = 28;
            this.label12.Text = "label12";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(827, 74);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(83, 29);
            this.textBox9.TabIndex = 27;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(236, 74);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(108, 29);
            this.textBox10.TabIndex = 26;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(236, 24);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(674, 29);
            this.textBox11.TabIndex = 25;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(236, 192);
            this.textBox12.Multiline = true;
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(674, 84);
            this.textBox12.TabIndex = 24;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(661, 430);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(144, 43);
            this.btnClose.TabIndex = 44;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(868, 430);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(144, 43);
            this.btnSave.TabIndex = 43;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chxIsActive
            // 
            this.chxIsActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chxIsActive.AutoSize = true;
            this.chxIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chxIsActive.Location = new System.Drawing.Point(947, 12);
            this.chxIsActive.Name = "chxIsActive";
            this.chxIsActive.Size = new System.Drawing.Size(93, 28);
            this.chxIsActive.TabIndex = 45;
            this.chxIsActive.Text = "IsActive";
            this.chxIsActive.UseVisualStyleBackColor = true;
            // 
            // ctrlAddress1
            // 
            this.ctrlAddress1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddress1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlAddress1.Location = new System.Drawing.Point(3, 3);
            this.ctrlAddress1.Margin = new System.Windows.Forms.Padding(6);
            this.ctrlAddress1.Name = "ctrlAddress1";
            this.ctrlAddress1.Size = new System.Drawing.Size(1010, 438);
            this.ctrlAddress1.TabIndex = 0;
            // 
            // frmAddEditReadProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 502);
            this.Controls.Add(this.chxIsActive);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddEditReadProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddEditReadProject";
            this.Load += new System.EventHandler(this.frmAddEditReadProject_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabAdresse.ResumeLayout(false);
            this.tabAdministration.ResumeLayout(false);
            this.tabAdministration.PerformLayout();
            this.tabBloc.ResumeLayout(false);
            this.tabBloc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.CheckBox chxIsSpecCompleted;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtProjectType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.TextBox txtProjectCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TabPage tabAdministration;
        private System.Windows.Forms.DateTimePicker dtpLandBookDate;
        private System.Windows.Forms.DateTimePicker dtpSubdivisionPermitDate;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtLandBookBy;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtDeedFolio;
        private System.Windows.Forms.TextBox txtLandBookNum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtConstPermitNum;
        private System.Windows.Forms.TextBox txtDeedNum;
        private System.Windows.Forms.TextBox txtDeedVolume;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSubdivisionPermitNum;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtLandRegistry;
        private System.Windows.Forms.TabPage tabBloc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tabAdresse;
        private Controls.ctrlAddress ctrlAddress1;
        private System.Windows.Forms.CheckBox chxIsActive;
        private System.Windows.Forms.DateTimePicker dtpConstPermitDate;
    }
}