using InventorySystem.AllForms.Receipt_Forms;
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

namespace InventorySystem.AllForms.PurchaseForms
{
    public partial class frmPurchase : Form
    {
        public frmPurchase()
        {
            InitializeComponent();
        }
        private string supplierID = string.Empty;
        private string categoryID = string.Empty;
        private void ClearSearchBox() {
            lblSupplierName.Text = string.Empty;
            lblContactNo.Text = string.Empty;
            lblDescription.Text = string.Empty;
            supplierID = string.Empty;
        }
        private void SetColumnWidth() {
            dgvCart.Columns[0].Width = 0;
            dgvCart.Columns[1].Width = 0;
            dgvCart.Columns[2].Width = 150;
            dgvCart.Columns[3].Width = 130;
            dgvCart.Columns[4].Width = 100;
            dgvCart.Columns[5].Width = 120;
            dgvCart.Columns[6].Width = 120;
            dgvCart.Columns[7].Width = 140;
            dgvCart.Columns[8].Width = 140;

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            epPurchase.Clear();
            ClearSearchBox();
            if (txtSearchSupplier.Text.Trim().Length == 0) {

                epPurchase.SetError(txtSearchSupplier, "Please Enter Supplier Name/Contact Number with country code e.g (+92)");
                txtSearchSupplier.Focus();
                return;
            }
            DataTable dt = new DataTable();
            dt = DBL.RetrieveData("Select * from Companies where CompanyName='" + txtSearchSupplier.Text.Trim() + "'");
            if (dt.Rows.Count == 0) {
                dt = DBL.RetrieveData("Select * from Companies where ContactNo='" + txtSearchSupplier.Text.Trim() + "'");
            }
            if (dt.Rows.Count > 0)
            {
                supplierID = Convert.ToString(dt.Rows[0]["CompanyID"]);
                lblSupplierName.Text = Convert.ToString(dt.Rows[0]["CompanyName"]);
                lblContactNo.Text = Convert.ToString(dt.Rows[0]["ContactNo"]);
                lblDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
                SelectSupplierPurchase();

            }
            else {
                ClearSearchBox();
                MessageBox.Show("Record Not Fount");
            }
        }
        private void NewPurchase() {
            grpPurchaseCart.Enabled = false;
            grpPurchaseInformation.Enabled = false;
            grpSelectProduct.Enabled = false;
            grpSelectProductDetail.Enabled = false;
            btnPurchaseFinalize.Enabled = false;
            btnPurchaseClear.Enabled = false;
            ClearAddItemGroup();
            InvisibleComponent();
            dgvCart.Rows.Clear();
            supplierID = string.Empty;
            ClearSearchBox();
            txtSearchSupplier.Clear();
        }
        private void SelectSupplierPurchase()
        {
            grpPurchaseCart.Enabled = true;
            grpPurchaseInformation.Enabled = true;
            grpSelectProduct.Enabled = true;
            grpSelectProductDetail.Enabled = true;
            btnPurchaseFinalize.Enabled = true;
            btnPurchaseClear.Enabled = true;
        }
        private void frmPurchase_Load(object sender, EventArgs e)
        {
            ComboBoxList.CategoryList(cmbCategory);
            SetColumnWidth();
            cmbQuality.SelectedIndex = 2;
            TotalPurchaseAmount();
            NewPurchase();
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbCategory.SelectedIndex > 0)
            {
                categoryID = Convert.ToString(DBL.RetrieveData("Select top 1 * from Categories where Name='" + cmbCategory.Text.Trim() + "'").Rows[0]["CategoryID"]);
                ComboBoxList.ProductList(cmbProductList, categoryID);
            }
            else
            {
                categoryID = string.Empty;
                cmbProductList.Items.Clear();
            }
        }

