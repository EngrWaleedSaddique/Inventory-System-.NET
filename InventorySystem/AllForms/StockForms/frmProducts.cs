using InventorySystem.Code;
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
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }
        private string updateProductID = string.Empty;
        private void setColumnsWidth() {
            dgvProductList.Columns[0].Width = 100;
            dgvProductList.Columns[1].Width = 150;
            dgvProductList.Columns[2].Width = 150;
            dgvProductList.Columns[3].Width = 90;
            dgvProductList.Columns[4].Width = 90;
            dgvProductList.Columns[5].Width = 120;
            dgvProductList.Columns[6].Width = 90;
            dgvProductList.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void FormClear() {
            cmbCategoryList.SelectedIndex = 0;
            txtProductName.Clear();
            txtUnitprice.Clear();
            txtQuantity.Clear();
            cmbQuality.SelectedIndex=2;
            txtDescription.Clear();
            FillGrid("");
        }
        private void EnableComponent() {
            btnCancel.Enabled = true;
            btnUpdate.Enabled = true;
            btnClear.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = false;
        }
        private void DisableComponent() {
            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;
            btnClear.Enabled = true;
            btnSave.Enabled = true;
            btnEdit.Enabled = true;
            FormClear();
        }
        private void FillGrid(string search) {
            dgvProductList.Rows.Clear();
            DataTable dt = new DataTable();
            if (search.Trim().Length > 0)
            {
                dt = DBL.RetrieveData("Select * from v_StockList where (ProductName+Name) like '%" + search + "%'");
            }
            else
            {
                dt = DBL.RetrieveData("Select * from v_StockList");
            }
            if (dt.Rows.Count > 0) {
                foreach (DataRow item in dt.Rows) {
                    dgvProductList.Rows.Add(Convert.ToString(item[2]), Convert.ToString(item[3]), Convert.ToString(item[1]), Convert.ToString(item[4]),Convert.ToString(item[5]),(Convert.ToDecimal((Convert.ToInt32(item[4]))*(Convert.ToInt32(item[5])))), Convert.ToString(item[6]), Convert.ToString(item[7]));
                }
            }

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            epProducts.Clear();
            if (cmbCategoryList.SelectedIndex < 1)
            {
                epProducts.SetError(cmbCategoryList, "Please Select Category");
                cmbCategoryList.Focus();
                return;
            }
            if (txtProductName.Text.Trim().Length == 0)
            {
                epProducts.SetError(txtProductName, "Please Enter Product Name");
                txtProductName.Focus();
                return;
            }
            if (txtUnitprice.Text.Trim().Length == 0)
            {
                epProducts.SetError(txtUnitprice, "Please Enter Product Unit Price");
                txtUnitprice.Focus();
                return;
            }
            if (txtQuantity.Text.Trim().Length == 0)
            {
                epProducts.SetError(txtQuantity, "Please Enter Product Quantity");
                txtQuantity.Focus();
                return;
            }
            if (cmbQuality.SelectedIndex == 0)
            {
                epProducts.SetError(cmbQuality, "Please Enter Product Quality");
                txtQuantity.Focus();
                return;
            }

            DataTable checkProduct = new DataTable();
            checkProduct = DBL.RetrieveData("Select * from v_StockList where ProductName='"+txtProductName+"' and Name='"+cmbCategoryList.Text.Trim()+"'" +
                "and ProductID!='"+updateProductID.Trim()+"'");
            if (checkProduct.Rows.Count > 0) {

                epProducts.SetError(txtProductName,"Product Name Already Exist");
                txtProductName.Focus();
                return;
            }
            string categoryid = string.Empty;
            DataTable dt = new DataTable();
            dt = DBL.RetrieveData("Select CategoryID from Categories where Name='" + cmbCategoryList.Text + "'");
            categoryid = Convert.ToString(dt.Rows[0][0]);
            string insertProduct = string.Format("update Products set CategoryId='{0}',Name='{1}',UnitPrice='{2}',Quantity='{3}',Quality='{4}',[Description]='{5}' where ProductID='"+updateProductID.Trim()+"'",
                categoryid, txtProductName.Text.Trim(), txtUnitprice.Text.Trim(), txtQuantity.Text.Trim(), cmbQuality.Text.Trim(), txtDescription.Text.Trim());
            DBL.InsertData(insertProduct);
            MessageBox.Show("Product Updated Successully");
            //FormClear();
            updateProductID = string.Empty;
            DisableComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            epProducts.Clear();
            if (cmbCategoryList.SelectedIndex < 1) {
                epProducts.SetError(cmbCategoryList,"Please Select Category");
                cmbCategoryList.Focus();
                return;
            }
            if (txtProductName.Text.Trim().Length == 0) {
                epProducts.SetError(txtProductName, "Please Enter Product Name");
                txtProductName.Focus();
                return;
            }
            if (txtUnitprice.Text.Trim().Length == 0)
            {
                epProducts.SetError(txtUnitprice, "Please Enter Product Unit Price");
                txtUnitprice.Focus();
                return;
            }
            if (txtQuantity.Text.Trim().Length == 0)
            {
                epProducts.SetError(txtQuantity, "Please Enter Product Quantity");
                txtQuantity.Focus();
                return;
            }
            if (cmbQuality.SelectedIndex == 0)
            {
                epProducts.SetError(cmbQuality, "Please Enter Product Quality");
                txtQuantity.Focus();
                return;
            }
            string categoryid = string.Empty;
            DataTable dt = new DataTable();
            dt = DBL.RetrieveData("Select CategoryID from Categories where Name='"+cmbCategoryList.Text+"'");
            categoryid = Convert.ToString(dt.Rows[0][0]);
            string insertProduct = string.Format("insert into Products(CategoryId,Name,UnitPrice,Quantity,Quality,[Description]) values('{0}','{1}','{2}','{3}','{4}','{5}')",
                categoryid,txtProductName.Text.Trim(),txtUnitprice.Text.Trim(),txtQuantity.Text.Trim(), cmbQuality.Text.Trim(), txtDescription.Text.Trim());
            DBL.InsertData(insertProduct);
            MessageBox.Show("Product Added Successully");
            FillGrid("");
            FormClear();

            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProductList.Rows.Count > 0)
            {
                if (dgvProductList.SelectedRows.Count == 1)
                {
                    updateProductID = Convert.ToString(dgvProductList.CurrentRow.Cells[0].Value);
                    txtProductName.Text= Convert.ToString(dgvProductList.CurrentRow.Cells[1].Value);
                    cmbCategoryList.Text= Convert.ToString(dgvProductList.CurrentRow.Cells[2].Value);
                    txtUnitprice.Text= Convert.ToString(dgvProductList.CurrentRow.Cells[3].Value);
                    txtQuantity.Text= Convert.ToString(dgvProductList.CurrentRow.Cells[4].Value);
                    cmbQuality.Text= Convert.ToString(dgvProductList.CurrentRow.Cells[6].Value);
                    txtDescription.Text = Convert.ToString(dgvProductList.CurrentRow.Cells[7].Value);
                    EnableComponent();
                    return;
                }
                else {
                    MessageBox.Show("Please Select One Record");
                    return;
                }
            }
            else {
                MessageBox.Show("Stock is Empty");            
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            ComboBoxList.CategoryList(cmbCategoryList);
            setColumnsWidth();
            cmbQuality.SelectedIndex = 2;
            FillGrid("");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            updateProductID = string.Empty;
            FormClear();
            DisableComponent();
        }

        private void btnExportStock_Click(object sender, EventArgs e)
        {
            frmStockReport frm = new frmStockReport();
            frm.ShowDialog();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void txtUnitprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}