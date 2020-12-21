using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

//Revision 7/14/2020 - Version 1.3 - Fixed bug with misspelling of "Southern Yellow Pine" when analyzing 6x6 columns. Added additional note on textfile output indicating if Bending/Comp value is a pass or fail value
//Revision 7/31/2020 - Version 1.4 - Failed to include updated to form when SL or RL controlled in Load combo 16-10 for Axial Compression. Program now prints both to form and to text file the correct load combo at load combination 16-10 
// - Fixed output error where software was always printing Fcprime adjusted for 1.6 LDF to report, now reports controlling Fcprime that determines axial compression load
//Revision 8/25/2020 - Version 1.5 - Built new class for EQ15_4 functions, seperated functions from ProgramSpawnForm to Eq15_4 and MaterialProperties class, added version number onto form that is based upon original production date
//9-6-2020: Added BuildData string to provide accurate build info on printed form, this is a lousy solution, but struggling to understand deterministic methodology in .NET framework 4.6.1
    //For accurate updates to form, will need to update 'BuildData' whenever we are recompiling the program


namespace _2018_NDS_BuiltUp_Column {

    public partial class ProgramSpawnForm : Form {

        public ToolTip FormTip = new ToolTip();

        //Build string for creating design report after hitting print button
        string[] datainfo_str = {"Critical Slenderness: ", "", "Design Axial Compression: ", "Allowed Axial Compression: ", "Compression Load Duration Factor: ", "Axial Compression Critical Load Combination: " , 
            "", "Design Lateral Moment: ", "Allowable Lateral Moment: ", "Lateral Moment Load Duration Factor: ", "Lateral Moment Critical Load Combination: ", "Design Lateral Deflection: ", 
            "Lateral Deflection Performance: ", "","Bending/Compression: ", "Bending/Compression Load Duration Factor: ", "Bending/Compression Critical Load Combination: "};
        double[] datainfo = new double[17];

        public ProgramSpawnForm() {
            InitializeComponent();

            DL_Textbox.Text = "0";
            FL_Textbox.Text = "0";
            SL_Textbox.Text = "0";
            RL_Textbox.Text = "0";
            LateralWind_Textbox.Text = "0";
            LatMoment_Label.Text = "Lateral Moment\n(ft.- lbs)";

            Col_Height.Text = "15";
            Ecc_Combo.Text = "1/6";
            CompBrace_Textbox.Text = "0.5";

            Axial_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Bold | FontStyle.Underline);
            Results_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Bold | FontStyle.Underline);

