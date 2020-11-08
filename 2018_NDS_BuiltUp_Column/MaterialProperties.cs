using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2018_NDS_BuiltUp_Column {
    public class MaterialProperties {
        public double E;
        public double Wid;
        public double Dep;
        public double Emin;
        public double Fc;
        public double Fb;
        public double c;
        public double Plies;
        public double I;
        public double CfFb;
        public double CfFc;
        public double Cr;
        public double Cm_Fb;
        public double Cm_Fc;
        public double Cm_E;
        public double Ci_E;
        public double Ci_F;


        //Used to reference data from active main 'ProgramSpawnForm' that is referenced for analysis
        ProgramSpawnForm FormData = (ProgramSpawnForm)Form.ActiveForm;


        //Builds struct based upon info provided by user selection, currently assumes visual grade #2 for all wood species
        //Definition of beams and stringers per section 4.1.3.3 of NDS
        //Definition of posts & timbers per section 4.1.3.4 of NDS
        public void ClassBuilder(MaterialProperties data, double width, double depth, string ply) {
            if (FormData.WoodSpeciesListBox.Text == "Douglas Fir" && width <= 4) {
                data.E = 1.6 * Math.Pow(10, 6);
                data.Wid = width;
                data.Dep = depth;
                data.Emin = 580000;
                data.Fc = 1350;
                data.Fb = 900;
            }
            //Beam and stringer
            else if (FormData.WoodSpeciesListBox.Text == "Douglas Fir" && (width > 4) && (depth > 2 + width)) {
                data.E = 1.3 * Math.Pow(10, 6);
                data.Wid = width;
                data.Dep = depth;
                data.Emin = 470000;
                data.Fc = 600;
                data.Fb = 875;
            }
            //Post & timber
            else if (FormData.WoodSpeciesListBox.Text == "Douglas Fir" && width > 4 && (depth <= 2 + width)) {
                data.E = 1.3 * Math.Pow(10, 6);
                data.Wid = width;
                data.Dep = depth;
                data.Emin = 470000;
                data.Fc = 700;
                data.Fb = 750;
            }
            else if (FormData.WoodSpeciesListBox.Text == "Spruce Pine Fir" && width <= 4) {
                data.E = 1.4 * Math.Pow(10, 6);
                data.Wid = width;
                data.Dep = depth;
                data.Emin = 510000;
                data.Fc = 1150;
                data.Fb = 875;
            }
            //Beam and stringer
            else if (FormData.WoodSpeciesListBox.Text == "Spruce Pine Fir" && (width > 4) && (depth > 2 + width)) {
                data.E = 1.0 * Math.Pow(10, 6);
                data.Wid = width;
                data.Dep = depth;
                data.Emin = 370000;
                data.Fc = 425;
                data.Fb = 600;
            }
            //Post & timber
            else if (FormData.WoodSpeciesListBox.Text == "Spruce Pine Fir" && width > 4 && (depth <= 2 + width)) {
                data.E = 1.0 * Math.Pow(10, 6);
                data.Wid = width;
                data.Dep = depth;
                data.Emin = 370000;
                data.Fc = 500;
                data.Fb = 500;
            }
            else if (FormData.WoodSpeciesListBox.Text == "Alaskan Yellow Cedar" && width <= 4) {
                data.E = 1.3 * Math.Pow(10, 6);
                data.Wid = width;
                data.Dep = depth;
                data.Emin = 470000;
                data.Fc = 1000;
                data.Fb = 800;
            }
            //Beam and stringer
            else if (FormData.WoodSpeciesListBox.Text == "Alaskan Yellow Cedar" && (width > 4) && (depth > 2 + width)) {
                data.E = 1.0 * Math.Pow(10, 6);
                data.Wid = width;
                data.Dep = depth;
                data.Emin = 370000;
                data.Fc = 500;
                data.Fb = 750;
            }
            //Post & timber
            else if (FormData.WoodSpeciesListBox.Text == "Alaskan Yellow Cedar" && width > 4 && (depth <= 2 + width)) {
                data.E = 1.0 * Math.Pow(10, 6);
                data.Wid = width;
                data.Dep = depth;
                data.Emin = 370000;
                data.Fc = 600;
                data.Fb = 625;
            }
            else if (FormData.WoodSpeciesListBox.Text == "Hem Fir" && width <= 4) {
                data.E = 1.3 * Math.Pow(10, 6);
                data.Wid = width;
                data.Dep = depth;
                data.Emin = 470000;
                data.Fc = 1300;
                data.Fb = 850;
            }
            //Beam and stringer
            else if (FormData.WoodSpeciesListBox.Text == "Hem Fir" && (width > 4) && (depth > 2 + width)) {
                data.E = 1.1 * Math.Pow(10, 6);
                data.Wid = width;
                data.Dep = depth;
                data.Emin = 400000;
                data.Fc = 500;
                data.Fb = 675;
            }
            //Post & timber
            else if (FormData.WoodSpeciesListBox.Text == "Hem Fir" && width > 4 && (depth <= 2 + width)) {
                data.E = 1.1 * Math.Pow(10, 6);
                data.Wid = width;
                data.Dep = depth;
                data.Emin = 400000;
                data.Fc = 575;
                data.Fb = 575;
            }

            else if (FormData.WoodSpeciesListBox.Text == "Southern Yellow Pine" && width <= 4) {
                data.E = 1.4 * Math.Pow(10, 6);
                data.Wid = width;
                data.Dep = depth;
                data.Emin = 510000;
                data.Fc = 1450;
                data.Fb = 1100;
            }
            //Per Table 4B of Supplement
            else if (FormData.WoodSpeciesListBox.Text == "Southern Yellow Pine" && (width > 4) && (width <= 6)) {
                data.E = 1.4 * Math.Pow(10, 6);
                data.Wid = width;
                data.Dep = depth;
                data.Emin = 510000;
                data.Fc = 1400;
                data.Fb = 1000;
            }
            //Per Table 4B of Supplement
            else if (FormData.WoodSpeciesListBox.Text == "Southern Yellow Pine" && (width > 6) && (width <= 8)) {
                data.E = 1.4 * Math.Pow(10, 6);
                data.Wid = width;
                data.Dep = depth;
                data.Emin = 510000;
                data.Fc = 1350;
                data.Fb = 925;
            }

            //Per 15.3.2.4
            data.c = 0.8;

            data.Plies = Convert.ToDouble(ply);

            //4.3.9
            if (Convert.ToDouble(ply) >= 3 && width <= 4)
                data.Cr = 1.15;
            else
                data.Cr = 1.00;

            //MOI in bending orientation, in^4
            data.I = data.Plies * data.Wid * Math.Pow(data.Dep, 3) / 12;

            //Per table 4A & 4B of Supplement
            if (width <= 2 && FormData.WoodSpeciesListBox.Text != "Southern Yellow Pine") {
                if (depth > 0 && depth <= 4) {
                    data.CfFb = 1.5;
                    data.CfFc = 1.15;
                }
                else if (depth <= 6) {
                    data.CfFb = 1.3;
                    data.CfFc = 1.1;
                }
                else if (depth <= 8) {
                    data.CfFb = 1.2;
                    data.CfFc = 1.05;
                }
            }
            else if (width <= 4 && FormData.WoodSpeciesListBox.Text != "Southern Yellow Pine") {
                if (depth > 0 && depth <= 4) {
                    data.CfFb = 1.5;
                    data.CfFc = 1.15;
                }
                else if (depth <= 6) {
                    data.CfFb = 1.3;
                    data.CfFc = 1.1;
                }
                else if (depth <= 8) {
                    data.CfFb = 1.3;
                    data.CfFc = 1.05;
                }
            }
            //Table 4B & 4D of Supplement, only need to apply size factor to timbers > 12" in depth, they don't exist in this project
            //Southern Yellow Pine has Cf_fb factored into design values
            else {
                data.CfFb = 1.0;
                data.CfFc = 1.0;
            }

            //Wet service condition adjustments, per table 4A
            if (FormData.Yes_Radio.Checked == true) {
                //Incision Factor
                if (FormData.WoodSpeciesListBox.Text == "Hem Fir") {
                    data.Ci_E = 0.95;
                    data.Ci_F = 0.80;
                }
                else {
                    data.Ci_E = 1.0;
                    data.Ci_F = 1.0;
                }
                //Wet Service Factor
                if ((data.Fb * data.CfFb) <= 1150)
                    data.Cm_Fb = 1.0;
                else
                    data.Cm_Fb = 0.85;

                if ((data.Fc * data.CfFc) <= 750)
                    data.Cm_Fc = 1.0;
                else
                    data.Cm_Fc = 0.80;

                data.Cm_E = 0.90;
            }
            else {
                data.Cm_E = 1.0;

                data.Cm_Fb = 1.0;
                data.Cm_Fc = 1.0;

                data.Ci_E = 1.0;
                data.Ci_F = 1.0;
            }

        }


        //Performs compression analysis for column to ensure axial load does not exceed F'c parallel
        public double CompressionCheck(MaterialProperties data, double DL, double FL, double SL, double RL, double Fcprime) {

            double CompChk;

            if (SL >= RL)
                CompChk = (DL + FL + SL) / (data.Dep * data.Wid * data.Plies * Fcprime);
            else
                CompChk = (DL + FL + RL) / (data.Dep * data.Wid * data.Plies * Fcprime);

            return CompChk;
        }


        //Determines applied lateral moment from lateral wind load only
        public double Lat_Moment(MaterialProperties data, double WL, double ColHgt, double Fbprime, out double Design_Moment, out double Allow_Moment) {
            //This analysis assumes eccentric loading is applied to the opposite face of the column as wind load,
            //so we do not observe combined eccentric loading and bending moments

            //Calc max moment at center of vertical span
            Design_Moment = WL * Math.Pow(ColHgt, 2) / 8;

            Allow_Moment = (data.I * Fbprime) / (data.Dep / 2);
            //Convert in-lbs to ft-lbs
            Allow_Moment /= 12;

            double Moment_Ratio = Design_Moment / Allow_Moment;

            return Moment_Ratio;
        }


        //Checks built-up column with lateral wind load for critical moment and deflection
        public double Lat_Defl(MaterialProperties data, double WL, double ColHgt) {

            double Deflection = 5 * WL * Math.Pow(ColHgt, 4);
            Deflection /= (384 * data.E * data.Cm_E * data.Ci_E * data.I);

            //Resolve units from (Ft^3/in^2) to in. of deflection
            Deflection *= 1728;

            return Deflection;
        }

    }
}
