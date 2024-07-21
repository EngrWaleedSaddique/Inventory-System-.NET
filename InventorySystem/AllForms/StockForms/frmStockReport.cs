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

namespace InventorySystem.AllForms.StockForms
{
    public partial class frmStockReport : Form
    {
        public frmStockReport()
        {
            InitializeComponent();
        }

        private void frmStockReport_Load(object sender, EventArgs e)
        {
            rptStock rpt = new rptStock();
            rpt.Refresh();
            crvStockReport.ReportSource = rpt;
            crvStockReport.Refresh();
        }
    }
}
