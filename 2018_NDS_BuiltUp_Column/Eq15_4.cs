using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace _2018_NDS_BuiltUp_Column {
    //Referenced to solve multi-step problem of bending/comp equation 15.4-1 in 2018 NDS
    class Eq15_4 {

        //Used to reference data from active main 'ProgramSpawnForm' that is referenced for analysis
        ProgramSpawnForm FormData = (ProgramSpawnForm)Form.ActiveForm;


        //Checks slenderness ratio per Chapter 15 of NDS
        public double SlendernessCheck(double ColHgt, double CompBrace, MaterialProperties data, out double Le1, out double Le2, out double Rb1) {
            //Per NDS Appendix G
            double Ke = 1.00;

            //Per 15.3.2, Slenderness in plane with the wall
            Le1 = ColHgt * Ke;

            //Slenderness out of plane of wall
            double Rb2;

            //Per table 3.3.3, use this table because we are including the option for wind load to be applied to the edge of the plies, convert
            if (CompBrace / data.Dep < 7)
                Le2 = 2.06 * CompBrace;
            else
                Le2 = (1.63 * CompBrace) + (3 * data.Dep);

            //Per 15.3.2.3
            Rb1 = Le1 * 12 / data.Dep;

            //Per 3.3.3.6 of NDS
            Rb2 = (Le2 * data.Dep * 12) / (Math.Pow((data.Wid * data.Plies), 2));
            Rb2 = Math.Pow(Rb2, 0.5);

            //Convert from in. to ft.
            Le2 = Le2 / 12;

            return Rb2;
        }


        //Fbstar and Fbprime function per 15.4-1
        public double Fbprime_func(MaterialProperties data, double Le1, double Le2, double LDF) {
            //per equation 3.3-6
            double Fbstar = data.Fb * LDF * data.Cm_Fb * data.CfFb * data.Ci_F * data.Cr;

            double FbE;

            //Per equation 15.4-1 General Equations section
            if (Le1 > Le2)
                FbE = (1.20 * data.Emin * data.Cm_E * data.Ci_E) / ((Le1 * 12 * data.Dep) / Math.Pow(data.Wid * data.Plies, 2));
            else
                FbE = (1.20 * data.Emin * data.Cm_E * data.Ci_E) / ((Le2 * 12 * data.Dep) / Math.Pow(data.Wid * data.Plies, 2));

            double Cl;

            //Per section 3.3.3.1 & 4.4.1.2-B
            if ((data.Dep <= (data.Wid * data.Plies)) || (data.Dep / (data.Wid * data.Plies) <= 4))
                Cl = 1.0;
            //Per 3.3.3.3
            else if (Convert.ToDouble(FormData.CompBrace_Textbox.Text) <= 1)
                Cl = 1.0;
            //Per 4.4.1.2-D
            else if (data.Dep / (data.Wid * data.Plies) <= 6 && Convert.ToDouble(FormData.CompBrace_Textbox.Text) <= 8)
                Cl = 1.0;
            //Per equation 3.3-6
            else {
                Cl = (1 + FbE / Fbstar) / 1.9;

                double temp1 = Math.Pow(Cl, 2) - ((FbE / Fbstar) / 0.95);

                Cl = Cl - Math.Pow(temp1, 0.5);
            }

            //Per table 4.3.1
            double Fbprime = Cl * Fbstar;

            return Fbprime;
        }


        //Checks column against Equation 15.4-2
        public double Eq15_4_2(MaterialProperties data, double fc, double fb1, double Le1, double Le2, double FcE1, double FcE2, double Ecc) {

            double FbE, fcE;

            //Per equation 15.4-1 General Equations section
            if (Le1 > Le2)
                FbE = (1.20 * data.Emin * data.Cm_E * data.Ci_E) / ((Le1 * 12 * data.Dep) / Math.Pow(data.Wid * data.Plies, 2));
            else
                FbE = (1.20 * data.Emin * data.Cm_E * data.Ci_E) / ((Le2 * 12 * data.Dep) / Math.Pow(data.Wid * data.Plies, 2));

            //Checks design equation per equations beyond Eq. 15.4-4
            if (FcE1 < FcE2)
                fcE = FcE1;
            else
                fcE = FcE2;

            double New1 = fc / fcE;


            //Start 15.4-2
            double temp1 = fc / FcE2;

            double temp2 = (fb1 + fc * (6 * Ecc / data.Dep)) / FbE;
            temp2 = Math.Pow(temp2, 2);

            //Per 15.4-2
            double Ans = temp1 + temp2;

            if (Ans > New1) {
                if (Ans >= (double)1.0) {
                    FormData.WarningLabel_2.ForeColor = Color.Red;
                    FormData.WarningLabel_2.Text = "Column fails in at least one load combination according to NDS Eq. 15.4-2, with a value of " + Ans.ToString("0.00") + ", this value must be below 1.0. " +
                        "(Most critical load combination may exceed this number, however, the last load combo to fail in Eq. 15.4-2 is the value printed here).";
                }
            }
            else {
                if (New1 >= (double)1.0) {
                    FormData.WarningLabel_2.ForeColor = Color.Red;
                    FormData.WarningLabel_2.Text = "Column fails in at least one load combination according to (fc / FcE), where FcE is the minimum of [FcE1 && FcE2]. with a value of " + New1.ToString("0.00") + ", " +
                        "this value must be below 1.0. (Most critical load combination may exceed this number, however, the last load combo to fail in (fc / FcE) is the value printed here).";
                }
            }

            return Ans;
        }


        //Performs complete bending analysis based upon load combo input into function, Per 15.3-1
        public double BendingCheckStrong(MaterialProperties data, double DL, double FL, double SL, double RL, double WL, double Col_Hgt, double ecc, double Le1, double Le2, double CompBrace, out double LDF, out double Fb1prime, out double Fcprime, out double CompChk) {

            if (SL >= RL && SL > 0)
                LDF = 1.15;
            else if (RL > SL && RL > 0)
                LDF = 1.25;
            else if (FL > 0)
                LDF = 1.00;
            else
                LDF = 0.9;

            //Per 3.7.1
            double Fcstar = data.Fc * LDF * data.Cm_Fc * data.CfFc * data.Ci_F;

            double fc;

            if (SL >= RL) {
                fc = (DL + FL + SL) / (data.Wid * data.Plies * data.Dep);
            }
            else {
                fc = (DL + FL + RL) / (data.Wid * data.Plies * data.Dep);
            }

            //Per equation 15.3-1, Le1 converted to inches
            //double FcE1 = (0.822 * data.Emin) / Math.Pow((Le1 * 12) / data.Dep, 2);
            //Per equations beyond 15.4-4 of General Equations section
            //double FcE2 = (0.822 * data.Emin) / Math.Pow(((Le2 * 12) / (data.Wid * data.Plies)), 2);

            //Per equation 15.3-1, Le1 converted to inches
            double FcE1 = (0.822 * data.Emin * data.Cm_E * data.Ci_E) / Math.Pow((Col_Hgt * 12) / data.Dep, 2);
            //Per equations beyond 15.4-4 of General Equations section, CompBrace already in unit of inches per main function
            double FcE2 = (0.822 * data.Emin * data.Cm_E * data.Ci_E) / Math.Pow(((CompBrace) / (data.Wid * data.Plies)), 2);

            double Cp, temp1;

            if (FcE1 < FcE2) {
                //Per equation 15.3-1
                Cp = (1 + (FcE1 / Fcstar)) / (2 * data.c);
                temp1 = Math.Pow(Cp, 2) - FcE1 / (Fcstar * data.c);
                Cp = Cp - Math.Pow(temp1, 0.5);
            }
            else {
                //Per equation 15.3-1
                Cp = (1 + (FcE2 / Fcstar)) / (2 * data.c);
                temp1 = Math.Pow(Cp, 2) - FcE2 / (Fcstar * data.c);
                Cp = Cp - Math.Pow(temp1, 0.5);

                if (data.Plies > 1)
                    Cp = 0.6 * Cp;  //Adjusted for built up per 15.3-1
            }

            //Per 15.4-1
            Fcprime = Fcstar * Cp;

            Fb1prime = Fbprime_func(data, Le1, Le2, LDF);

            //First step of analysis, considering eccentric loading without lateral bending due to wind, Per Eq 15.4-1
            double Ans_Send = Math.Pow(fc / Fcprime, 2);
            temp1 = fc * (6 * ecc / data.Dep) * (1 + 0.234 * (fc / FcE1)) / (Fb1prime * (1 - (fc / FcE1)));

            Ans_Send = Ans_Send + temp1;

            //Compression check on member due to axial loading
            CompChk = data.CompressionCheck(data, DL, FL, SL, RL, Fcprime);

            //Begin analysis where we include lateral wind load on column design
            LDF = 1.6;
            Fcstar = LDF * data.Fc * data.CfFc;

            //in.-lbs
            double Lat_Moment = Math.Pow(Col_Hgt, 2) * WL * 12 / 8;

            //lbs./in^2
            double fb1 = Lat_Moment * (data.Dep / 2) / data.I;

            if (FcE1 < FcE2 || data.Plies == 1) {
                //Eq. 15.3-1
                Cp = (1 + (FcE1 / Fcstar)) / (2 * data.c);
                temp1 = Math.Pow(Cp, 2) - FcE1 / (Fcstar * data.c);
                Cp = Cp - Math.Pow(temp1, 0.5);
            }
            else {
                //Eq. 15.3-1
                Cp = (1 + (FcE2 / Fcstar)) / (2 * data.c);
                temp1 = Math.Pow(Cp, 2) - FcE2 / (Fcstar * data.c);
                Cp = Cp - Math.Pow(temp1, 0.5);

                Cp = 0.6 * Cp;  //Adjusted for built up per 15.3-1
            }


            //Recalc Fcprime due to changes to Cp1 for LDF change
            double Fcprime1 = Fcstar * Cp;

            Fb1prime = Fbprime_func(data, Le1, Le2, LDF);

            double Ans_Send_Wind = Math.Pow(fc / Fcprime1, 2);

            temp1 = (fb1 + (fc * (6 * ecc / data.Dep) * (1 + 0.234 * (fc / FcE1)))) / (Fb1prime * (1 - (fc / FcE1)));

            Ans_Send_Wind = Ans_Send_Wind + temp1;

            if (Ans_Send_Wind > Ans_Send)
                Ans_Send = Ans_Send_Wind;
            else {
                if (SL >= RL && SL > 0)
                    LDF = 1.15;
                else if (RL > SL && RL > 0)
                    LDF = 1.25;
                else if (FL > 0)
                    LDF = 1.00;
                else
                    LDF = 0.9;
            }

            //Recheck compression loading on member due to axial loading for load duration due to wind
            if (CompChk < data.CompressionCheck(data, DL, FL, SL, RL, Fcprime1)) {
                CompChk = data.CompressionCheck(data, DL, FL, SL, RL, Fcprime1);

                //determine what value is controlling, send out to main function
                Fcprime = Fcprime1;
            }

            //Run analysis to consider Eq 15.4-2
            double AlterCheck = Eq15_4_2(data, fc, fb1, Le1, Le2, FcE1, FcE2, ecc);

            return Ans_Send;

        }



    }
}
