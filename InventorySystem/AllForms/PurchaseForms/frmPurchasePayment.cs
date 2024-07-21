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

namespace InventorySystem.AllForms.PurchaseForms
{
    public partial class frmPurchasePayment : Form
    {
        public frmPurchasePayment()
        {
            InitializeComponent();
        }
        private string supplierID = string.Empty;
        private void setColumnWidth() {
            dgvAllPurchases.Columns[0].Width = 80;
            dgvAllPurchases.Columns[1].Width = 120;
            dgvAllPurchases.Columns[2].Width = 120;
            dgvAllPurchases.Columns[3].Width = 200;

            dgvPurchaseDetail.Columns[0].Width = 80;
            dgvPurchaseDetail.Columns[2].Width = 170;
            dgvPurchaseDetail.Columns[3].Width = 120;
            dgvPurchaseDetail.Columns[4].Width = 120;
            dgvPurchaseDetail.Columns[5].Width = 120;

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            epPurchase.Clear();
            ClearSearchBox();
            lblTotalAmount.Text = "0.0";
            lblTotalPayment.Text = "0.0";
            lblRemainingBalance.Text = "0.0";
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
                SelectSupplierAllPurchase();
                RetrieveAllPayment();
            }
            else
            {
                lblTotalAmount.Text = "0.0";
                lblTotalPayment.Text = "0.0";
                lblRemainingBalance.Text = "0.0";
                ClearSearchBox();
                MessageBox.Show("Record Not Fount");
            }
        }

        private void SelectSupplierAllPurchase()
        {
            lblTotalAmount.Text = "0.0";
            int TotalBalances = 0;
            DataTable dt = new DataTable();
            dgvAllPurchases.Rows.Clear();
            dt = DBL.RetrieveData("Select * from Purchases where CompanyId='"+supplierID+"'");
            if (dt.Rows.Count > 0) {
                foreach (DataRow purchase in dt.Rows) {
                    dgvAllPurchases.Rows.Add(Convert.ToString(purchase["PurchaseID"]), Convert.ToString(Convert.ToDateTime(purchase["PurchaseDate"]).ToString("dd MMMM,yyyy")),Convert.ToString(purchase["TotalAmount"]),Convert.ToString(purchase["Description"]));
                    TotalBalances = TotalBalances + Convert.ToInt32(purchase["TotalAmount"]);
                }
                lblTotalAmount.Text = TotalBalances.ToString();
                AllPayment();
            }
        }
        private void ClearSearchBox()
        {
            lblSupplierName.Text = string.Empty;
            lblContactNo.Text = string.Empty;
            lblDescription.Text = string.Empty;
            supplierID = string.Empty;
        }

        private void frmPurchasePayment_Load(object sender, EventArgs e)
        {
            setColumnWidth();
        }

