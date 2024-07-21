using InventorySystem.AllForms.Receipt_Forms;
using InventorySystem.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem.AllForms.SupplierForms
{
    public partial class frmSupplierBalances : Form
    {
        public frmSupplierBalances()
        {
            InitializeComponent();
        }
        private string supplierID = string.Empty;
        private void ClearSearchBox()
        {
            lblSupplierName.Text = string.Empty;
            lblContactNo.Text = string.Empty;
            lblDescription.Text = string.Empty;
            supplierID = string.Empty;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            epPurchase.Clear();
            ClearSearchBox();
            if (txtSearchSupplier.Text.Trim().Length == 0)
            {

                epPurchase.SetError(txtSearchSupplier, "Please Enter Supplier Name/Contact Number with country code e.g (+92)");
                txtSearchSupplier.Focus();
                return;
            }
            DataTable dt = new DataTable();
            dt = DBL.RetrieveData("Select * from Companies where CompanyName='" + txtSearchSupplier.Text.Trim() + "'");
            if (dt.Rows.Count == 0)
            {
                dt = DBL.RetrieveData("Select * from Companies where ContactNo='" + txtSearchSupplier.Text.Trim() + "'");
            }
            if (dt.Rows.Count > 0)
            {
                supplierID = Convert.ToString(dt.Rows[0]["CompanyID"]);
                lblSupplierName.Text = Convert.ToString(dt.Rows[0]["CompanyName"]);
                lblContactNo.Text = Convert.ToString(dt.Rows[0]["ContactNo"]);
                lblDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
                AllPaymentList();

            }
            else
            {
                ClearSearchBox();
                MessageBox.Show("Record Not Fount");
            }
        }
        private void AllPaymentList() {
            DataTable dt = new DataTable();
            dt = DBL.RetrieveData("Select [CompanyID] as [ID],[CompanyName],[ContactNo],[PurchasePaymentID] as [Receipt No],[Date] as [Payment Date],[TotalBalances] as [Total Balances],[Payments] as [Payment],[RemainingBalances] as [Runing Balances],[Description] from[V_SupplierBalances] Where [CompanyID]='" + supplierID + "'");
            if (dt.Rows.Count > 0)
            {
                dgvPaymentDetail.DataSource = dt;
            }
            else
            {
                dgvPaymentDetail.DataSource = null;
            }
        }

        private void printReciptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPaymentDetail.Rows.Count > 0)
            {
                if (dgvPaymentDetail.SelectedRows.Count == 1)
                {
                    frmReceiptPayment frm = new frmReceiptPayment(Convert.ToString(dgvPaymentDetail.CurrentRow.Cells[3].Value).Trim());
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Please Select One Record");
                    return;
                }
            }
            else {
                MessageBox.Show("List is empty!");
            }
        }

        private void returnPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPaymentDetail.Rows.Count > 0)
            {
                if (dgvPaymentDetail.SelectedRows.Count == 1)
                {
                    if (MessageBox.Show("Are you sure you want to Return Selected Payment.", "Confirmation Message",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string paymentid = Convert.ToString(dgvPaymentDetail.CurrentRow.Cells[3].Value).Trim();
                        string query = string.Format("Delete from PurchasePayments where PurchasePaymentID='" + paymentid + "'");
                        DBL.DeleteData(query);
                        AllPaymentList();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select One Record");
                    return;
                }
            }
            else
            {
                MessageBox.Show("List is empty!");
            }
        }
    }
}

