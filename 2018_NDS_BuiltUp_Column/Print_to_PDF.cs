using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using PdfSharp.Pdf;
using PdfSharp.Drawing;


namespace _2018_NDS_BuiltUp_Column {
    class Print_to_PDF {

        readonly double pdfBuffer = 50;
        readonly double tableNewLineOffset = 14;


        //Returns a save location with filename if user clicks 'yes' on save dialog box option
        bool SaveDialogBoxVal(string filename, out string savepathway) {
            SaveFileDialog savebox = new SaveFileDialog();
            DateTime today = DateTime.Today;

            bool useraccept = false;

            savebox.DefaultExt = "*.pdf";
            savebox.FileName = String.Format("{0}_{1}.pdf", filename, today.ToString("MM.dd.yyyy"));
            savebox.Filter = "txt files (*.txt)|*.txt|pdf files (*.pdf)|*.pdf|All files (*.*)|*.*";
            savebox.FilterIndex = 2;
            savebox.RestoreDirectory = true;    //Restores last selected directory when opening a new dialogbox

            if (savebox.ShowDialog() == DialogResult.OK) {
                savepathway = savebox.FileName;
                useraccept = true;
            }
            else {
                savepathway = "";
            }

            return useraccept;
        }


        //Builders out header with icon image and file name at top of pdf
        void HeaderBuilder(PdfPage docPage, XGraphics gfx, string memberName, out double y_hgt) {
            Image iconImg = Properties.Resources.ColumnDrawing;

            double x_wid, x_modifier, yImgHgt;
            x_wid = 40;
            x_modifier = x_wid / iconImg.Width;
            yImgHgt = iconImg.Height * x_modifier;

            MemoryStream strm = new MemoryStream();
            iconImg.Save(strm, System.Drawing.Imaging.ImageFormat.Bmp);
            XImage ximg = XImage.FromStream(strm);

            gfx.DrawImage(ximg, new XRect(50, 20, x_wid, yImgHgt)); //Draws image from stream

            double titleXLoc = 50 + x_wid + 15;
            double titleCellWidth = docPage.Width - pdfBuffer - titleXLoc;
            y_hgt = 40;
            //gfx.DrawString("2018 NDS Built-Up Column Design Tool", new XFont("Microsoft Sans Sarif", 18, XFontStyle.Bold | XFontStyle.Underline), XBrushes.Black, new XRect(titleXLoc, y_hgt, titleCellWidth, 18), XStringFormats.CenterLeft); 
            gfx.DrawString("2018 NDS Built-Up Column Design Tool", new XFont("Microsoft Sans Sarif", 18, XFontStyle.Bold | XFontStyle.Underline), XBrushes.Black, new XRect(0, y_hgt, docPage.Width, 18), XStringFormats.Center);

            if (!String.IsNullOrEmpty(memberName)) {
                y_hgt += 25;
                gfx.DrawString(String.Format("Member: {0}", memberName), new XFont("Microsoft Sans Sarif", 12, XFontStyle.Regular), XBrushes.Black, new XRect(0, y_hgt, docPage.Width, 12), XStringFormats.Center);
                y_hgt += 14;
            }
            else {
                y_hgt += 20;
            }
        }


        //Builds footer at bottom of page
        void FooterBuilder(PdfPage docPage, XGraphics gfx, string versionNum) {
            double RectLeft = pdfBuffer;
            double RectWidth = docPage.Width - (2 * pdfBuffer);

            gfx.DrawString(versionNum, new XFont("Microsoft Sans Sarif", 6), XBrushes.Black, new XRect(RectLeft, 750, RectWidth, 8), XStringFormats.CenterRight);

            string dateTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
            dateTime = String.Format("Analysis Runtime - {0}", dateTime);
            gfx.DrawString(dateTime, new XFont("Microsoft Sans Sarif", 6), XBrushes.Black, new XRect(RectLeft, 760, RectWidth, 8), XStringFormats.CenterRight);
        }


        //
        void DesignResulttoGFX(XGraphics gfx, ref double y_hgt) {
            List<string> designTableHeader = new List<string> {
                "Results",
                "Design",
                "Allowable",
                "Design Ratio",
                "LDF",
                "Load Combination"
            };

        }


        public void PDFPrintMethod() {
            PdfDocument newDoc = new PdfDocument(); //New document
            PdfPage docPage = newDoc.AddPage(); //New page added to 'newdoc'
            XGraphics gfx = XGraphics.FromPdfPage(docPage); //This will provide drawing related methods for specified page

            ProgramSpawnForm MainForm = (ProgramSpawnForm)Form.ActiveForm;

            HeaderBuilder(docPage, gfx, MainForm.MemberName_Textbox.Text, out double y_hgt);
            FooterBuilder(docPage, gfx, MainForm.VersionLabel.Text);








            if (SaveDialogBoxVal("Built Up Column_Pdf", out string saveLocation)) {
                try {
                    newDoc.Save(saveLocation);
                }
                catch (Exception ex) {
                    MessageBox.Show("Warning - File using this name is open in another application. Please choose a different name, or close this file out of all other applications that have this file locked before saving file.");
                }
            }
        }
    }
}