        private void cmbProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProductList.SelectedIndex > 0)
            {

                DataTable dt = new DataTable();
                string productName = cmbProductList.Text.Trim();
                int indexofbr = productName.IndexOf("(");
                productName = productName.Substring(0, indexofbr).Trim();

                string proquality = cmbProductList.Text.Trim();
                int indexStart = proquality.IndexOf("(");
                int indexEnd = proquality.IndexOf(")");
                proquality = proquality.Substring(indexStart + 1);
                proquality = proquality.Substring(0, (proquality.Length - 1));

                dt = DBL.RetrieveData("Select top 1 * from Products where Name='" + productName + "' and CategoryId='" + categoryID + "' and Quality='"+proquality+"'");
                //dt = DBL.RetrieveData("Select top 1 * from Products where Name='" + productName + "' and CategoryId='" + categoryID + "'");
                if (dt.Rows.Count > 0)
                {
                    cmbQuality.Text = Convert.ToString(dt.Rows[0]["Quality"]);
                    lblSProductName.Text = Convert.ToString(dt.Rows[0]["Name"]);
                    lblSSoldQuantity.Text = Convert.ToString(dt.Rows[0]["Quantity"]);
                    lblQuality.Text = Convert.ToString(dt.Rows[0]["Quality"]);
                    lblSPUnitPrice.Text = Convert.ToString(dt.Rows[0]["UnitPrice"]);
                }
                else
                {
                    cmbQuality.SelectedIndex = 2;
                    lblSProductName.Text = "";
                    lblSSoldQuantity.Text = "";
                    lblSPUnitPrice.Text = "";
                    lblQuality.Text = "";
                }
            }
            else {
                cmbQuality.SelectedIndex = 2;
                lblSProductName.Text = "";
                lblSSoldQuantity.Text = "";
                lblSPUnitPrice.Text = "";
                lblQuality.Text = "";
            }

        }

        private void cmbQuality_SelectionChangeCommitted(object sender, EventArgs e)
        {
            epPurchase.Clear();
            if (cmbQuality.Text.Trim() == lblQuality.Text.Trim()) {
                return;
            }
            if (int.Parse(lblSSoldQuantity.Text) > 0)
            {
                epPurchase.SetError(cmbQuality, "Already some Products are available in Stock. \n Select Product Sold Quantity must be zero if you want to change Quality of a product");
                cmbQuality.Focus();
                cmbQuality.Text = lblQuality.Text;
                return;
            }
        }

        private void txtPurchaseQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPurchaseUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSaleUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPurchaseQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtPurchaseQuantity.Text.Trim().Length > 0 && txtPurchaseUnitPrice.Text.Trim().Length > 0)
            {

                int pquantity = 0;
                int punitprice = 0;
                pquantity = int.Parse(txtPurchaseQuantity.Text.Trim());
                punitprice = int.Parse(txtPurchaseUnitPrice.Text.Trim());
                txtItemCost.Text = Convert.ToString(pquantity * punitprice);

            }
            else {
                txtItemCost.Text = "0";
            }
        }

        private void txtPurchaseUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtPurchaseQuantity.Text.Trim().Length > 0 && txtPurchaseUnitPrice.Text.Trim().Length > 0)
            {

                int pquantity = 0;
                int punitprice = 0;
                pquantity = int.Parse(txtPurchaseQuantity.Text.Trim());
                punitprice = int.Parse(txtPurchaseUnitPrice.Text.Trim());
                txtItemCost.Text = Convert.ToString(pquantity * punitprice);

            }
            else
            {
                txtItemCost.Text = "0";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            epPurchase.Clear();
            if (cmbCategory.SelectedIndex == 0) {
                epPurchase.SetError(cmbCategory, "Please Select Category");
                cmbCategory.Focus();
                return;
            }
            if (cmbProductList.SelectedIndex == 0) {
                epPurchase.SetError(cmbProductList, "Please Select Products");
                cmbProductList.Focus();
                return;
            }
            if (cmbQuality.SelectedIndex == 0) {
                epPurchase.SetError(cmbQuality, "Please Select Product Quality");
                cmbQuality.Focus();
                return;
            }
            if (txtPurchaseQuantity.Text.Trim().Length == 0) {
                epPurchase.SetError(txtPurchaseQuantity, "Please Enter Purchase Quantity");
                txtPurchaseQuantity.Focus();
                return;
            }
            if (txtPurchaseUnitPrice.Text.Trim().Length == 0)
            {
                epPurchase.SetError(txtPurchaseUnitPrice, "Please Enter Purchase Unit Price");
                txtPurchaseUnitPrice.Focus();
                return;
            }
            if (txtSaleUnitPrice.Text.Trim().Length == 0)
            {
                epPurchase.SetError(txtSaleUnitPrice, "Please Enter Sale Unit Price");
                txtSaleUnitPrice.Focus();
                return;
            }
            if (txtItemCost.Text.Trim().Length == 0)
            {
                epPurchase.SetError(txtItemCost, "Please Enter Purchase Quanity and unit Price of Products Purchase");
                txtItemCost.Focus();
                return;
            }
            if (int.Parse(txtItemCost.Text.Trim()) == 0)
            {
                epPurchase.SetError(txtItemCost, "Please Enter Purchase Quanity and unit Price of Products Purchase");
                txtItemCost.Focus();
                return;
            }
            if (dgvCart.Rows.Count > 0) {
                foreach (DataGridViewRow product in dgvCart.Rows) {
                    if (cmbProductList.Text.Trim() == Convert.ToString(product.Cells[2].Value).Trim() && (cmbCategory.Text.Trim() == Convert.ToString(product.Cells[3].Value).Trim()) && (cmbQuality.Text.Trim() == Convert.ToString(product.Cells[4].Value).Trim())) {
                        epPurchase.SetError(cmbProductList, "Already is in Purchase Cart");
                        cmbProductList.Focus();
                        product.Selected = true;
                        return;
                    }
                }
            }

            string productID = string.Empty;
            string categoryID = string.Empty;
            DataTable dt = new DataTable();
            dt = DBL.RetrieveData("Select top 1 CategoryID from Categories where Name='" + cmbCategory.Text.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                categoryID = dt.Rows[0]["CategoryId"].ToString().Trim();

            }
            else {
                MessageBox.Show("Please restart the application");
                return;
            }
            DataTable dt1 = new DataTable();
            string productName = cmbProductList.Text.Trim();
            int indexofbr = productName.IndexOf("(");
            productName = productName.Substring(0, indexofbr).Trim();

            string proquality = cmbProductList.Text.Trim();
            int indexStart = proquality.IndexOf("(");
            int indexEnd = proquality.IndexOf(")");
            proquality = proquality.Substring(indexStart + 1);
            proquality = proquality.Substring(0, (proquality.Length - 1));


            dt1 = DBL.RetrieveData("select top 1 ProductId from Products where Name='" + productName.Trim() + "' and CategoryId='" + categoryID + "' and Quality='"+proquality+"'");
            if (dt1.Rows.Count > 0)
            {
                productID = dt1.Rows[0]["productID"].ToString().Trim();
            }
            else {
                MessageBox.Show("Please Restart the application");
                return;
            }

            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvCart);
            row.Cells[0].Value = productID;
            row.Cells[1].Value = categoryID;
            row.Cells[2].Value = cmbProductList.Text.Trim();
            row.Cells[3].Value = cmbCategory.Text.Trim();
            row.Cells[4].Value = cmbQuality.Text.Trim();
            row.Cells[5].Value = txtSaleUnitPrice.Text.Trim();
            row.Cells[6].Value = txtPurchaseQuantity.Text.Trim();
            row.Cells[7].Value = txtPurchaseUnitPrice.Text.Trim();
            row.Cells[8].Value = txtItemCost.Text.Trim();
            dgvCart.Rows.Add(row);
            ClearAddItemGroup();
            TotalPurchaseAmount();

        }
        private void ClearAddItemGroup() {
            cmbCategory.SelectedIndex = 0;
            txtPurchaseQuantity.Clear();
            txtPurchaseUnitPrice.Clear();
            txtSaleUnitPrice.Clear();
            txtItemCost.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAddItemGroup();
            TotalPurchaseAmount();
        }
        private void VisibleComponent() {
            btnUpdate.Visible = true;
            btnCancel.Visible = true;
            btnAdd.Visible = false;
            btnClear.Visible = false;
            dgvCart.Enabled = false;
            LnklblEditProducts.Enabled = false;
            LnklblDeleteSelectedProducts.Enabled = false;
        }
        private void InvisibleComponent() {
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnAdd.Visible = true;
            btnClear.Visible = true;
            dgvCart.Enabled = true;
            LnklblEditProducts.Enabled = true;
            LnklblDeleteSelectedProducts.Enabled = true;
            TotalPurchaseAmount();
        }
        private void LnklblEditProducts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgvCart.Rows.Count > 0)
            {
                if (dgvCart.SelectedRows.Count == 1)
                {
                    cmbCategory.Text = Convert.ToString(dgvCart.CurrentRow.Cells[3].Value);
                    cmbProductList.Text = Convert.ToString(dgvCart.CurrentRow.Cells[2].Value);
                    cmbQuality.Text=Convert.ToString(dgvCart.CurrentRow.Cells[4].Value);
                    txtSaleUnitPrice.Text=Convert.ToString(dgvCart.CurrentRow.Cells[5].Value);
                    txtPurchaseQuantity.Text=Convert.ToString(dgvCart.CurrentRow.Cells[6].Value);
                    txtPurchaseUnitPrice.Text=Convert.ToString(dgvCart.CurrentRow.Cells[7].Value);
                    txtItemCost.Text=Convert.ToString(dgvCart.CurrentRow.Cells[8].Value);
                    VisibleComponent();
                    
                }
                else {
                    MessageBox.Show("Please Select one Record");
                    return;
                }
            }
            else {
                MessageBox.Show("Purchase Cart is Empty");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAddItemGroup();
            InvisibleComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            epPurchase.Clear();
            if (cmbCategory.SelectedIndex == 0)
            {
                epPurchase.SetError(cmbCategory, "Please Select Category");
                cmbCategory.Focus();
                return;
            }
            if (cmbProductList.SelectedIndex == 0)
            {
                epPurchase.SetError(cmbProductList, "Please Select Products");
                cmbProductList.Focus();
                return;
            }
            if (cmbQuality.SelectedIndex == 0)
            {
                epPurchase.SetError(cmbQuality, "Please Select Product Quality");
                cmbQuality.Focus();
                return;
            }
            if (txtPurchaseQuantity.Text.Trim().Length == 0)
            {
                epPurchase.SetError(txtPurchaseQuantity, "Please Enter Purchase Quantity");
                txtPurchaseQuantity.Focus();
                return;
            }
            if (txtPurchaseUnitPrice.Text.Trim().Length == 0)
            {
                epPurchase.SetError(txtPurchaseUnitPrice, "Please Enter Purchase Unit Price");
                txtPurchaseUnitPrice.Focus();
                return;
            }
            if (txtSaleUnitPrice.Text.Trim().Length == 0)
            {
                epPurchase.SetError(txtSaleUnitPrice, "Please Enter Sale Unit Price");
                txtSaleUnitPrice.Focus();
                return;
            }
            if (txtItemCost.Text.Trim().Length == 0)
            {
                epPurchase.SetError(txtItemCost, "Please Enter Purchase Quanity and unit Price of Products Purchase");
                txtItemCost.Focus();
                return;
            }
            if (int.Parse(txtItemCost.Text.Trim()) == 0)
            {
                epPurchase.SetError(txtItemCost, "Please Enter Purchase Quanity and unit Price of Products Purchase");
                txtItemCost.Focus();
                return;
            }
            if (dgvCart.Rows.Count > 0)
            {
                int indexRow = dgvCart.CurrentRow.Index;
                foreach (DataGridViewRow product in dgvCart.Rows)
                {
                    if (indexRow != product.Index)
                    {
                        if (cmbProductList.Text.Trim() == Convert.ToString(product.Cells[2].Value).Trim() && (cmbCategory.Text.Trim() == Convert.ToString(product.Cells[3].Value).Trim()) && (cmbQuality.Text.Trim() == Convert.ToString(product.Cells[4].Value).Trim()))
                        {
                            epPurchase.SetError(cmbProductList, "Already is in Purchase Cart");
                            cmbProductList.Focus();
                            product.Selected = true;
                            return;
                        }
                    }
                }
            }

            string productID = string.Empty;
            string categoryID = string.Empty;
            DataTable dt = new DataTable();
            dt = DBL.RetrieveData("Select top 1 CategoryID from Categories where Name='" + cmbCategory.Text.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                categoryID = dt.Rows[0]["CategoryId"].ToString().Trim();

            }
            else
            {
                MessageBox.Show("Please restart the application");
                return;
            }
            DataTable dt1 = new DataTable();
            string productName = cmbProductList.Text.Trim();
            int indexofbr = productName.IndexOf("(");
            productName = productName.Substring(0, indexofbr).Trim();
            dt1 = DBL.RetrieveData("select top 1 ProductId from Products where Name='" + productName.Trim() + "' and CategoryId='" + categoryID + "'");
            if (dt1.Rows.Count > 0)
            {
                productID = dt1.Rows[0]["productID"].ToString().Trim();
            }
            else
            {
                MessageBox.Show("Please Restart the application");
                return;
            }
            dgvCart.CurrentRow.Cells[0].Value = productID;
            dgvCart.CurrentRow.Cells[1].Value = categoryID;
            dgvCart.CurrentRow.Cells[2].Value = cmbProductList.Text.Trim();
            dgvCart.CurrentRow.Cells[3].Value = cmbCategory.Text.Trim();
            dgvCart.CurrentRow.Cells[4].Value = cmbQuality.Text.Trim();
            dgvCart.CurrentRow.Cells[5].Value = txtSaleUnitPrice.Text.Trim();
            dgvCart.CurrentRow.Cells[6].Value = txtPurchaseQuantity.Text.Trim();
            dgvCart.CurrentRow.Cells[7].Value = txtPurchaseUnitPrice.Text.Trim();
            dgvCart.CurrentRow.Cells[8].Value = txtItemCost.Text.Trim();
            ClearAddItemGroup();
            InvisibleComponent();
        }

        private void LnklblDeleteSelectedProducts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dgvCart.Rows.Count > 0)
            {
                if (dgvCart.SelectedRows.Count == 1)
                {
                    if (MessageBox.Show("Are you sure you want to delete selected products from cart?","Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                        dgvCart.Rows.Remove(dgvCart.CurrentRow);
                        TotalPurchaseAmount();
                    }


                }
                else
                {
                    MessageBox.Show("Please Select one Record");
                    TotalPurchaseAmount();
                    return;
                }

            }
            else
            {
                MessageBox.Show("Purchase Cart is Empty");
            }
            TotalPurchaseAmount();
        }
        private void TotalPurchaseAmount() {
            if (dgvCart.Rows.Count > 0)
            {
                float totalAmount = 0;
                foreach (DataGridViewRow product in dgvCart.Rows)
                {
                    totalAmount = totalAmount + float.Parse(Convert.ToString(product.Cells[8].Value));
                    lblTotalAmount.Text = Convert.ToString(totalAmount);

                }
            }
            else
            {
                lblTotalAmount.Text = "0";
            }

        }

        private void btnPurchaseClear_Click(object sender, EventArgs e)
        {
            TotalPurchaseAmount();
        }

        private void btnPurchaseCancel_Click(object sender, EventArgs e)
        {
            NewPurchase();
        }

        private void btnPurchaseFinalize_Click(object sender, EventArgs e)
        {
            epPurchase.Clear();
            if (lblSupplierName.Text.Trim().Length == 0) {

                epPurchase.SetError(txtSearchSupplier,"Please first Search Supplier");
                txtSearchSupplier.Focus();
                return;
            }
            if (dgvCart.Rows.Count == 0) {
                MessageBox.Show("Purchase Cart is empty");
                return;
            }
            if (dgvCart.Rows.Count > 0) {
                int purchaseID=0;
                string query = string.Format("insert into Purchases(CompanyID,PurchaseDate,TotalAmount,Description) values('{0}','{1}','{2}','{3}')",supplierID.Trim(),dtpPurchaseDate.Value.ToString("yyyy/MM/dd"),lblTotalAmount.Text.Trim(),txtPurchaseDescription.Text.Trim());
                DBL.InsertData(query);
                DataTable dt = new DataTable();
                dt = DBL.RetrieveData("Select Max(PurchaseID) from Purchases where CompanyID='"+supplierID+"' and TotalAmount='"+lblTotalAmount.Text.Trim()+"'");
                if (dt.Rows.Count > 0)
                {
                    purchaseID = int.Parse(Convert.ToString(dt.Rows[0][0]).Trim());
                }
                else {
                    MessageBox.Show("Please Restart the Application");
                    return;
                }
                foreach (DataGridViewRow product in dgvCart.Rows) {
                    string productName = Convert.ToString(product.Cells[2].Value).Trim();
                    int indexofbr = productName.IndexOf("(");
                    productName = productName.Substring(0, indexofbr).Trim();
                    DBL.NewPurchase(int.Parse(supplierID.Trim()),purchaseID,Convert.ToInt32(Convert.ToString(product.Cells[0].Value)), productName,Convert.ToInt32(Convert.ToString(product.Cells[1].Value)),Convert.ToString(product.Cells[3].Value),float.Parse(Convert.ToString(product.Cells[6].Value)),float.Parse(Convert.ToString(product.Cells[7].Value)),float.Parse(Convert.ToString(product.Cells[5].Value)),Convert.ToString(product.Cells[4].Value));

                }
            }
            DataTable dt3 = new DataTable();
            dt3 = DBL.RetrieveData("Select Max(PurchaseID) from Purchases");
            if (dt3.Rows.Count == 1) {
                frmPurchaseDetailReport frm = new frmPurchaseDetailReport(Convert.ToString(dt3.Rows[0][0]).Trim());
                frm.ShowDialog();
            }
            NewPurchase();
            MessageBox.Show("Purchase Successfully");
        }
    }
    }
