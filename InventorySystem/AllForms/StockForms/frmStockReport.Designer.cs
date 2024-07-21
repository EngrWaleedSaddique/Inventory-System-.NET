namespace InventorySystem.AllForms.StockForms
{
    partial class frmStockReport
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
            this.crvStockReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvStockReport
            // 
            this.crvStockReport.ActiveViewIndex = -1;
            this.crvStockReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvStockReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvStockReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvStockReport.Location = new System.Drawing.Point(0, 0);
            this.crvStockReport.Name = "crvStockReport";
            this.crvStockReport.ShowCloseButton = false;
            this.crvStockReport.ShowGroupTreeButton = false;
            this.crvStockReport.ShowLogo = false;
            this.crvStockReport.ShowParameterPanelButton = false;
            this.crvStockReport.Size = new System.Drawing.Size(800, 450);
            this.crvStockReport.TabIndex = 0;
            // 
            // frmStockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crvStockReport);
            this.Name = "frmStockReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Report";
            this.Load += new System.EventHandler(this.frmStockReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvStockReport;
    }
}