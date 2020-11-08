namespace _2018_NDS_BuiltUp_Column {
    partial class ProgramSpawnForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ExitButton = new System.Windows.Forms.Button();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.WoodSpeciesListBox = new System.Windows.Forms.ListBox();
            this.ProductSizeBox = new System.Windows.Forms.ListBox();
            this.ColHgtLabel = new System.Windows.Forms.Label();
            this.DL_Label = new System.Windows.Forms.Label();
            this.FL_Label = new System.Windows.Forms.Label();
            this.SL_Label = new System.Windows.Forms.Label();
            this.RL_Label = new System.Windows.Forms.Label();
            this.PliesBox = new System.Windows.Forms.ListBox();
            this.WL_Label = new System.Windows.Forms.Label();
            this.Ecc_Label = new System.Windows.Forms.Label();
            this.DL_Textbox = new System.Windows.Forms.TextBox();
            this.Ecc_Combo = new System.Windows.Forms.ComboBox();
            this.WarningLabel_1 = new System.Windows.Forms.Label();
            this.FL_Textbox = new System.Windows.Forms.TextBox();
            this.SL_Textbox = new System.Windows.Forms.TextBox();
            this.RL_Textbox = new System.Windows.Forms.TextBox();
            this.Col_Height = new System.Windows.Forms.TextBox();
            this.CompBrace_Label = new System.Windows.Forms.Label();
            this.CompBrace_Textbox = new System.Windows.Forms.TextBox();
            this.LateralWind_Textbox = new System.Windows.Forms.TextBox();
            this.Results_Label = new System.Windows.Forms.Label();
            this.DesignValue_Label = new System.Windows.Forms.Label();
            this.LoadComboTitle_Label = new System.Windows.Forms.Label();
            this.LDF_Label = new System.Windows.Forms.Label();
            this.WoodSpecies_Label = new System.Windows.Forms.Label();
            this.Dimension_Label = new System.Windows.Forms.Label();
            this.Plies_Label = new System.Windows.Forms.Label();
            this.Rb_Label = new System.Windows.Forms.Label();
            this.LDFStrong_Label = new System.Windows.Forms.Label();
            this.Strong_Eq15_Label = new System.Windows.Forms.Label();
            this.Rb1_Label = new System.Windows.Forms.Label();
            this.SlendernessCombo_Label = new System.Windows.Forms.Label();
            this.LoadComboStrong_Label = new System.Windows.Forms.Label();
            this.StrongSolution_Label = new System.Windows.Forms.Label();
            this.Axial_Label = new System.Windows.Forms.Label();
            this.AxialComp_Label = new System.Windows.Forms.Label();
            this.CompChkStrong_Label = new System.Windows.Forms.Label();
            this.AxialComp_LoadCombo = new System.Windows.Forms.Label();
            this.AxialLDF_Label = new System.Windows.Forms.Label();
            this.SlenderLDF_Label = new System.Windows.Forms.Label();
            this.PrintButton = new System.Windows.Forms.Button();
            this.MemberName_Textbox = new System.Windows.Forms.TextBox();
            this.MemberName_Label = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Yes_Radio = new System.Windows.Forms.RadioButton();
            this.No_Radio = new System.Windows.Forms.RadioButton();
            this.WarningLabel_2 = new System.Windows.Forms.Label();
            this.LatMoment_Label = new System.Windows.Forms.Label();
            this.LatMoment_LoadCombo = new System.Windows.Forms.Label();
            this.MomRatio_Label = new System.Windows.Forms.Label();
            this.LatMomentLDF_Label = new System.Windows.Forms.Label();
            this.LatDeflection_Label = new System.Windows.Forms.Label();
            this.LatDeflection_LoadCombo = new System.Windows.Forms.Label();
            this.DesignLatDeflection_Label = new System.Windows.Forms.Label();
            this.LatDeflection_LDF = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(12, 559);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 17;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(547, 559);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(75, 23);
            this.CalculateButton.TabIndex = 15;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // WoodSpeciesListBox
            // 
            this.WoodSpeciesListBox.FormattingEnabled = true;
            this.WoodSpeciesListBox.Items.AddRange(new object[] {
            "Douglas Fir",
            "Spruce Pine Fir",
            "Alaskan Yellow Cedar",
            "Hem Fir",
            "Southern Yellow Pine"});
            this.WoodSpeciesListBox.Location = new System.Drawing.Point(12, 23);
            this.WoodSpeciesListBox.Name = "WoodSpeciesListBox";
            this.WoodSpeciesListBox.Size = new System.Drawing.Size(110, 69);
            this.WoodSpeciesListBox.TabIndex = 1;
            // 
            // ProductSizeBox
            // 
            this.ProductSizeBox.FormattingEnabled = true;
            this.ProductSizeBox.Items.AddRange(new object[] {
            "2x4",
            "2x6",
            "2x8",
            "4x4",
            "4x6",
            "4x8",
            "6x6",
            "6x8",
            "8x8"});
            this.ProductSizeBox.Location = new System.Drawing.Point(137, 23);
            this.ProductSizeBox.Name = "ProductSizeBox";
            this.ProductSizeBox.Size = new System.Drawing.Size(110, 69);
            this.ProductSizeBox.TabIndex = 2;
            // 
            // ColHgtLabel
            // 
            this.ColHgtLabel.Location = new System.Drawing.Point(398, 36);
            this.ColHgtLabel.Name = "ColHgtLabel";
            this.ColHgtLabel.Size = new System.Drawing.Size(120, 13);
            this.ColHgtLabel.TabIndex = 7;
            this.ColHgtLabel.Text = "Column Height (ft)";
            this.ColHgtLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DL_Label
            // 
            this.DL_Label.Location = new System.Drawing.Point(40, 125);
            this.DL_Label.Name = "DL_Label";
            this.DL_Label.Size = new System.Drawing.Size(82, 13);
            this.DL_Label.TabIndex = 8;
            this.DL_Label.Text = "Dead Load (lbs)";
            this.DL_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FL_Label
            // 
            this.FL_Label.Location = new System.Drawing.Point(43, 148);
            this.FL_Label.Name = "FL_Label";
            this.FL_Label.Size = new System.Drawing.Size(79, 13);
            this.FL_Label.TabIndex = 9;
            this.FL_Label.Text = "Floor Load (lbs)";
            this.FL_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SL_Label
            // 
            this.SL_Label.Location = new System.Drawing.Point(39, 171);
            this.SL_Label.Name = "SL_Label";
            this.SL_Label.Size = new System.Drawing.Size(83, 13);
            this.SL_Label.TabIndex = 10;
            this.SL_Label.Text = "Snow Load (lbs)";
            this.SL_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RL_Label
            // 
            this.RL_Label.Location = new System.Drawing.Point(47, 194);
            this.RL_Label.Name = "RL_Label";
            this.RL_Label.Size = new System.Drawing.Size(75, 13);
            this.RL_Label.TabIndex = 11;
            this.RL_Label.Text = "Roof Live (lbs)";
            this.RL_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PliesBox
            // 
            this.PliesBox.FormattingEnabled = true;
            this.PliesBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.PliesBox.Location = new System.Drawing.Point(265, 23);
            this.PliesBox.Name = "PliesBox";
            this.PliesBox.Size = new System.Drawing.Size(110, 69);
            this.PliesBox.TabIndex = 3;
            // 
            // WL_Label
            // 
            this.WL_Label.Location = new System.Drawing.Point(9, 231);
            this.WL_Label.Name = "WL_Label";
            this.WL_Label.Size = new System.Drawing.Size(114, 13);
            this.WL_Label.TabIndex = 13;
            this.WL_Label.Text = "Lateral Wind Load (plf)";
            this.WL_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Ecc_Label
            // 
            this.Ecc_Label.Location = new System.Drawing.Point(456, 83);
            this.Ecc_Label.Name = "Ecc_Label";
            this.Ecc_Label.Size = new System.Drawing.Size(62, 13);
            this.Ecc_Label.TabIndex = 14;
            this.Ecc_Label.Text = "Eccentricity";
            this.Ecc_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DL_Textbox
            // 
            this.DL_Textbox.Location = new System.Drawing.Point(129, 122);
            this.DL_Textbox.Name = "DL_Textbox";
            this.DL_Textbox.Size = new System.Drawing.Size(100, 20);
            this.DL_Textbox.TabIndex = 8;
            this.DL_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Ecc_Combo
            // 
            this.Ecc_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Ecc_Combo.FormattingEnabled = true;
            this.Ecc_Combo.Items.AddRange(new object[] {
            "0",
            "1/6",
            "1/4",
            "1/2"});
            this.Ecc_Combo.Location = new System.Drawing.Point(525, 80);
            this.Ecc_Combo.Name = "Ecc_Combo";
            this.Ecc_Combo.Size = new System.Drawing.Size(69, 21);
            this.Ecc_Combo.TabIndex = 7;
            this.Ecc_Combo.SelectedIndexChanged += new System.EventHandler(this.Ecc_Combo_SelectedIndexChanged);
            // 
            // WarningLabel_1
            // 
            this.WarningLabel_1.Location = new System.Drawing.Point(261, 125);
            this.WarningLabel_1.Name = "WarningLabel_1";
            this.WarningLabel_1.Size = new System.Drawing.Size(360, 86);
            this.WarningLabel_1.TabIndex = 17;
            this.WarningLabel_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FL_Textbox
            // 
            this.FL_Textbox.Location = new System.Drawing.Point(129, 145);
            this.FL_Textbox.Name = "FL_Textbox";
            this.FL_Textbox.Size = new System.Drawing.Size(100, 20);
            this.FL_Textbox.TabIndex = 9;
            this.FL_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SL_Textbox
            // 
            this.SL_Textbox.Location = new System.Drawing.Point(129, 168);
            this.SL_Textbox.Name = "SL_Textbox";
            this.SL_Textbox.Size = new System.Drawing.Size(100, 20);
            this.SL_Textbox.TabIndex = 10;
            this.SL_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RL_Textbox
            // 
            this.RL_Textbox.Location = new System.Drawing.Point(129, 191);
            this.RL_Textbox.Name = "RL_Textbox";
            this.RL_Textbox.Size = new System.Drawing.Size(100, 20);
            this.RL_Textbox.TabIndex = 11;
            this.RL_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Col_Height
            // 
            this.Col_Height.Location = new System.Drawing.Point(525, 33);
            this.Col_Height.Name = "Col_Height";
            this.Col_Height.Size = new System.Drawing.Size(69, 20);
            this.Col_Height.TabIndex = 5;
            this.Col_Height.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CompBrace_Label
            // 
            this.CompBrace_Label.Location = new System.Drawing.Point(395, 59);
            this.CompBrace_Label.Name = "CompBrace_Label";
            this.CompBrace_Label.Size = new System.Drawing.Size(123, 13);
            this.CompBrace_Label.TabIndex = 22;
            this.CompBrace_Label.Text = "Compression Bracing (ft)";
            this.CompBrace_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CompBrace_Textbox
            // 
            this.CompBrace_Textbox.Location = new System.Drawing.Point(525, 56);
            this.CompBrace_Textbox.Name = "CompBrace_Textbox";
            this.CompBrace_Textbox.Size = new System.Drawing.Size(69, 20);
            this.CompBrace_Textbox.TabIndex = 6;
            this.CompBrace_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LateralWind_Textbox
            // 
            this.LateralWind_Textbox.Location = new System.Drawing.Point(129, 228);
            this.LateralWind_Textbox.Name = "LateralWind_Textbox";
            this.LateralWind_Textbox.Size = new System.Drawing.Size(100, 20);
            this.LateralWind_Textbox.TabIndex = 12;
            this.LateralWind_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Results_Label
            // 
            this.Results_Label.AutoSize = true;
            this.Results_Label.Location = new System.Drawing.Point(29, 328);
            this.Results_Label.Name = "Results_Label";
            this.Results_Label.Size = new System.Drawing.Size(42, 13);
            this.Results_Label.TabIndex = 25;
            this.Results_Label.Text = "Results";
            // 
            // DesignValue_Label
            // 
            this.DesignValue_Label.Location = new System.Drawing.Point(124, 328);
            this.DesignValue_Label.Name = "DesignValue_Label";
            this.DesignValue_Label.Size = new System.Drawing.Size(123, 13);
            this.DesignValue_Label.TabIndex = 26;
            this.DesignValue_Label.Text = "Design Allowable";
            this.DesignValue_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadComboTitle_Label
            // 
            this.LoadComboTitle_Label.Location = new System.Drawing.Point(375, 328);
            this.LoadComboTitle_Label.Name = "LoadComboTitle_Label";
            this.LoadComboTitle_Label.Size = new System.Drawing.Size(254, 13);
            this.LoadComboTitle_Label.TabIndex = 27;
            this.LoadComboTitle_Label.Text = "Load Combination";
            this.LoadComboTitle_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LDF_Label
            // 
            this.LDF_Label.Location = new System.Drawing.Point(266, 328);
            this.LDF_Label.Name = "LDF_Label";
            this.LDF_Label.Size = new System.Drawing.Size(93, 13);
            this.LDF_Label.TabIndex = 28;
            this.LDF_Label.Text = "LDF";
            this.LDF_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WoodSpecies_Label
            // 
            this.WoodSpecies_Label.AutoSize = true;
            this.WoodSpecies_Label.Location = new System.Drawing.Point(28, 9);
            this.WoodSpecies_Label.Name = "WoodSpecies_Label";
            this.WoodSpecies_Label.Size = new System.Drawing.Size(77, 13);
            this.WoodSpecies_Label.TabIndex = 30;
            this.WoodSpecies_Label.Text = "Wood Species";
            // 
            // Dimension_Label
            // 
            this.Dimension_Label.AutoSize = true;
            this.Dimension_Label.Location = new System.Drawing.Point(142, 7);
            this.Dimension_Label.Name = "Dimension_Label";
            this.Dimension_Label.Size = new System.Drawing.Size(96, 13);
            this.Dimension_Label.TabIndex = 31;
            this.Dimension_Label.Text = "Product Dimension";
            // 
            // Plies_Label
            // 
            this.Plies_Label.AutoSize = true;
            this.Plies_Label.Location = new System.Drawing.Point(277, 7);
            this.Plies_Label.Name = "Plies_Label";
            this.Plies_Label.Size = new System.Drawing.Size(81, 13);
            this.Plies_Label.TabIndex = 32;
            this.Plies_Label.Text = "Number of Plies";
            // 
            // Rb_Label
            // 
            this.Rb_Label.AutoSize = true;
            this.Rb_Label.Location = new System.Drawing.Point(22, 355);
            this.Rb_Label.Name = "Rb_Label";
            this.Rb_Label.Size = new System.Drawing.Size(65, 13);
            this.Rb_Label.TabIndex = 33;
            this.Rb_Label.Text = "Slenderness";
            // 
            // LDFStrong_Label
            // 
            this.LDFStrong_Label.Location = new System.Drawing.Point(266, 491);
            this.LDFStrong_Label.Name = "LDFStrong_Label";
            this.LDFStrong_Label.Size = new System.Drawing.Size(93, 13);
            this.LDFStrong_Label.TabIndex = 34;
            this.LDFStrong_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Strong_Eq15_Label
            // 
            this.Strong_Eq15_Label.Location = new System.Drawing.Point(121, 491);
            this.Strong_Eq15_Label.Name = "Strong_Eq15_Label";
            this.Strong_Eq15_Label.Size = new System.Drawing.Size(126, 13);
            this.Strong_Eq15_Label.TabIndex = 35;
            this.Strong_Eq15_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Rb1_Label
            // 
            this.Rb1_Label.Location = new System.Drawing.Point(121, 355);
            this.Rb1_Label.Name = "Rb1_Label";
            this.Rb1_Label.Size = new System.Drawing.Size(126, 13);
            this.Rb1_Label.TabIndex = 36;
            this.Rb1_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SlendernessCombo_Label
            // 
            this.SlendernessCombo_Label.Location = new System.Drawing.Point(375, 355);
            this.SlendernessCombo_Label.Name = "SlendernessCombo_Label";
            this.SlendernessCombo_Label.Size = new System.Drawing.Size(254, 13);
            this.SlendernessCombo_Label.TabIndex = 37;
            this.SlendernessCombo_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoadComboStrong_Label
            // 
            this.LoadComboStrong_Label.Location = new System.Drawing.Point(375, 491);
            this.LoadComboStrong_Label.Name = "LoadComboStrong_Label";
            this.LoadComboStrong_Label.Size = new System.Drawing.Size(254, 13);
            this.LoadComboStrong_Label.TabIndex = 38;
            this.LoadComboStrong_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // StrongSolution_Label
            // 
            this.StrongSolution_Label.AutoSize = true;
            this.StrongSolution_Label.Location = new System.Drawing.Point(22, 491);
            this.StrongSolution_Label.Name = "StrongSolution_Label";
            this.StrongSolution_Label.Size = new System.Drawing.Size(56, 13);
            this.StrongSolution_Label.TabIndex = 39;
            this.StrongSolution_Label.Text = "Eq. 15.4-1";
            // 
            // Axial_Label
            // 
            this.Axial_Label.Location = new System.Drawing.Point(34, 104);
            this.Axial_Label.Name = "Axial_Label";
            this.Axial_Label.Size = new System.Drawing.Size(88, 13);
            this.Axial_Label.TabIndex = 40;
            this.Axial_Label.Text = "Axial Load(s)";
            this.Axial_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AxialComp_Label
            // 
            this.AxialComp_Label.Location = new System.Drawing.Point(3, 385);
            this.AxialComp_Label.Name = "AxialComp_Label";
            this.AxialComp_Label.Size = new System.Drawing.Size(113, 13);
            this.AxialComp_Label.TabIndex = 42;
            this.AxialComp_Label.Text = "Axial Compression";
            this.AxialComp_Label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CompChkStrong_Label
            // 
            this.CompChkStrong_Label.Location = new System.Drawing.Point(121, 385);
            this.CompChkStrong_Label.Name = "CompChkStrong_Label";
            this.CompChkStrong_Label.Size = new System.Drawing.Size(126, 13);
            this.CompChkStrong_Label.TabIndex = 43;
            this.CompChkStrong_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AxialComp_LoadCombo
            // 
            this.AxialComp_LoadCombo.Location = new System.Drawing.Point(375, 385);
            this.AxialComp_LoadCombo.Name = "AxialComp_LoadCombo";
            this.AxialComp_LoadCombo.Size = new System.Drawing.Size(254, 13);
            this.AxialComp_LoadCombo.TabIndex = 44;
            this.AxialComp_LoadCombo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AxialLDF_Label
            // 
            this.AxialLDF_Label.Location = new System.Drawing.Point(266, 385);
            this.AxialLDF_Label.Name = "AxialLDF_Label";
            this.AxialLDF_Label.Size = new System.Drawing.Size(93, 13);
            this.AxialLDF_Label.TabIndex = 45;
            this.AxialLDF_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SlenderLDF_Label
            // 
            this.SlenderLDF_Label.Location = new System.Drawing.Point(266, 355);
            this.SlenderLDF_Label.Name = "SlenderLDF_Label";
            this.SlenderLDF_Label.Size = new System.Drawing.Size(93, 13);
            this.SlenderLDF_Label.TabIndex = 46;
            this.SlenderLDF_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(466, 559);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(75, 23);
            this.PrintButton.TabIndex = 16;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Visible = false;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // MemberName_Textbox
            // 
            this.MemberName_Textbox.Location = new System.Drawing.Point(525, 10);
            this.MemberName_Textbox.Name = "MemberName_Textbox";
            this.MemberName_Textbox.Size = new System.Drawing.Size(69, 20);
            this.MemberName_Textbox.TabIndex = 4;
            this.MemberName_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MemberName_Label
            // 
            this.MemberName_Label.Location = new System.Drawing.Point(398, 13);
            this.MemberName_Label.Name = "MemberName_Label";
            this.MemberName_Label.Size = new System.Drawing.Size(120, 13);
            this.MemberName_Label.TabIndex = 48;
            this.MemberName_Label.Text = "Member Name";
            this.MemberName_Label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Yes_Radio);
            this.groupBox1.Controls.Add(this.No_Radio);
            this.groupBox1.Location = new System.Drawing.Point(37, 254);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 56);
            this.groupBox1.TabIndex = 50;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consider Wet Service Conditions For This Column?";
            // 
            // Yes_Radio
            // 
            this.Yes_Radio.AutoSize = true;
            this.Yes_Radio.Location = new System.Drawing.Point(99, 30);
            this.Yes_Radio.Name = "Yes_Radio";
            this.Yes_Radio.Size = new System.Drawing.Size(43, 17);
            this.Yes_Radio.TabIndex = 14;
            this.Yes_Radio.Text = "Yes";
            this.Yes_Radio.UseVisualStyleBackColor = true;
            // 
            // No_Radio
            // 
            this.No_Radio.AutoSize = true;
            this.No_Radio.Checked = true;
            this.No_Radio.Location = new System.Drawing.Point(38, 30);
            this.No_Radio.Name = "No_Radio";
            this.No_Radio.Size = new System.Drawing.Size(39, 17);
            this.No_Radio.TabIndex = 13;
            this.No_Radio.TabStop = true;
            this.No_Radio.Text = "No";
            this.No_Radio.UseVisualStyleBackColor = true;
            // 
            // WarningLabel_2
            // 
            this.WarningLabel_2.Location = new System.Drawing.Point(261, 215);
            this.WarningLabel_2.Name = "WarningLabel_2";
            this.WarningLabel_2.Size = new System.Drawing.Size(360, 86);
            this.WarningLabel_2.TabIndex = 51;
            this.WarningLabel_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LatMoment_Label
            // 
            this.LatMoment_Label.Location = new System.Drawing.Point(3, 413);
            this.LatMoment_Label.Name = "LatMoment_Label";
            this.LatMoment_Label.Size = new System.Drawing.Size(119, 26);
            this.LatMoment_Label.TabIndex = 56;
            this.LatMoment_Label.Text = "Lateral Moment (ft.-lbs)";
            this.LatMoment_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LatMoment_LoadCombo
            // 
            this.LatMoment_LoadCombo.Location = new System.Drawing.Point(375, 422);
            this.LatMoment_LoadCombo.Name = "LatMoment_LoadCombo";
            this.LatMoment_LoadCombo.Size = new System.Drawing.Size(254, 13);
            this.LatMoment_LoadCombo.TabIndex = 55;
            this.LatMoment_LoadCombo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MomRatio_Label
            // 
            this.MomRatio_Label.Location = new System.Drawing.Point(121, 422);
            this.MomRatio_Label.Name = "MomRatio_Label";
            this.MomRatio_Label.Size = new System.Drawing.Size(126, 13);
            this.MomRatio_Label.TabIndex = 54;
            this.MomRatio_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LatMomentLDF_Label
            // 
            this.LatMomentLDF_Label.Location = new System.Drawing.Point(266, 422);
            this.LatMomentLDF_Label.Name = "LatMomentLDF_Label";
            this.LatMomentLDF_Label.Size = new System.Drawing.Size(93, 13);
            this.LatMomentLDF_Label.TabIndex = 53;
            this.LatMomentLDF_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LatDeflection_Label
            // 
            this.LatDeflection_Label.Location = new System.Drawing.Point(3, 447);
            this.LatDeflection_Label.Name = "LatDeflection_Label";
            this.LatDeflection_Label.Size = new System.Drawing.Size(119, 26);
            this.LatDeflection_Label.TabIndex = 61;
            this.LatDeflection_Label.Text = "Lateral Deflection (in.)";
            this.LatDeflection_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LatDeflection_LoadCombo
            // 
            this.LatDeflection_LoadCombo.Location = new System.Drawing.Point(375, 454);
            this.LatDeflection_LoadCombo.Name = "LatDeflection_LoadCombo";
            this.LatDeflection_LoadCombo.Size = new System.Drawing.Size(254, 13);
            this.LatDeflection_LoadCombo.TabIndex = 60;
            this.LatDeflection_LoadCombo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DesignLatDeflection_Label
            // 
            this.DesignLatDeflection_Label.Location = new System.Drawing.Point(121, 454);
            this.DesignLatDeflection_Label.Name = "DesignLatDeflection_Label";
            this.DesignLatDeflection_Label.Size = new System.Drawing.Size(126, 13);
            this.DesignLatDeflection_Label.TabIndex = 59;
            this.DesignLatDeflection_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LatDeflection_LDF
            // 
            this.LatDeflection_LDF.Location = new System.Drawing.Point(266, 454);
            this.LatDeflection_LDF.Name = "LatDeflection_LDF";
            this.LatDeflection_LDF.Size = new System.Drawing.Size(93, 13);
            this.LatDeflection_LDF.TabIndex = 58;
            this.LatDeflection_LDF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(93, 564);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(113, 13);
            this.VersionLabel.TabIndex = 62;
            this.VersionLabel.Text = "Version: {0}.{1}.{2}.{3}";
            // 
            // ProgramSpawnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 593);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.LatDeflection_Label);
            this.Controls.Add(this.LatDeflection_LoadCombo);
            this.Controls.Add(this.DesignLatDeflection_Label);
            this.Controls.Add(this.LatDeflection_LDF);
            this.Controls.Add(this.LatMoment_Label);
            this.Controls.Add(this.LatMoment_LoadCombo);
            this.Controls.Add(this.MomRatio_Label);
            this.Controls.Add(this.LatMomentLDF_Label);
            this.Controls.Add(this.WarningLabel_2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MemberName_Textbox);
            this.Controls.Add(this.MemberName_Label);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.SlenderLDF_Label);
            this.Controls.Add(this.AxialLDF_Label);
            this.Controls.Add(this.AxialComp_LoadCombo);
            this.Controls.Add(this.CompChkStrong_Label);
            this.Controls.Add(this.AxialComp_Label);
            this.Controls.Add(this.Axial_Label);
            this.Controls.Add(this.StrongSolution_Label);
            this.Controls.Add(this.LoadComboStrong_Label);
            this.Controls.Add(this.SlendernessCombo_Label);
            this.Controls.Add(this.Rb1_Label);
            this.Controls.Add(this.Strong_Eq15_Label);
            this.Controls.Add(this.LDFStrong_Label);
            this.Controls.Add(this.Rb_Label);
            this.Controls.Add(this.Plies_Label);
            this.Controls.Add(this.Dimension_Label);
            this.Controls.Add(this.WoodSpecies_Label);
            this.Controls.Add(this.LDF_Label);
            this.Controls.Add(this.LoadComboTitle_Label);
            this.Controls.Add(this.DesignValue_Label);
            this.Controls.Add(this.Results_Label);
            this.Controls.Add(this.LateralWind_Textbox);
            this.Controls.Add(this.CompBrace_Textbox);
            this.Controls.Add(this.CompBrace_Label);
            this.Controls.Add(this.Col_Height);
            this.Controls.Add(this.RL_Textbox);
            this.Controls.Add(this.SL_Textbox);
            this.Controls.Add(this.FL_Textbox);
            this.Controls.Add(this.WarningLabel_1);
            this.Controls.Add(this.Ecc_Combo);
            this.Controls.Add(this.DL_Textbox);
            this.Controls.Add(this.Ecc_Label);
            this.Controls.Add(this.WL_Label);
            this.Controls.Add(this.PliesBox);
            this.Controls.Add(this.RL_Label);
            this.Controls.Add(this.SL_Label);
            this.Controls.Add(this.FL_Label);
            this.Controls.Add(this.DL_Label);
            this.Controls.Add(this.ColHgtLabel);
            this.Controls.Add(this.ProductSizeBox);
            this.Controls.Add(this.WoodSpeciesListBox);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.ExitButton);
            this.Name = "ProgramSpawnForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NDS 2018 Built-Up Column With Lateral Load";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Label ColHgtLabel;
        private System.Windows.Forms.Label DL_Label;
        private System.Windows.Forms.Label FL_Label;
        private System.Windows.Forms.Label SL_Label;
        private System.Windows.Forms.Label RL_Label;
        private System.Windows.Forms.Label WL_Label;
        private System.Windows.Forms.Label Ecc_Label;
        private System.Windows.Forms.Label CompBrace_Label;
        private System.Windows.Forms.Label Results_Label;
        private System.Windows.Forms.Label DesignValue_Label;
        private System.Windows.Forms.Label LoadComboTitle_Label;
        private System.Windows.Forms.Label LDF_Label;
        private System.Windows.Forms.Label WoodSpecies_Label;
        private System.Windows.Forms.Label Dimension_Label;
        private System.Windows.Forms.Label Plies_Label;
        private System.Windows.Forms.Label Rb_Label;
        private System.Windows.Forms.Label StrongSolution_Label;
        private System.Windows.Forms.Label Axial_Label;
        private System.Windows.Forms.Label AxialComp_Label;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Label MemberName_Label;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LatMoment_Label;
        private System.Windows.Forms.Label LatDeflection_Label;
        public System.Windows.Forms.ListBox WoodSpeciesListBox;
        public System.Windows.Forms.RadioButton Yes_Radio;
        public System.Windows.Forms.TextBox CompBrace_Textbox;
        public System.Windows.Forms.Label WarningLabel_2;
        private System.Windows.Forms.Label VersionLabel;
        public System.Windows.Forms.ListBox ProductSizeBox;
        public System.Windows.Forms.ListBox PliesBox;
        public System.Windows.Forms.TextBox DL_Textbox;
        public System.Windows.Forms.ComboBox Ecc_Combo;
        public System.Windows.Forms.TextBox FL_Textbox;
        public System.Windows.Forms.TextBox SL_Textbox;
        public System.Windows.Forms.TextBox RL_Textbox;
        public System.Windows.Forms.TextBox Col_Height;
        public System.Windows.Forms.TextBox LateralWind_Textbox;
        public System.Windows.Forms.Label LDFStrong_Label;
        public System.Windows.Forms.Label Strong_Eq15_Label;
        public System.Windows.Forms.Label Rb1_Label;
        public System.Windows.Forms.Label SlendernessCombo_Label;
        public System.Windows.Forms.Label LoadComboStrong_Label;
        public System.Windows.Forms.Label CompChkStrong_Label;
        public System.Windows.Forms.Label AxialComp_LoadCombo;
        public System.Windows.Forms.Label AxialLDF_Label;
        public System.Windows.Forms.Label SlenderLDF_Label;
        public System.Windows.Forms.TextBox MemberName_Textbox;
        public System.Windows.Forms.Label LatMoment_LoadCombo;
        public System.Windows.Forms.Label MomRatio_Label;
        public System.Windows.Forms.Label LatMomentLDF_Label;
        public System.Windows.Forms.Label LatDeflection_LoadCombo;
        public System.Windows.Forms.Label DesignLatDeflection_Label;
        public System.Windows.Forms.Label LatDeflection_LDF;
        public System.Windows.Forms.Label WarningLabel_1;
        public System.Windows.Forms.RadioButton No_Radio;
    }
}

