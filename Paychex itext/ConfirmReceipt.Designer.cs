namespace Paychex_itext
{
    partial class ValidData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.confirmData = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.receiptData = new System.Windows.Forms.ListView();
            this.field = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.value = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // confirmData
            // 
            this.confirmData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.confirmData.Location = new System.Drawing.Point(13, 340);
            this.confirmData.Name = "confirmData";
            this.confirmData.Size = new System.Drawing.Size(75, 23);
            this.confirmData.TabIndex = 0;
            this.confirmData.Text = "Confirm";
            this.confirmData.UseVisualStyleBackColor = true;
            this.confirmData.Click += new System.EventHandler(this.confirmData_Click);
            // 
            // cancel
            // 
            this.cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancel.Location = new System.Drawing.Point(263, 340);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // receiptData
            // 
            this.receiptData.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.receiptData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.field,
            this.value});
            this.receiptData.HideSelection = false;
            this.receiptData.Location = new System.Drawing.Point(13, 76);
            this.receiptData.Name = "receiptData";
            this.receiptData.Size = new System.Drawing.Size(325, 241);
            this.receiptData.TabIndex = 2;
            this.receiptData.UseCompatibleStateImageBehavior = false;
            this.receiptData.View = System.Windows.Forms.View.Details;
            this.receiptData.SelectedIndexChanged += new System.EventHandler(this.receiptData_SelectedIndexChanged);
            // 
            // field
            // 
            this.field.Text = "Field";
            this.field.Width = 100;
            // 
            // value
            // 
            this.value.Text = "Value";
            this.value.Width = 250;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(81, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Is the Information Correct?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ValidData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 375);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.receiptData);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.confirmData);
            this.Name = "ValidData";
            this.Text = "Confirm Receipt";
            this.Load += new System.EventHandler(this.ValidData_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirmData;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.ListView receiptData;
        private System.Windows.Forms.ColumnHeader field;
        private System.Windows.Forms.ColumnHeader value;
        private System.Windows.Forms.Label label1;
    }
}