            Rb_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Bold);
            StrongSolution_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Bold);
            LDF_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Bold);
            LoadComboTitle_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Bold);
            DesignValue_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Bold);
            LoadComboTitle_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Bold);
            AxialComp_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Bold);
            LatMoment_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Bold);
            LatDeflection_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Bold);

            //Set text in tooltips on form
            FormTip.Active = true;
            FormTip.AutoPopDelay = 15000;
            FormTip.InitialDelay = 600;
            FormTip.IsBalloon = true;

            FormTip.SetToolTip(Ecc_Label, "Eccentricity is only applied in the depth axis of the built\nup column. No eccentricity is applied to the column width.");
            FormTip.SetToolTip(WL_Label, "Wind load is only applied to the narrow face of the built-up column.\nWind load is not applied to the wide face of the built-up column.");
            FormTip.SetToolTip(CompBrace_Label, "Bracing is applied to narrow edge of built-up column\n(such as wall sheathing), or to the outside of the plies\n" +
                "(such as fire blocking or sheathing panel blocking).\n\n Use member height for free standing posts.");
            FormTip.SetToolTip(WoodSpeciesListBox, "All species are calculated assuming Visual Grade #2.");
            FormTip.SetToolTip(groupBox1, "Wet service conditions for sawn lumber are defined per section 4.1.4\nof the 2018 NDS, and are required when the moisture content is expected\n" +
                "to exceed 19% at any point during the service life of the structure.\n\nWet service conditions are required for outdoor, exposed scenarios such\nas: supporting deck beams, second " +
                "floor offsets, or columns supporting\nroof overhang.");
            FormTip.SetToolTip(MemberName_Label, "Only needed if you plan to print a design report,\nand would like to distinguish this column from others\nthat have been designed.");
            FormTip.SetToolTip(LatDeflection_Label, "This analysis only considers lateral deflection\ndue to wind load. Eccentric deflection is not\naccounted for.\n\nAdditional analysis may be " +
                "required to consider\ndeflection due to eccentricity.");
            FormTip.SetToolTip(DesignLatDeflection_Label, "Deflection is calculated using the 0.42 wind\nload adjustment published in 2018 IBC Table\n1604.3, footnote f.");
            FormTip.SetToolTip(LatMoment_Label, "This analysis assumes eccentric loading is applied\nto the opposite face of the column as wind load,\nso we do not observe combined eccentric loading\n" +
                "induced moments and bending moments.\n\nAdditional analysis may be required to consider\nlateral moment due to eccentricity.");


            VersionLabel.Text = string.Format(VersionLabel.Text, GlobalVar.MajorV, GlobalVar.MinorV, GlobalVar.BuildMon, GlobalVar.BuildDay);
            VersionLabel.Font = new Font("Microsoft Sans Sarif", 7, FontStyle.Regular);
        }


        
        //Alters tool tip when user changes value
        private void Ecc_Combo_SelectedIndexChanged(object sender, EventArgs e) {
            if (Ecc_Combo.Text == "0")
                FormTip.SetToolTip(Ecc_Combo, "Axial load applied at the center of the built up column depth.");
            else if (Ecc_Combo.Text == "1/6")
                FormTip.SetToolTip(Ecc_Combo, "Eccentricity equal to 1/6 of the built up member depth.");
            else if (Ecc_Combo.Text == "1/4")
                FormTip.SetToolTip(Ecc_Combo, "Eccentricity equal to 1/4 of the built up member depth.");
            else if (Ecc_Combo.Text == "1/2")
                FormTip.SetToolTip(Ecc_Combo, "Eccentricity set to the outside edge of the built up member depth.");
        }


        //Prints design information to a .txt file for user to save design data
        private void PrintButton_Click(object sender, EventArgs e) {

            FormEditor FormChange = new FormEditor();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            DateTime today = DateTime.Today;

            saveFileDialog1.DefaultExt = "*.txt";
            saveFileDialog1.FileName = "Built-Up Column Design_" + today.ToString("MM.dd.yyyy") + ".txt";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                FormChange.PrintFunction(saveFileDialog1.FileName, datainfo_str, datainfo);
            }
        }


        //Exits program, terminates all windows, both hidden and visible
        private void ExitButton_Click(object sender, EventArgs e) {
            Application.Exit();
        }



        //Main function
        private void CalculateButton_Click(object sender, EventArgs e) {

            FormEditor FormChange = new FormEditor();

            //Clears data held within WarningLabel_2 if the user decides to design another member
            WarningLabel_2.Text = "";

            //clears data in dataprint string in case user designs more than one member
            datainfo_str[0] = "Critical Slenderness: ";
            datainfo_str[1] = "";
            datainfo_str[2] = "Design Axial Compression: ";
            datainfo_str[3] = "Allowed Axial Compression: ";
            datainfo_str[4] = "Compression Load Duration Factor: ";
            datainfo_str[5] = "Axial Compression Critical Load Combination: ";
            datainfo_str[6] = "";
            datainfo_str[7] = "Design Lateral Moment: ";
            datainfo_str[8] = "Allowable Lateral Moment: ";
            datainfo_str[9] = "Lateral Moment Load Duration Factor: ";
            datainfo_str[10] = "Lateral Moment Critical Load Combination: ";
            datainfo_str[11] = "Design Lateral Deflection: ";
            datainfo_str[12] = "Lateral Deflection Performance: ";
            datainfo_str[13] = "";
            datainfo_str[14] = "Bending/Compression: ";
            datainfo_str[15] = "Bending/Compression Load Duration Factor: ";
            datainfo_str[16] = "Bending/Compression Critical Load Combination: ";


            //Performs check to verify wet service conditions are allowable on the chosen wood species, exits function if use chooses incorrect wood species
            if (Yes_Radio.Checked == true && (WoodSpeciesListBox.Text == "Douglas Fir" || WoodSpeciesListBox.Text == "Spruce Pine Fir")) {
                WarningLabel_1.Text = "This species of wood is not compatible for outdoor, wet use. Please select another wood species that is approved for exterior use.";
                FormChange.NaNFill();
                return;
            }


            //Data check to ensure user selects an option in each list box, prevent program from throwing an out of range exception. Exits function if user fails to input a choice
            if (WoodSpeciesListBox.SelectedIndex == -1) {
                WarningLabel_1.Text = "Please select an option in the wood species box.";
                FormChange.NaNFill();
                return;
            }
            if (ProductSizeBox.SelectedIndex == -1) {
                WarningLabel_1.Text = "Please select an option in the product size box.";
                FormChange.NaNFill();
                return;
            }
            if (PliesBox.SelectedIndex == -1) {
                WarningLabel_1.Text = "Please select an option for the number of plies.";
                FormChange.NaNFill();
                return;
            }

            double Col_Hgt, DL, FL, SL, RL, Lat_WL, CompBrace, Ecc, width, depth;

            //Parses user input loading data, verifies as double and stores locally
            Col_Hgt = FormChange.TextParse(Col_Height.Text, "column height");
            if (Col_Hgt < 0)
                return;
            DL = FormChange.TextParse(DL_Textbox.Text, "axial dead load");
            if (DL < 0)
                return;
            FL = FormChange.TextParse(FL_Textbox.Text, "axial floor live load");
            if (FL < 0)
                return;
            SL = FormChange.TextParse(SL_Textbox.Text, "axial snow load");
            if (SL < 0)
                return;
            RL = FormChange.TextParse(RL_Textbox.Text, "axial roof live load");
            if (RL < 0)
                return;
            Lat_WL = FormChange.TextParse(LateralWind_Textbox.Text, "lateral wind load");
            if (Lat_WL < 0)
                return;
            CompBrace = FormChange.TextParse(CompBrace_Textbox.Text, "weak axis compression bracing");
            if (CompBrace < 0)
                return;

            //Convert ft. to in. for analysis
            CompBrace = CompBrace * 12;

            //result stores string split by Split function, temp1 acts as the delimiter that splits the string
            string[] result;
            string[] temp1 = { "x" };

            result = ProductSizeBox.Text.Split(temp1, StringSplitOptions.None);

            //Converts user input nominal size into actual product size, per table 1A of NDS Supplement
            //Check Table 1B of 2018 supplement for additional info
            if (ProductSizeBox.Text[0] == '2' || ProductSizeBox.Text[0] == '4' || ProductSizeBox.Text[0] == '6' || ProductSizeBox.Text[0] == '8')
                width = Convert.ToDouble(result[0]) - 0.5;
            //else if (ProductSizeBox.Text[0] == '8')
            //    width = Convert.ToDouble(result[0]) - 0.75;
            else
                width = 0;

            //Check Table 1B of 2018 supplement for additional info
            if (ProductSizeBox.Text[0] == '6' || ProductSizeBox.Text[0] == '8')
                depth = Convert.ToDouble(result[1]) - 0.5;
            //For dimension lumber 2"-4" thick, with depth <= 6"
            else if ((ProductSizeBox.Text[2] == '2' || ProductSizeBox.Text[2] == '4' || ProductSizeBox.Text[2] == '6') && (ProductSizeBox.Text[0] == '2' || ProductSizeBox.Text[0] == '4'))
                depth = Convert.ToDouble(result[1]) - 0.5;
            //For dimension lumber 2"-4" thick, with depth > 6"
            else if (ProductSizeBox.Text[2] == '8' && (ProductSizeBox.Text[0] == '2' || ProductSizeBox.Text[0] == '4'))
                depth = Convert.ToDouble(result[1]) - 0.75;
            else
                depth = 0;


            //Defines new class and fills data in class with ClassBuilder function call
            MaterialProperties StudData = new MaterialProperties();
            StudData.ClassBuilder(StudData, width, depth, PliesBox.Text);

            //Define new class to determine characteristics of Eq 15.4-1
            Eq15_4 eq15_4 = new Eq15_4();

            //Calculate eccentricity on the built up column
            if (Ecc_Combo.Text == "0")
                Ecc = 0 * StudData.Dep;
            else if (Ecc_Combo.Text == "1/6")
                Ecc = (double)1 / 6 * StudData.Dep;
            else if (Ecc_Combo.Text == "1/4")
                Ecc = (double)1 / 4 * StudData.Dep;
            else if (Ecc_Combo.Text == "1/2")
                Ecc = (double)1 / 2 * StudData.Dep;
            else
                Ecc = 0;

            //Variables to be returned by the slenderness function
            double Rb1 = 0, Le1 = 0, Le2 = 0;

            double Rb2 = eq15_4.SlendernessCheck(Col_Hgt, CompBrace, StudData, out Le1, out Le2, out Rb1);

            //Update for critical slenderness to print to form
            if (Rb2 > Rb1)
                Rb1 = Rb2;

            //Double check slenderness for unbraced axial load column conditions
            if ((Col_Hgt * 12 / StudData.Dep) > Rb1)
                Rb1 = Col_Hgt * 12 / StudData.Dep;
            if ((CompBrace / (StudData.Wid * StudData.Plies)) > Rb1)
                Rb1 = CompBrace / (StudData.Wid * StudData.Plies);

            //TempCompChk is used to check current load combo against previous load combos for max compression check, Fbprime is used to compare allowable moment to design moment in lat/mom function
            double LDF = 0, CompChk = 0, TempCompChk, Lat_Def = 0, Lat_Mom_Ratio = 0, Temp_Mom_Ratio, Fbprime, Fcprime, Design_LatMom, Allow_LatMom;

            //Calcs lateral deflection due to wind loading, adjust wind load based on IBC Table 1604.3, footnote f
            Lat_Def = StudData.Lat_Defl(StudData, 0.42 * Lat_WL, Col_Hgt);

            //IBC Load Combo 16-8
            double Strong_15_4 = eq15_4.BendingCheckStrong(StudData, DL, 0 * FL, 0 * SL, 0 * RL, 0 * Lat_WL, Col_Hgt, Ecc, Le1, Le2, CompBrace, out LDF, out Fbprime, out Fcprime, out CompChk);
            LoadComboStrong_Label.Text = "1.0 DL";
            AxialComp_LoadCombo.Text = "1.0 DL";
            AxialLDF_Label.Text = "0.90";

            datainfo[2] = DL;
            datainfo[3] = Fcprime * StudData.Dep * StudData.Wid * StudData.Plies;
            datainfo[4] = 0.90;
            datainfo_str[5] = datainfo_str[5] + " 1.0 DL";

            datainfo[7] = 0;
            datainfo[8] = 0;
            datainfo[9] = 0.90;
            datainfo_str[10] = datainfo_str[10] + " 1.0 DL";

            datainfo[14] = Strong_15_4;
            datainfo[15] = 0.90;
            datainfo_str[16] = datainfo_str[16] + " 1.0 DL";

            //Warns user for built up column to follow design provisions in Ch. 15 of NDS
            if (StudData.Plies > 1)
                WarningLabel_1.Text = "Warning: Built-up columns must follow the connection provisions outlined in sections 15.3.3 and/or 15.3.4 of the NDS.";

            
            //IBC Load Combo 16-9
            if (eq15_4.BendingCheckStrong(StudData, DL, FL, 0 * SL, 0 * RL, 0 * Lat_WL, Col_Hgt, Ecc, Le1, Le2, CompBrace, out LDF, out Fbprime, out Fcprime, out TempCompChk) > Strong_15_4) {
                Strong_15_4 = eq15_4.BendingCheckStrong(StudData, DL, FL, 0 * SL, 0 * RL, 0 * Lat_WL, Col_Hgt, Ecc, Le1, Le2, CompBrace, out LDF, out Fbprime, out Fcprime, out TempCompChk);
                LoadComboStrong_Label.Text = "1.0 DL + 1.0 FL";
                LDFStrong_Label.Text = LDF.ToString("0.00");

                datainfo[14] = Strong_15_4;
                datainfo[15] = LDF;
                datainfo_str[16] = datainfo_str[16].Substring(0, 53) + " + 1.0 FL";
            }

            if (CompChk < TempCompChk) {
                CompChk = TempCompChk;
                AxialComp_LoadCombo.Text = "1.0 DL + 1.0 FL";
                AxialLDF_Label.Text = "1.00";

                datainfo[2] = DL + FL;
                datainfo[3] = Fcprime * StudData.Dep * StudData.Wid * StudData.Plies;
                datainfo[4] = 1.00;
                datainfo_str[5] = datainfo_str[5].Substring(0, 52) + " + 1.0 FL";
            }
            
            //IBC Load Combo 16-10
            if (eq15_4.BendingCheckStrong(StudData, DL, 0 * FL, SL, RL, 0 * Lat_WL, Col_Hgt, Ecc, Le1, Le2, CompBrace, out LDF, out Fbprime, out Fcprime, out TempCompChk) > Strong_15_4) {
                Strong_15_4 = eq15_4.BendingCheckStrong(StudData, DL, 0 * FL, SL, RL, 0 * Lat_WL, Col_Hgt, Ecc, Le1, Le2, CompBrace, out LDF, out Fbprime, out Fcprime, out TempCompChk);
                LDFStrong_Label.Text = LDF.ToString("0.00");

                datainfo[14] = Strong_15_4;
                datainfo_str[16] = datainfo_str[16].Substring(0, 53) + " + (1.0 SL or 1.0 RL)";
            }

            if (CompChk < TempCompChk) {
                CompChk = TempCompChk;

                if (SL >= RL) {
                    AxialLDF_Label.Text = "1.15";
                    AxialComp_LoadCombo.Text = "1.0 DL + 1.0 SL";
                    LoadComboStrong_Label.Text = "1.0 DL + 1.0 SL";

                    datainfo[2] = DL + SL;
                    datainfo[4] = 1.15;

                    datainfo[15] = 1.15;
                }
                else if (RL > SL) {
                    AxialLDF_Label.Text = "1.25";
                    AxialComp_LoadCombo.Text = "1.0 DL + 1.0 RL";
                    LoadComboStrong_Label.Text = "1.0 DL + 1.0 RL";

                    datainfo[2] = DL + RL;
                    datainfo[4] = 1.25;

                    datainfo[15] = 1.25;
                }
                datainfo[3] = Fcprime * StudData.Dep * StudData.Wid * StudData.Plies;
                datainfo_str[5] = datainfo_str[5].Substring(0, 52) + " + (1.0 SL or 1.0 RL)";
            }
            
            //IBC Load Combo 16-11
            if (eq15_4.BendingCheckStrong(StudData, DL, 0.75 * FL, 0.75 * SL, 0.75 * RL, 0 * Lat_WL, Col_Hgt, Ecc, Le1, Le2, CompBrace, out LDF, out Fbprime, out Fcprime, out TempCompChk) > Strong_15_4) {
                Strong_15_4 = eq15_4.BendingCheckStrong(StudData, DL, 0.75 * FL, 0.75 * SL, 0.75 * RL, 0 * Lat_WL, Col_Hgt, Ecc, Le1, Le2, CompBrace, out LDF, out Fbprime, out Fcprime, out TempCompChk);
                LoadComboStrong_Label.Text = "1.0 DL + 0.75 FL + (0.75 SL or 0.75 RL)";
                LDFStrong_Label.Text = LDF.ToString("0.00");

                datainfo[14] = Strong_15_4;
                datainfo_str[16] = datainfo_str[16].Substring(0, 53) + " + 0.75 FL + (0.75 SL or 0.75 RL)";
            }
            if (CompChk < TempCompChk) {
                CompChk = TempCompChk;
                AxialComp_LoadCombo.Text = "1.0 DL + 0.75 FL + (0.75 SL or 0.75 RL)";
                if (SL >= RL) {
                    AxialLDF_Label.Text = "1.15";

                    datainfo[2] = DL + 0.75 * FL + 0.75 * SL;
                    datainfo[4] = 1.15;

                    datainfo[15] = 1.15;
                }
                else if (RL > SL) {
                    AxialLDF_Label.Text = "1.25";

                    datainfo[2] = DL + 0.75 * FL + 0.75 * RL;
                    datainfo[4] = 1.25;

                    datainfo[15] = 1.25;
                }
                datainfo[3] = Fcprime * StudData.Dep * StudData.Wid * StudData.Plies;
                datainfo_str[5] = datainfo_str[5].Substring(0, 52) + " + 0.75 FL + (0.75 SL or 0.75 RL)";
            }

            
            //IBC Load Combo 16-12
            if (eq15_4.BendingCheckStrong(StudData, DL, 0 * FL, 0 * SL, 0 * RL, 0.6 * Lat_WL, Col_Hgt, Ecc, Le1, Le2, CompBrace, out LDF, out Fbprime, out Fcprime, out TempCompChk) > Strong_15_4) {
                Strong_15_4 = eq15_4.BendingCheckStrong(StudData, DL, 0 * FL, 0 * SL, 0 * RL, 0.6 * Lat_WL, Col_Hgt, Ecc, Le1, Le2, CompBrace, out LDF, out Fbprime, out Fcprime, out TempCompChk);
                LoadComboStrong_Label.Text = "1.0 DL + 0.6 WL";
                LDFStrong_Label.Text = LDF.ToString("0.00");

                datainfo[14] = Strong_15_4;
                datainfo[15] = LDF;
                datainfo_str[16] = datainfo_str[16].Substring(0, 53) + " + 0.6 WL";
            }
            if (CompChk < TempCompChk) {
                CompChk = TempCompChk;
                AxialComp_LoadCombo.Text = "1.0 DL + 0.6 WL";
                AxialLDF_Label.Text = "1.60";

                datainfo[2] = DL + 0 * FL + 0 * SL + 0 * RL;
                datainfo[3] = Fcprime * StudData.Dep * StudData.Wid * StudData.Plies;
                datainfo[4] = 1.60;
                datainfo_str[5] = datainfo_str[5].Substring(0, 52) + " + 0.6 WL";
            }
            Temp_Mom_Ratio = StudData.Lat_Moment(StudData, 0.6 * Lat_WL, Col_Hgt, Fbprime, out Design_LatMom, out Allow_LatMom);
            if (Lat_Mom_Ratio < Temp_Mom_Ratio) {
                Lat_Mom_Ratio = Temp_Mom_Ratio;
                LatMomentLDF_Label.Text = "1.60";
                LatMoment_LoadCombo.Text = "1.0 DL + 0.6 WL";

                datainfo[7] = Design_LatMom;
                datainfo[8] = Allow_LatMom;
                datainfo[9] = 1.60;
                datainfo_str[10] = datainfo_str[10].Substring(0, 48) + " + 0.6 WL";
            }

            //IBC Load Combo 16-13
            if (eq15_4.BendingCheckStrong(StudData, DL, 0.75 * FL, 0.75 * SL, 0.75 * RL, 0.6 * 0.75 * Lat_WL, Col_Hgt, Ecc, Le1, Le2, CompBrace, out LDF, out Fbprime, out Fcprime, out TempCompChk) > Strong_15_4) {
                Strong_15_4 = eq15_4.BendingCheckStrong(StudData, DL, 0.75 * FL, 0.75 * SL, 0.75 * RL, 0.6 * 0.75 * Lat_WL, Col_Hgt, Ecc, Le1, Le2, CompBrace, out LDF, out Fbprime, out Fcprime, out TempCompChk);
                LoadComboStrong_Label.Text = "1.0 DL + 0.45 WL + 0.75 FL + (0.75 SL or 0.75 RL)";
                LDFStrong_Label.Text = LDF.ToString("0.00");

                datainfo[14] = Strong_15_4;
                datainfo[15] = LDF;
                datainfo_str[16] = datainfo_str[16].Substring(0,53) + " + 0.45 WL + 0.75 FL + (0.75 SL or 0.75 RL)";
            }
            if (CompChk < TempCompChk) {
                CompChk = TempCompChk;
                AxialComp_LoadCombo.Text = "1.0 DL + 0.45 WL + 0.75 FL + (0.75 SL or 0.75 RL)";
                AxialLDF_Label.Text = "1.60";

                if (SL >= RL)
                    datainfo[2] = DL + 0.75 * FL + 0.75 * SL;
                else
                    datainfo[2] = DL + 0.75 * FL + 0.75 * RL;

                datainfo[3] = Fcprime * StudData.Dep * StudData.Wid * StudData.Plies;
                datainfo[4] = 1.60;
                datainfo_str[5] = datainfo_str[5].Substring(0, 52) + " + 0.45 WL + 0.75 FL + (0.75 SL or 0.75 RL)";
            }
            Temp_Mom_Ratio = StudData.Lat_Moment(StudData, 0.45 * Lat_WL, Col_Hgt, Fbprime, out Design_LatMom, out Allow_LatMom);
            if (Lat_Mom_Ratio < Temp_Mom_Ratio) {
                Lat_Mom_Ratio = Temp_Mom_Ratio;
                LatMomentLDF_Label.Text = "1.60";
                LatMoment_LoadCombo.Text = "1.0 DL + 0.45 WL + 0.75 FL + (0.75 SL or 0.75 RL)";

                datainfo[7] = Design_LatMom;
                datainfo[8] = Allow_LatMom;
                datainfo[9] = 1.60;
                datainfo_str[10] = datainfo_str[10].Substring(0, 48) + " + 0.45 WL + 0.75 FL + (0.75 SL or 0.75 RL)";
            }

            //IBC Load Combo 16-15            
            if (eq15_4.BendingCheckStrong(StudData, 0.6 * DL, 0 * FL, 0 * SL, 0 * RL, 0.6 * Lat_WL, Col_Hgt, Ecc, Le1, Le2, CompBrace, out LDF, out Fbprime, out Fcprime, out TempCompChk) > Strong_15_4) {
                Strong_15_4 = eq15_4.BendingCheckStrong(StudData, 0.6 * DL, 0 * FL, 0 * SL, 0 * RL, 0.6 * Lat_WL, Col_Hgt, Ecc, Le1, Le2, CompBrace, out LDF, out Fbprime, out Fcprime, out TempCompChk);
                LoadComboStrong_Label.Text = "0.6 DL + 0.6 WL";
                LDFStrong_Label.Text = LDF.ToString("0.00");

                datainfo[14] = Strong_15_4;
                datainfo[15] = LDF;
                datainfo_str[16] = datainfo_str[16].Substring(0, 53) + " 0.6 DL + 0.6 WL";
            }
            if (CompChk < TempCompChk) {
                CompChk = TempCompChk;
                AxialComp_LoadCombo.Text = "0.6 DL + 0.6 WL";
                AxialLDF_Label.Text = "1.60";

                datainfo[2] = 0.6 * DL + 0 * FL + 0 * SL + 0 * RL;
                datainfo[3] = Fcprime * StudData.Dep * StudData.Wid * StudData.Plies;
                datainfo[4] = 1.6;
                datainfo_str[5] = datainfo_str[5].Substring(0, 52) + " 0.6 DL + 0.6 WL";
            }
            Temp_Mom_Ratio = StudData.Lat_Moment(StudData, 0.6 * Lat_WL, Col_Hgt, Fbprime, out Design_LatMom, out Allow_LatMom);
            if (Lat_Mom_Ratio < Temp_Mom_Ratio) {
                Lat_Mom_Ratio = Temp_Mom_Ratio;
                LatMomentLDF_Label.Text = "1.60";
                LatMoment_LoadCombo.Text = "0.6 DL + 0.6 WL";

                datainfo[7] = Design_LatMom;
                datainfo[8] = Allow_LatMom;
                datainfo[9] = 1.60;
                datainfo_str[10] = datainfo_str[10].Substring(0, 48) + " 0.6 DL + 0.6 WL";
            }


            //Print all results to form
            Strong_Eq15_Label.Text = (Strong_15_4 * 100).ToString("0.0") + "%";
            if (Strong_15_4 > 1) {
                Strong_Eq15_Label.ForeColor = Color.Red;
                Strong_Eq15_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Bold);
            }
            else {
                Strong_Eq15_Label.ForeColor = Color.Black;
                Strong_Eq15_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Regular);
            }

            Rb1_Label.Text = Rb1.ToString("0.0") + " (" + (Rb1 * 2).ToString("0.0") + "%)";
            if (Rb1 > 50) {
                Rb1_Label.ForeColor = Color.Red;
                Rb1_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Bold);
            }
            else {
                Rb1_Label.ForeColor = Color.Black;
                Rb1_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Regular);
            }

            //if (Rb2 > 50) {
            //    SlendernessCombo_Label.ForeColor = Color.Red;
            //    SlendernessCombo_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Bold);
            //}
            //else {
            //    SlendernessCombo_Label.ForeColor = Color.Black;
            //    SlendernessCombo_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Regular);
            //}

            CompChkStrong_Label.Text = (CompChk * 100).ToString("0.0") + "%";
            if (CompChk > 1) {
                CompChkStrong_Label.ForeColor = Color.Red;
                CompChkStrong_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Bold);
            }
            else {
                CompChkStrong_Label.ForeColor = Color.Black;
                CompChkStrong_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Regular);
            }

            MomRatio_Label.Text = (Lat_Mom_Ratio * 100).ToString("0.0") + "%";
            if (Lat_Mom_Ratio >= 1.001) {
                MomRatio_Label.ForeColor = Color.Red;
                MomRatio_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Bold);
            }
            else {
                MomRatio_Label.ForeColor = Color.Black;
                MomRatio_Label.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Regular);
            }

            DesignLatDeflection_Label.Text = Lat_Def.ToString("0.00") + " in.";
            LatDeflection_LDF.Text = "L/" + ((Col_Hgt * 12) / Lat_Def).ToString("0");
            if ((Col_Hgt * 12) / Lat_Def < 120) {
                LatDeflection_LDF.ForeColor = Color.Red;
                LatDeflection_LDF.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Bold);
            }
            else {
                LatDeflection_LDF.ForeColor = Color.Black;
                LatDeflection_LDF.Font = new Font("Microsoft Sans Sarif", 8, FontStyle.Regular);
            }


            SlenderLDF_Label.Text = "N/A";
            SlendernessCombo_Label.Text = "N/A";
            LatDeflection_LoadCombo.Text = "N/A";

            //Fill in datainfo struct to allow user to print to text file
            datainfo[0] = Rb1;
            datainfo[1] = 0;

            datainfo[5] = 0;
            datainfo[6] = 0;

            datainfo[10] = 0;
            datainfo[11] = Lat_Def;
            datainfo[12] = 0;
            datainfo_str[12] = datainfo_str[12] + " L/" + ((Col_Hgt * 12) / Lat_Def).ToString("0");
            datainfo[13] = 0;

            datainfo[16] = 0;

            //Final data check to warn user if multi-ply in wet use
            if (Yes_Radio.Checked == true && StudData.Plies > 1)
                WarningLabel_1.Text += "\n\nPrecaution should be used when specifying built-up members in wet service conditions. Water may collect between plies and cause issue with wood decay and/or fastener performance.";

            //Makes print button appear after design
            PrintButton.Visible = true;
        }

    }

    static class GlobalVar {

        //Formatted in: Year, Month, Day
        public static string BuildData = "2020, 12, 20";

        //User defined strings for version number as selected by the coder who performs compiling
        public static string MajorV = "1";
        public static string MinorV = "6";

        //result stores string split by Split function, temp1 acts as the delimiter that splits the string
        static string[] temp1 = { "," };
        static string[] result = ResultCalc(BuildData, temp1);

        //Determines number of months since May 31st, 2020. Will set that date as consideration for original build date
        public static string BuildMon = (((new DateTime(int.Parse(result[0]), int.Parse(result[1]), int.Parse(result[2])).Year - new DateTime(2020, 5, 31).Year) * 12) + new DateTime(int.Parse(result[0]), int.Parse(result[1]), int.Parse(result[2])).Month - new DateTime(2020, 5, 31).Month).ToString();
        public static string BuildDay = new DateTime(int.Parse(result[0]), int.Parse(result[1]), int.Parse(result[2])).Date.ToString("dd");

        public static string[] ResultCalc(string BuildData, string[] temp1)
        {
            string[] resultcalc = BuildData.Split(temp1, StringSplitOptions.None);

            return resultcalc;
        }
    }

}
