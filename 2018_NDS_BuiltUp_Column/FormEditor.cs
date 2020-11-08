using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _2018_NDS_BuiltUp_Column {
    public class FormEditor {

        //Used to reference data from active main 'SpawnForm' that is referenced for analysis
        ProgramSpawnForm FormData = (ProgramSpawnForm)Form.ActiveForm;

        //Returns 'NaN' to calculated boxes if user has invalid input
        public void NaNFill() {
            FormData.LDFStrong_Label.Text = "N/A";
            FormData.Rb1_Label.Text = "N/A";
            FormData.Strong_Eq15_Label.Text = "N/A";
            FormData.LoadComboStrong_Label.Text = "N/A";
            FormData.CompChkStrong_Label.Text = "N/A";
            FormData.AxialLDF_Label.Text = "N/A";
            FormData.SlenderLDF_Label.Text = "N/A";
            FormData.SlendernessCombo_Label.Text = "N/A";
            FormData.AxialComp_LoadCombo.Text = "N/A";
            FormData.MomRatio_Label.Text = "N/A";
            FormData.LatMomentLDF_Label.Text = "N/A";
            FormData.LatMoment_LoadCombo.Text = "N/A";
            FormData.DesignLatDeflection_Label.Text = "N/A";
            FormData.LatDeflection_LDF.Text = "N/A";
            FormData.LatDeflection_LoadCombo.Text = "N/A";
        }


        //Parses user input, converts to double
        public double TextParse(string text, string variable) {
            double a;

            if (double.TryParse(text, out a))
                FormData.WarningLabel_1.Text = "";
            else {
                FormData.WarningLabel_1.Text = ("Please enter a valid number for " + variable + ".");
                NaNFill();
                return -1;
            }

            return a;
        }


        //Builds string and prints to file pathway defined by user
        public void PrintFunction(string pathway, string[] datainfo_str, double[] datainfo) {

            string membername = FormData.MemberName_Textbox.Text;
            string woodspecies = FormData.WoodSpeciesListBox.Text;
            string dimension = FormData.ProductSizeBox.Text;
            string plies = FormData.PliesBox.Text;
            string colheight = FormData.Col_Height.Text;
            string compbrace = FormData.CompBrace_Textbox.Text;
            string ecc = FormData.Ecc_Combo.Text;
            string DL = FormData.DL_Textbox.Text;
            string FL = FormData.FL_Textbox.Text;
            string SL = FormData.SL_Textbox.Text;
            string RL = FormData.RL_Textbox.Text;
            string WL = FormData.LateralWind_Textbox.Text;
            string ServiceCond;
            if (FormData.No_Radio.Checked == true)
                ServiceCond = "No";
            else
                ServiceCond = "Yes";

            string[] dataprint = { "Built-Up Column Analysis Per 2018 National Design Specification", "", "Column Name - " + membername, "Wood Species: " + woodspecies,"Product Dimension: " + dimension, "Number of Plies: " + plies, "", "Column Height: " + colheight + " ft.", "Compression Bracing: " + compbrace + " ft.",
                "Applied Axial Eccentricity From Neutral Axis: " + ecc + " member depth", "", "Applied Dead Load: " + DL + " lbs", "Applied Floor Live Load: " + FL + " lbs", "Applied Snow Load: " + SL + " lbs", "Applied Roof Live Load: " + RL + " lbs", "Lateral Wind Load: " + WL + " plf", "", "Were Wet Service Conditions Considered: " + ServiceCond,
                "\n", "DESIGN RESULTS:\n"};

            System.IO.File.WriteAllLines(pathway, dataprint);


            for (int i = 0; i < 17; i++) {

                //Adjust for slenderness
                if (i == 0) {
                    File.AppendAllText(pathway, datainfo_str[i] + datainfo[i].ToString("0.0") + "\n");
                }
                //Adjust for empty struct, lateral deflection L/xxx, and Load Combo
                else if (i == 1 || i == 5 || i == 6 || i == 10 || i == 12 || i == 13 || i == 16) {
                    File.AppendAllText(pathway, datainfo_str[i] + "\n");
                }
                //Adjust sigfig for LDF & Bending/Comp
                else if (i == 4 || i == 9 || i == 14 || i == 15) {
                    //Adjust to provide a passed/failed value on text report
                    if (i == 14 && (datainfo[i] > 1))
                        File.AppendAllText(pathway, datainfo_str[i] + datainfo[i].ToString("0.00") + " - Failed\n");
                    else if (i == 14 && (datainfo[i] <= 1))
                        File.AppendAllText(pathway, datainfo_str[i] + datainfo[i].ToString("0.00") + " - Passed\n");
                    else
                        File.AppendAllText(pathway, datainfo_str[i] + datainfo[i].ToString("0.00") + "\n");
                }
                //Adjust for display of lateral deflection
                else if (i == 11) {
                    File.AppendAllText(pathway, datainfo_str[i] + datainfo[i].ToString("0.00") + " in\n");
                }
                //Adjust for axial compression
                else if (i == 2 || i == 3) {
                    File.AppendAllText(pathway, datainfo_str[i] + datainfo[i].ToString("0") + " lbs\n");
                }
                //Adjust for lateral moment
                else if (i == 7 || i == 8) {
                    File.AppendAllText(pathway, datainfo_str[i] + datainfo[i].ToString("0") + " ft-lbs\n");
                }
                else {
                    File.AppendAllText(pathway, datainfo_str[i] + datainfo[i].ToString("0") + "\n");
                }
            }

            if (FormData.WarningLabel_1.Text != "")
                File.AppendAllText(pathway, "\nWarning #1 - " + FormData.WarningLabel_1.Text + "\n");
            if (FormData.WarningLabel_2.Text != "")
                File.AppendAllText(pathway, "\nWarning #2 - " + FormData.WarningLabel_2.Text + "\n");
        }

    }
}
