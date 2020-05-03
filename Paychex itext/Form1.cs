﻿using System;
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
using System.Text.RegularExpressions;

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

        private void btnProcess_Click(object sender, EventArgs e)
        {
            txtResults.Text = PDFread.GetPdfPageText(txtFilePath.Text);
            /*Send to data parser for value extraction*/
            DataClass parsedData = VendorSelection.ParseData(txtResults.Text);
            this.Hide();
            writeToFile();

            /*user confirmation of data*/
            ValidData viewData = new ValidData(parsedData);
            viewData.ShowDialog();

            /*close current form*/
            this.Close();
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
        public static string GetPdfPageText(string filePath)
        {

            using (PdfDocument pdfDocument = new PdfDocument(new PdfReader(filePath)))
            {
                int numberOfPages = pdfDocument.GetNumberOfPages();
                ITextExtractionStrategy extractionsStrategy = new SimpleTextExtractionStrategy();
                string pageText = "";
                int pageNum = 1;

                // Extract every page from the pdf
                while (pageNum <= numberOfPages)
                {
                    pageText = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(pageNum), extractionsStrategy);
                    pageText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(pageText)));
                    pageNum++;
                }

                /* Processing to make regexes usable */
                pageText = Regex.Replace(pageText, @"\t|\n|\r", " "); // remove non-readable characters
                pageText = Regex.Replace(pageText, @"[^\u0000-\u007F]+", " "); // replace artifacts from ASCIIEncoding
                pdfDocument.Close();

                return pageText;

            }

        }
    }


}