        private void dgvAllPurchases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvAllPurchases_SelectionChanged(object sender, EventArgs e)
        {
            
            dgvPurchaseDetail.Rows.Clear();
            if (dgvAllPurchases.Rows.Count == 0) {
                return;
            }
            if (dgvAllPurchases.SelectedRows.Count !=1) {
                return;
            }
            string purchaseid = Convert.ToString(dgvAllPurchases.CurrentRow.Cells[0].Value).Trim();
            DataTable dt = new DataTable();
            dt = DBL.RetrieveData("Select * from v_PurchaseDetails where PurchaseID='" + purchaseid + "'");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow product in dt.Rows)
                {
                    dgvPurchaseDetail.Rows.Add(Convert.ToString(product[0]), Convert.ToString(product[1]), Convert.ToString(product[2]), Convert.ToString(product[3]),
                        Convert.ToString(product[4]), Convert.ToString(product[5]));
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dtpPaymentDate.Value = DateTime.Now;
            txtPayment.Clear();
            txtRemainingBalance.Clear();
            txtDescription.Clear();

        }
        private void AllPayment() {
            DataTable dt = new DataTable();
            dt = DBL.RetrieveData("Select sum(Payments) from PurchasePayments where CompanyID='"+supplierID+"'");
            if (dt.Rows.Count > 0)
            {
                float totalAmount = 0.0f;
                float.TryParse(lblTotalAmount.Text.Trim(), out totalAmount);

                float totalPayment = 0.0f;
                float.TryParse(Convert.ToString(dt.Rows[0][0]), out totalPayment);

                lblTotalPayment.Text = Convert.ToString(dt.Rows[0][0]);
                lblRemainingBalance.Text = Convert.ToString(totalAmount - totalPayment);

            }
            else {
                lblRemainingBalance.Text = lblTotalAmount.Text;
                lblTotalPayment.Text = "0.0";
            }
        
        }
        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            epPurchase.Clear();
            if (txtPayment.Text.Trim().Length == 0) {

                epPurchase.SetError(txtPayment,"Please Enter Payment Amount");
                txtPayment.Focus();
                return;
            }
            float payment = 0.0f;
            float.TryParse(txtRemainingBalance.Text.Trim(), out payment);
            if (payment<0) {
                epPurchase.SetError(txtRemainingBalance, "Payment must be less or equal our supplier balance");
                txtRemainingBalance.Focus();
                return;
            }
            if (supplierID != null & supplierID.Trim().Length > 0)
            {
                string Payments = txtPayment.Text.Trim();
                string TotalBalances = lblRemainingBalance.Text.Trim();
                string paymentDate = dtpPaymentDate.Value.ToString("yyyy/MM/dd");
                string RemainingBalance = txtRemainingBalance.Text.Trim();
                string Description = txtDescription.Text.Trim();

                string query = string.Format("Insert into PurchasePayments(CompanyID,TotalBalances,Payments,Date,RemainingBalances,Description)" +
                    " values('{0}','{1}','{2}','{3}','{4}','{5}')",supplierID,TotalBalances,Payments,paymentDate,RemainingBalance,Description);
                DBL.InsertData(query);
                MessageBox.Show("Payment Successfully");
                button2_Click(sender, e);
                AllPayment();
                RetrieveAllPayment();
                tabControl1.SelectedIndex = 0;
            }
            else {
                MessageBox.Show("Please first Search Supplier!");
            }
        }

        private void txtPayment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            float payment = 0.0f;
            float.TryParse(txtPayment.Text.Trim(), out payment);
            float reamainingbalance = 0.0f;
            float.TryParse(lblRemainingBalance.Text.Trim(), out reamainingbalance);
            txtRemainingBalance.Text = Convert.ToString(reamainingbalance-payment);

        }
        private void RetrieveAllPayment()
        {
            DataTable dt = new DataTable();
            dt = DBL.RetrieveData("SELECT [PurchasePaymentID] as ID,[Payments],[Date],[RemainingBalances] as [Remaining Balance],[Description] FROM [InventorySystem].[dbo].[PurchasePayments] Where [CompanyID]='" + supplierID + "'");
            if (dt.Rows.Count > 0)
            {
                dgvPaymentDetail.DataSource = dt;
            }
            else {
                dgvPaymentDetail.DataSource = null;
            }
        }

        private void printReciptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPaymentDetail.Rows.Count > 0)
            {
                if (dgvPaymentDetail.SelectedRows.Count == 1)
                {
                    frmReceiptPayment frm = new frmReceiptPayment(Convert.ToString(dgvPaymentDetail.CurrentRow.Cells[0].Value).Trim());
                    frm.ShowDialog();
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

        private void purchaseInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllPurchases.Rows.Count > 0)
            {
                if (dgvAllPurchases.SelectedRows.Count == 1)
                {
                    frmPurchaseDetailReport frm = new frmPurchaseDetailReport(Convert.ToString(dgvAllPurchases.CurrentRow.Cells[0].Value).Trim());
                    frm.ShowDialog();
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