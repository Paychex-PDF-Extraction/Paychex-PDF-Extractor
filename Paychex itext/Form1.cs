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
using iText.Barcodes;
using iText.Forms;
using iText.IO;
using iText.Kernel;
using iText.Layout;
using iText.Pdfa;
using iText.Signatures;
using iText.StyledXmlParser;
using iText.Svg;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using IOException = System.IO.IOException;
using Data_Parser;
using DB_Interface;

namespace Paychex_itext
{
    
	public partial class Paychex : Form
	{
		public Paychex()
		{
			InitializeComponent();
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            this.openFileDialog1.Filter = "PDF Files|*.pdf";
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                txtFilePath.Text = file;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use
        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            txtResults.Text = PDFread.GetPdfPageText(txtFilePath.Text, 1);
            /*Send to data parser for value extraction*/
            //DataClass parsedData = VendorSelection.ParseData(txtResults.Text);

            /*Send result of parser to db as c# objects*/
            Db db = new Db("http://localhost:5984", "pdf_receipts", "tempAdmin", "gH5sE2*61Lu");
            var result = await db.AddDoc(VendorSelection.ParseData(txtResults.Text));
            if (result)
            {
                // success dialog and continue writing to file
                MessageBox.Show("Success!");
                writeToFile();
            }
            else
            {
                // failure alert and stop writing to file
                MessageBox.Show("Failure");
            }
        }

        private void writeToFile()
        {
            string writeFileName = string.Format("outputData-{0:yyyy-MM-dd_hh-mm-ss-tt}.txt", DateTime.Now);

            StreamWriter outputFile;

            outputFile = File.CreateText(writeFileName);

            outputFile.WriteLine(txtResults.Text);
            outputFile.Close();



        }
    }




    public static class PDFread
    {
        public static string GetPdfPageText(string filePath, int pageNum)
        {
            using (PdfDocument pdfDocument = new PdfDocument(new PdfReader(filePath)))
            {

                ITextExtractionStrategy extractionsStrategy = new SimpleTextExtractionStrategy();
                string pageText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(pageNum), extractionsStrategy);
                pageText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(pageText)));
                pdfDocument.Close();


                return pageText;
            }

        }
    }


}
