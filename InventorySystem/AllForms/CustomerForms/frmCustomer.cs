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

namespace InventorySystem.AllForms.CustomerForms
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }
        private string editCustomerID = string.Empty;
        private void setColoumnsWidth()
        {
            dgvCustomerList.Columns[0].Width = 100;
            dgvCustomerList.Columns[1].Width = 150;
            dgvCustomerList.Columns[2].Width = 120;
            dgvCustomerList.Columns[3].Width = 180;
            dgvCustomerList.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            setColoumnsWidth();
            FillGrid("");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            epCustomer.Clear();
            if (txtCustomerName.Text.Trim().Length == 0)
            {
                epCustomer.SetError(txtCustomerName, "Please Enter Customer Name");
                txtCustomerName.Focus();
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
            dt = DBL.RetrieveData("Select * from Customers where CustomerName='" + txtCustomerName.Text.Trim() + "' and ContactNo='"+txtContactNo.Text.Trim()+"'");
            if (dt.Rows.Count > 0)
            {
                epCustomer.SetError(txtCustomerName, "Already Exist!");
                txtCustomerName.Focus();
                return;
            }
            string query = String.Format("Insert into Customers(CustomerName,ContactNo,Address,Description) values('{0}','{1}','{2}','{3}')", txtCustomerName.Text.Trim(), contactNo,txtAddress.Text.Trim(), txtDescription.Text.Trim());
            DBL.InsertData(query);
            MessageBox.Show("Customer Added Successfully");
            ClearForm();
        }
        private void ClearForm()
        {
            txtContactNo.Clear();
            txtDescription.Clear();
            txtCustomerName.Clear();
            txtAddress.Clear();
            FillGrid("");

        }

        private void FillGrid(string search)
        {

            DataTable dt = new DataTable();
            dgvCustomerList.Rows.Clear();
            if (search.Trim().Length > 0)
            {
                dt = DBL.RetrieveData("Select * from Customers where (CustomerName+Description) like '%" + search.Trim() + "%'");
            }
            else
            {
                dt = DBL.RetrieveData("Select * from Customers");
            }
            if (dt.Rows.Count > 0)
            {

                foreach (DataRow Customer in dt.Rows)
                {
                    dgvCustomerList.Rows.Add(Convert.ToString(Customer[0]), Convert.ToString(Customer[1]), Convert.ToString(Customer[2]), Convert.ToString(Customer[3]),Convert.ToString(Customer[4]));
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
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
            editCustomerID = string.Empty;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomerList.Rows.Count > 0)
            {
                if (dgvCustomerList.SelectedRows.Count == 1)
                {
                    editCustomerID = Convert.ToString(dgvCustomerList.CurrentRow.Cells[0].Value);
                    txtCustomerName.Text = Convert.ToString(dgvCustomerList.CurrentRow.Cells[1].Value);
                    txtContactNo.Text = Convert.ToString(dgvCustomerList.CurrentRow.Cells[2].Value);
                    txtAddress.Text = Convert.ToString(dgvCustomerList.CurrentRow.Cells[3].Value);
                    txtDescription.Text = Convert.ToString(dgvCustomerList.CurrentRow.Cells[4].Value);
                    EnableComponent();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableComponent();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            epCustomer.Clear();
            if (txtCustomerName.Text.Trim().Length == 0)
            {
                epCustomer.SetError(txtCustomerName, "Please Enter Supplier Name");
                txtCustomerName.Focus();
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
            dt = DBL.RetrieveData("Select * from Customers where CustomerName='" + txtCustomerName.Text.Trim() + "' and ContactNo='"+txtContactNo.Text.Trim()+"' and CustomerId !='" + editCustomerID.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                epCustomer.SetError(txtCustomerName, "Already Exist!");
                txtCustomerName.Focus();
                return;
            }
            string query = String.Format("update Customers set CustomerName='{0}',ContactNo='{1}',Address='{2}',Description='{3}' where CustomerID='{4}'", txtCustomerName.Text.Trim(), contactNo,txtContactNo.Text.Trim(), txtDescription.Text.Trim(), editCustomerID.Trim());

            DBL.InsertData(query);
            MessageBox.Show("Customer Record Updated Successfully");
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
                if (dgvCustomerList.Rows.Count > 0)
                {
                    if (dgvCustomerList.SelectedRows.Count == 1)
                    {
                        if (MessageBox.Show("Are you sure you want to selected record!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DBL.DeleteData("Delete from Customers where CustomerID='" + Convert.ToString(dgvCustomerList.CurrentRow.Cells[0].Value) + "'");
                            MessageBox.Show("Customer Deleted Successfully");
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
            catch (Exception)
            {
                MessageBox.Show("Some records are Dependent on selected record");
            }
        }

        private void txtContactNo_Leave(object sender, EventArgs e)
        {
            epCustomer.Clear();
            if (txtContactNo.Text.Trim().Length < 13 && txtContactNo.Text.Trim().Length > 1)
            {
                epCustomer.SetError(txtContactNo, "Please Enter Contact No!");
                txtContactNo.Focus();
                txtContactNo.SelectAll();
                return;
            }
        }
    }
}
