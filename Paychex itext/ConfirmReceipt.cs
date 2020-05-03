using Data_Parser;
using DB_Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paychex_itext
{
    public partial class ValidData : Form
    {
        private DataClass data;
        public ValidData(DataClass receiptData)
        {
            this.data = receiptData;
            InitializeComponent();
        }

        private async void confirmData_Click(object sender, EventArgs e)
        {
            /*Send result of parser to db as c# objects*/
            Db db = new Db("http://localhost:5984", "pdf_receipts", "tempAdmin", "gH5sE2*61Lu");
            try
            {
                var result = await db.AddDoc(data);
                if (result)
                {
                    MessageBox.Show("Success!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failure");
                    this.Close();
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ValidData_Load_1(object sender, EventArgs e)
        {
            receiptData.View = View.Details;
            receiptData.GridLines = true;
            receiptData.Items.Add(new ListViewItem(new string[] { "First Name", this.data.EMP_FNAME }));
            receiptData.Items.Add(new ListViewItem(new string[] { "Last Name", this.data.EMP_LNAME }));
            receiptData.Items.Add(new ListViewItem(new string[] { "Total", this.data.TOTAL.ToString() }));
            receiptData.Items.Add(new ListViewItem(new string[] { "Date of Purchase", this.data.DOP }));
            receiptData.Items.Add(new ListViewItem(new string[] { "Vendor Name", this.data.VEND_NAME }));
            receiptData.Items.Add(new ListViewItem(new string[] { "Vendor Id", this.data.VEND_ID.ToString() }));
        }

        private void receiptData_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
