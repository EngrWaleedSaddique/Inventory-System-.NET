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

namespace InventorySystem.AllForms.StockForms
{
    public partial class frmSupplier : Form
    {
        public frmSupplier()
        {
            InitializeComponent();
        }
        private string editSupplierID = string.Empty;
        private void frmSupplier_Load(object sender, EventArgs e)
        {
            setColoumnsWidth();
            FillGrid("");
        }
        private void setColoumnsWidth() {
            dgvSupplierList.Columns[0].Width = 100;
            dgvSupplierList.Columns[1].Width = 150;
            dgvSupplierList.Columns[2].Width = 120;
            dgvSupplierList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void txtContactNo_Leave(object sender, EventArgs e)
        {
            epSupplier.Clear();
            if (txtContactNo.Text.Trim().Length < 13 && txtContactNo.Text.Trim().Length > 1) {
                epSupplier.SetError(txtContactNo,"Please Enter Contact No!");
                txtContactNo.Focus();
                txtContactNo.SelectAll();
                return;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            epSupplier.Clear();
            if (txtSupplierName.Text.Trim().Length == 0) {
                epSupplier.SetError(txtSupplierName,"Please Enter Supplier Name");
                txtSupplierName.Focus();
                return;
            }
            string contactNo = string.Empty;
            if (txtContactNo.Text.Length == 1)
            {
                contactNo = "";
            }
            else {
                contactNo = txtContactNo.Text.Trim();
            }

            DataTable dt = new DataTable();
            dt = DBL.RetrieveData("Select * from Companies where CompanyName='"+txtSupplierName.Text.Trim()+"'");
            if (dt.Rows.Count > 0) {
                epSupplier.SetError(txtSupplierName,"Already Exist!");
                txtSupplierName.Focus();
                return;
            }
            string query = String.Format("Insert into Companies(CompanyName,ContactNo,Description) values('{0}','{1}','{2}')",txtSupplierName.Text.Trim(),contactNo,txtDescription.Text.Trim());
            DBL.InsertData(query);
            MessageBox.Show("Supplier Added Successfully");
            ClearForm();
        }
        private void EnableComponent()
        {
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
        }
        private void DisableComponent()
        {
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Enabled = true;
            btnEdit.Enabled = true;
            editSupplierID = string.Empty;
        }
        private void ClearForm()
        {
            txtContactNo.Clear();
            txtDescription.Clear();
            txtSupplierName.Clear();
            FillGrid("");

        }

        private void FillGrid(string search)
        {

            DataTable dt = new DataTable();
            dgvSupplierList.Rows.Clear();
            if (search.Trim().Length > 0)
            {
                dt = DBL.RetrieveData("Select * from Companies where (CompanyName+Description) like '%" + search.Trim() + "%'");
            }
            else {
                dt = DBL.RetrieveData("Select * from Companies");
            }
            if (dt.Rows.Count > 0) {

                foreach (DataRow Supplier in dt.Rows) {
                    dgvSupplierList.Rows.Add(Convert.ToString(Supplier[0]), Convert.ToString(Supplier[1]), Convert.ToString(Supplier[2]), Convert.ToString(Supplier[3]));

                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSupplierList.Rows.Count > 0)
            {
                if (dgvSupplierList.SelectedRows.Count == 1)
                {
                    editSupplierID = Convert.ToString(dgvSupplierList.CurrentRow.Cells[0].Value);
                    txtSupplierName.Text = Convert.ToString(dgvSupplierList.CurrentRow.Cells[1].Value);
                    txtContactNo.Text = Convert.ToString(dgvSupplierList.CurrentRow.Cells[2].Value);
                    txtDescription.Text = Convert.ToString(dgvSupplierList.CurrentRow.Cells[3].Value);
                    EnableComponent();
                }
                else
                {
                    MessageBox.Show("Please Select one Record");
                    return;
                }
            }
            else {
                MessageBox.Show("List is Empty");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableComponent();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            epSupplier.Clear();
            if (txtSupplierName.Text.Trim().Length == 0)
            {
                epSupplier.SetError(txtSupplierName, "Please Enter Supplier Name");
                txtSupplierName.Focus();
                return;
            }
            string contactNo = string.Empty;
            if (txtContactNo.Text.Length == 1)
            {
                contactNo = "";
            }
            else
            {
                contactNo = txtContactNo.Text.Trim();
            }

            DataTable dt = new DataTable();
            dt = DBL.RetrieveData("Select * from Companies where CompanyName='" + txtSupplierName.Text.Trim() + "' and CompanyId !='"+editSupplierID.Trim()+"'");
            if (dt.Rows.Count > 0)
            {
                epSupplier.SetError(txtSupplierName, "Already Exist!");
                txtSupplierName.Focus();
                return;
            }
            string query = String.Format("update Companies set CompanyName='{0}',ContactNo='{1}',Description='{2}' where CompanyID='{3}'", txtSupplierName.Text.Trim(), contactNo, txtDescription.Text.Trim(),editSupplierID.Trim());

            DBL.InsertData(query);
            MessageBox.Show("Supplier Added Successfully");
            ClearForm();
            DisableComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSupplierList.Rows.Count > 0)
                {
                    if (dgvSupplierList.SelectedRows.Count == 1)
                    {
                        if (MessageBox.Show("Are you sure you want to selected record!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DBL.DeleteData("Delete from Companies where CompanyID='" + Convert.ToString(dgvSupplierList.CurrentRow.Cells[0].Value) + "'");
                            MessageBox.Show("Supplier Deleted Successfully");
                            FillGrid("");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please Select one Record");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("List is Empty");
                }
            }
            catch (Exception) {
                MessageBox.Show("Some records are Dependent on selected record");
            }
        }
    }
}
