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
    }
}
