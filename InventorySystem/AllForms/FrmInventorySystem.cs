using InventorySystem.AllForms.CustomerForms;
using InventorySystem.AllForms.PurchaseForms;
using InventorySystem.AllForms.StockForms;
using InventorySystem.AllForms.SupplierForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem.AllForms
{
    public partial class FrmInventorySystem : Form
    {
        public FrmInventorySystem()
        {
            InitializeComponent();
        }

        private void FrmInventorySystem_Load(object sender, EventArgs e)
        {
            tsslabelDateTime.Text = DateTime.Now.ToString("dddd MMMM yyyy hh:mm:ss");
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory frm = new frmCategory();
            frm.ShowDialog();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducts frm = new frmProducts();
            frm.ShowDialog();
        }

        private void stockReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockReport frm = new frmStockReport();
            frm.ShowDialog();
        }

        private void btnStockReport_Click(object sender, EventArgs e)
        {
            frmStockReport frm = new frmStockReport();
            frm.ShowDialog();
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockReport frm = new frmStockReport();
            frm.ShowDialog();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            frmProducts frm = new frmProducts();
            frm.ShowDialog();
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplier frm = new frmSupplier();
            frm.ShowDialog();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            frm.ShowDialog();
        }

        private void newPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchase frm = new frmPurchase();
            frm.ShowDialog();
        }

        private void purchasePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPurchasePayment frm = new frmPurchasePayment();
            frm.ShowDialog();
        }

        private void supplierBalancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSupplierBalances frm = new frmSupplierBalances();
            frm.ShowDialog();
        }
    }
}
