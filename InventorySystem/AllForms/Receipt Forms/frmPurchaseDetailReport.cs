using InventorySystem.AllReports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem.AllForms.Receipt_Forms
{
    public partial class frmPurchaseDetailReport : Form
    {
        private string purchaseID = string.Empty;
        public frmPurchaseDetailReport(string purchaseID)
        {
            InitializeComponent();
            this.purchaseID = purchaseID;
        }

        private void frmPurchaseDetailReport_Load(object sender, EventArgs e)
        {
            rptPurchaseReciptReport rpt = new rptPurchaseReciptReport();
            rpt.SetParameterValue("pPurchaseID",purchaseID);
            crv.ReportSource = rpt;
        }
    }
}
