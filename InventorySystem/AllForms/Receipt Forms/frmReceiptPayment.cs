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
    public partial class frmReceiptPayment : Form
    {
        private string paymentId = string.Empty;
        public frmReceiptPayment(string paymentId)
        {
            InitializeComponent();
            this.paymentId = paymentId;
        }

        private void frmReceiptPayment_Load(object sender, EventArgs e)
        {
            rptPaymentRecipt rpt = new rptPaymentRecipt();
            rpt.SetParameterValue("pPaymentID", paymentId);
            crv.ReportSource = rpt;
        }
    }
}
