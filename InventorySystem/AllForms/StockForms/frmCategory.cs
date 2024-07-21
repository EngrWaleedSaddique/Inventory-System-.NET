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
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
            FillGrid("");
        }
        private string editCategoryID = string.Empty;
        private void SetColoumnsWidth() {
            dgvCategoryList.Columns[0].Width = 100;
            dgvCategoryList.Columns[1].Width = 200;
            dgvCategoryList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            FillGrid("");
            SetColoumnsWidth();
        }
        private void FillGrid(string search) {
            DataTable dt = new DataTable();
            dgvCategoryList.Rows.Clear();
            if (search.Trim().Length > 0)
            {
                dt = DBL.RetrieveData("Select * from Categories where (Name+Description) like '%" + search.Trim() + "%'");
            }
            else
            {
                dt = DBL.RetrieveData("Select * from Categories");
            }
            if (dt == null) {
                return;
            }
            if (dt.Rows.Count > 0) {
                foreach (DataRow category in dt.Rows) {
                    dgvCategoryList.Rows.Add(Convert.ToString(category[0]), Convert.ToString(category[1]), Convert.ToString(category[2]));
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            epCategory.Clear();
            if (txtCategory.Text.Trim().Length == 0)
            {
                epCategory.SetError(txtCategory,"Please Enter Category Name");
                txtCategory.Focus();
                txtCategory.SelectAll();
                return;
            }
            DataTable dt = new DataTable();
            dt = DBL.RetrieveData("Select * from Categories where Name='"+txtCategory.Text.Trim()+"'");
            if (dt.Rows.Count > 0) {
                epCategory.SetError(txtCategory,"Category is already exist");
                txtCategory.Focus();
                txtCategory.SelectAll();
                return;
            }
            string query = string.Format("insert into Categories(Name,[Description]) values ('{0}','{1}')",txtCategory.Text.Trim(),txtDescription.Text.Trim());
            DBL.InsertData(query);
            ClearForm();
            FillGrid("");
            MessageBox.Show("Category Added Successfully", "Inventory System");
        }
        private void ClearForm() {
            txtDescription.Clear();
            txtCategory.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void txtSearchCategory_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text);
        }
        private void EnableComponent() {
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
            editCategoryID = string.Empty;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableComponent();
            if (dgvCategoryList.Rows.Count > 0)
            {
                if (dgvCategoryList.SelectedRows.Count == 1) {
                    editCategoryID = Convert.ToString(dgvCategoryList.CurrentRow.Cells[0].Value);
                    txtCategory.Text= Convert.ToString(dgvCategoryList.CurrentRow.Cells[1].Value);
                    txtDescription.Text= Convert.ToString(dgvCategoryList.CurrentRow.Cells[2].Value);
                }
                else
                {
                    MessageBox.Show("Please select one Record");
                    return;
                }
            }
            else {
                MessageBox.Show("List is empty");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableComponent();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            epCategory.Clear();
            if (txtCategory.Text.Trim().Length == 0)
            {
                epCategory.SetError(txtCategory, "Please Enter Category Name");
                txtCategory.Focus();
                txtCategory.SelectAll();
                return;
            }
            DataTable dt = new DataTable();
            dt = DBL.RetrieveData("Select * from Categories where Name='" + txtCategory.Text.Trim() + "' and CategoryID !='"+editCategoryID.Trim()+"'");
            if (dt.Rows.Count > 0)
            {
                epCategory.SetError(txtCategory, "Category is already exist");
                txtCategory.Focus();
                txtCategory.SelectAll();
                return;
            }

            string query = string.Format("Update Categories set Name='{0}',[Description]='{1}' where CategoryID='{2}'",txtCategory.Text.Trim(),txtDescription.Text.Trim(),editCategoryID.Trim());
            DBL.InsertData(query);
            ClearForm();
            FillGrid("");
            MessageBox.Show("Category Updated Successfully", "Inventory System");
            DisableComponent();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCategoryList.Rows.Count > 0)
            {
                if (dgvCategoryList.SelectedRows.Count == 1)
                {
                    if (MessageBox.Show("Are you sure you want to delete Record!", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string query = "Select * from Products where CategoryID='" + Convert.ToString(dgvCategoryList.CurrentRow.Cells[0].Value) + "'";
                        DataTable dt = new DataTable();
                        dt = DBL.RetrieveData(query);
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Category is not Empty !\nNote: Only Empty Categories are Deleted...");
                            return;
                        }
                        DBL.DeleteData("Delete from Categories where CategoryID='" + Convert.ToString(dgvCategoryList.CurrentRow.Cells[0].Value) + "'");
                        MessageBox.Show("Category Deleted Successfully");
                        FillGrid("");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please select one Record");
                    return;
                }
            }
            else
            {
                MessageBox.Show("List is empty");
            }
        }
    }
}
