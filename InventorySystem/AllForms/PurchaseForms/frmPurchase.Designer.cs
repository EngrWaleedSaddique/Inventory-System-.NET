namespace InventorySystem.AllForms.PurchaseForms
{
    partial class frmPurchase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchSupplier = new System.Windows.Forms.TextBox();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.epPurchase = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpPurchaseInformation = new System.Windows.Forms.GroupBox();
            this.dtpPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.txtPurchaseDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grpSelectProductDetail = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblSPUnitPrice = new System.Windows.Forms.Label();
            this.lblQuality = new System.Windows.Forms.Label();
            this.lblSSoldQuantity = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSProductName = new System.Windows.Forms.Label();
            this.grpSelectProduct = new System.Windows.Forms.GroupBox();
            this.cmbQuality = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtItemCost = new System.Windows.Forms.TextBox();
            this.txtSaleUnitPrice = new System.Windows.Forms.TextBox();
            this.txtPurchaseUnitPrice = new System.Windows.Forms.TextBox();
            this.txtPurchaseQuantity = new System.Windows.Forms.TextBox();
            this.cmbProductList = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.grpPurchaseCart = new System.Windows.Forms.GroupBox();
            this.LnklblDeleteSelectedProducts = new System.Windows.Forms.LinkLabel();
            this.LnklblEditProducts = new System.Windows.Forms.LinkLabel();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQuality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSaleUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPQTY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label19 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnPurchaseFinalize = new System.Windows.Forms.Button();
            this.btnPurchaseClear = new System.Windows.Forms.Button();
            this.btnPurchaseCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epPurchase)).BeginInit();
            this.grpPurchaseInformation.SuspendLayout();
            this.grpSelectProductDetail.SuspendLayout();
            this.grpSelectProduct.SuspendLayout();
            this.grpPurchaseCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearchSupplier);
            this.groupBox1.Controls.Add(this.lblSupplierName);
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Controls.Add(this.lblContactNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Supplier";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(104, 74);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchSupplier
            // 
            this.txtSearchSupplier.Location = new System.Drawing.Point(28, 48);
            this.txtSearchSupplier.Name = "txtSearchSupplier";
            this.txtSearchSupplier.Size = new System.Drawing.Size(151, 20);
            this.txtSearchSupplier.TabIndex = 2;
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSupplierName.Location = new System.Drawing.Point(320, 48);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(151, 23);
            this.lblSupplierName.TabIndex = 1;
            this.lblSupplierName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDescription
            // 
            this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDescription.Location = new System.Drawing.Point(320, 139);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(151, 55);
            this.lblDescription.TabIndex = 1;
            // 
            // lblContactNo
            // 
            this.lblContactNo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblContactNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblContactNo.Location = new System.Drawing.Point(28, 139);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(151, 23);
            this.lblContactNo.TabIndex = 1;
            this.lblContactNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Contact No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Supplier";
            // 
            // epPurchase
            // 
            this.epPurchase.ContainerControl = this;
            // 
            // grpPurchaseInformation
            // 
            this.grpPurchaseInformation.Controls.Add(this.dtpPurchaseDate);
            this.grpPurchaseInformation.Controls.Add(this.txtPurchaseDescription);
            this.grpPurchaseInformation.Controls.Add(this.label6);
            this.grpPurchaseInformation.Controls.Add(this.label5);
            this.grpPurchaseInformation.Location = new System.Drawing.Point(12, 246);
            this.grpPurchaseInformation.Name = "grpPurchaseInformation";
            this.grpPurchaseInformation.Size = new System.Drawing.Size(352, 178);
            this.grpPurchaseInformation.TabIndex = 1;
            this.grpPurchaseInformation.TabStop = false;
            this.grpPurchaseInformation.Text = "Purchase Information";
            // 
            // dtpPurchaseDate
            // 
            this.dtpPurchaseDate.CustomFormat = "DD MMMM, yyyy";
            this.dtpPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPurchaseDate.Location = new System.Drawing.Point(123, 45);
            this.dtpPurchaseDate.Name = "dtpPurchaseDate";
            this.dtpPurchaseDate.Size = new System.Drawing.Size(200, 20);
            this.dtpPurchaseDate.TabIndex = 3;
            // 
            // txtPurchaseDescription
            // 
            this.txtPurchaseDescription.Location = new System.Drawing.Point(123, 89);
            this.txtPurchaseDescription.Multiline = true;
            this.txtPurchaseDescription.Name = "txtPurchaseDescription";
            this.txtPurchaseDescription.Size = new System.Drawing.Size(200, 60);
            this.txtPurchaseDescription.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "PurchaseDate";
            // 
            // grpSelectProductDetail
            // 
            this.grpSelectProductDetail.Controls.Add(this.label12);
            this.grpSelectProductDetail.Controls.Add(this.label11);
            this.grpSelectProductDetail.Controls.Add(this.label10);
            this.grpSelectProductDetail.Controls.Add(this.lblSPUnitPrice);
            this.grpSelectProductDetail.Controls.Add(this.lblQuality);
            this.grpSelectProductDetail.Controls.Add(this.lblSSoldQuantity);
            this.grpSelectProductDetail.Controls.Add(this.label7);
            this.grpSelectProductDetail.Controls.Add(this.lblSProductName);
            this.grpSelectProductDetail.Location = new System.Drawing.Point(12, 448);
            this.grpSelectProductDetail.Name = "grpSelectProductDetail";
            this.grpSelectProductDetail.Size = new System.Drawing.Size(352, 177);
            this.grpSelectProductDetail.TabIndex = 2;
            this.grpSelectProductDetail.TabStop = false;
            this.grpSelectProductDetail.Text = "Select Product Details";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Purchase Unit Price";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(25, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Quality";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Sold Quantity";
            // 
            // lblSPUnitPrice
            // 
            this.lblSPUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSPUnitPrice.Location = new System.Drawing.Point(145, 131);
            this.lblSPUnitPrice.Name = "lblSPUnitPrice";
            this.lblSPUnitPrice.Size = new System.Drawing.Size(151, 23);
            this.lblSPUnitPrice.TabIndex = 1;
            this.lblSPUnitPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQuality
            // 
            this.lblQuality.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblQuality.Location = new System.Drawing.Point(145, 65);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(151, 23);
            this.lblQuality.TabIndex = 1;
            this.lblQuality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSSoldQuantity
            // 
            this.lblSSoldQuantity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSSoldQuantity.Location = new System.Drawing.Point(145, 97);
            this.lblSSoldQuantity.Name = "lblSSoldQuantity";
            this.lblSSoldQuantity.Size = new System.Drawing.Size(151, 23);
            this.lblSSoldQuantity.TabIndex = 1;
            this.lblSSoldQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Product Name";
            // 
            // lblSProductName
            // 
            this.lblSProductName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSProductName.Location = new System.Drawing.Point(144, 30);
            this.lblSProductName.Name = "lblSProductName";
            this.lblSProductName.Size = new System.Drawing.Size(151, 23);
            this.lblSProductName.TabIndex = 1;
            this.lblSProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpSelectProduct
            // 
            this.grpSelectProduct.Controls.Add(this.cmbQuality);
            this.grpSelectProduct.Controls.Add(this.btnCancel);
            this.grpSelectProduct.Controls.Add(this.btnUpdate);
            this.grpSelectProduct.Controls.Add(this.btnClear);
            this.grpSelectProduct.Controls.Add(this.btnAdd);
            this.grpSelectProduct.Controls.Add(this.txtItemCost);
            this.grpSelectProduct.Controls.Add(this.txtSaleUnitPrice);
            this.grpSelectProduct.Controls.Add(this.txtPurchaseUnitPrice);
            this.grpSelectProduct.Controls.Add(this.txtPurchaseQuantity);
            this.grpSelectProduct.Controls.Add(this.cmbProductList);
            this.grpSelectProduct.Controls.Add(this.cmbCategory);
            this.grpSelectProduct.Controls.Add(this.label8);
            this.grpSelectProduct.Controls.Add(this.label18);
            this.grpSelectProduct.Controls.Add(this.label17);
            this.grpSelectProduct.Controls.Add(this.label16);
            this.grpSelectProduct.Controls.Add(this.label15);
            this.grpSelectProduct.Controls.Add(this.label14);
            this.grpSelectProduct.Controls.Add(this.label13);
            this.grpSelectProduct.Location = new System.Drawing.Point(396, 246);
            this.grpSelectProduct.Name = "grpSelectProduct";
            this.grpSelectProduct.Size = new System.Drawing.Size(334, 379);
            this.grpSelectProduct.TabIndex = 3;
            this.grpSelectProduct.TabStop = false;
            this.grpSelectProduct.Text = "Select Product";
            // 
            // cmbQuality
            // 
            this.cmbQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuality.FormattingEnabled = true;
            this.cmbQuality.Items.AddRange(new object[] {
            "Select Quality",
            "Low",
            "Normal",
            "Best"});
            this.cmbQuality.Location = new System.Drawing.Point(118, 122);
            this.cmbQuality.Name = "cmbQuality";
            this.cmbQuality.Size = new System.Drawing.Size(100, 21);
            this.cmbQuality.TabIndex = 4;
            this.cmbQuality.SelectionChangeCommitted += new System.EventHandler(this.cmbQuality_SelectionChangeCommitted);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(87, 337);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(11, 337);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Visible = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(91, 337);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(10, 337);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtItemCost
            // 
            this.txtItemCost.Location = new System.Drawing.Point(118, 282);
            this.txtItemCost.Name = "txtItemCost";
            this.txtItemCost.ReadOnly = true;
            this.txtItemCost.Size = new System.Drawing.Size(100, 20);
            this.txtItemCost.TabIndex = 2;
            // 
            // txtSaleUnitPrice
            // 
            this.txtSaleUnitPrice.Location = new System.Drawing.Point(118, 242);
            this.txtSaleUnitPrice.Name = "txtSaleUnitPrice";
            this.txtSaleUnitPrice.Size = new System.Drawing.Size(100, 20);
            this.txtSaleUnitPrice.TabIndex = 2;
            this.txtSaleUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSaleUnitPrice_KeyPress);
            // 
            // txtPurchaseUnitPrice
            // 
            this.txtPurchaseUnitPrice.Location = new System.Drawing.Point(118, 202);
            this.txtPurchaseUnitPrice.Name = "txtPurchaseUnitPrice";
            this.txtPurchaseUnitPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPurchaseUnitPrice.TabIndex = 2;
            this.txtPurchaseUnitPrice.TextChanged += new System.EventHandler(this.txtPurchaseUnitPrice_TextChanged);
            this.txtPurchaseUnitPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPurchaseUnitPrice_KeyPress);
            // 
            // txtPurchaseQuantity
            // 
            this.txtPurchaseQuantity.Location = new System.Drawing.Point(118, 162);
            this.txtPurchaseQuantity.Name = "txtPurchaseQuantity";
            this.txtPurchaseQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtPurchaseQuantity.TabIndex = 2;
            this.txtPurchaseQuantity.TextChanged += new System.EventHandler(this.txtPurchaseQuantity_TextChanged);
            this.txtPurchaseQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPurchaseQuantity_KeyPress);
            // 
            // cmbProductList
            // 
            this.cmbProductList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductList.FormattingEnabled = true;
            this.cmbProductList.Location = new System.Drawing.Point(118, 82);
            this.cmbProductList.Name = "cmbProductList";
            this.cmbProductList.Size = new System.Drawing.Size(180, 21);
            this.cmbProductList.TabIndex = 1;
            this.cmbProductList.SelectedIndexChanged += new System.EventHandler(this.cmbProductList_SelectedIndexChanged);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(118, 42);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(180, 21);
            this.cmbCategory.TabIndex = 1;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Select Quality";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 285);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Item Cost";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 245);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 13);
            this.label17.TabIndex = 0;
            this.label17.Text = "Sale Unit Price";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 205);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(101, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Purchase Unit Price";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 165);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Purchase Quantity";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 85);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Select Product";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Select Category";
            // 
            // grpPurchaseCart
            // 
            this.grpPurchaseCart.Controls.Add(this.LnklblDeleteSelectedProducts);
            this.grpPurchaseCart.Controls.Add(this.LnklblEditProducts);
            this.grpPurchaseCart.Controls.Add(this.dgvCart);
            this.grpPurchaseCart.Controls.Add(this.label19);
            this.grpPurchaseCart.Controls.Add(this.lblTotalAmount);
            this.grpPurchaseCart.Location = new System.Drawing.Point(764, 12);
            this.grpPurchaseCart.Name = "grpPurchaseCart";
            this.grpPurchaseCart.Size = new System.Drawing.Size(515, 613);
            this.grpPurchaseCart.TabIndex = 4;
            this.grpPurchaseCart.TabStop = false;
            this.grpPurchaseCart.Text = "Purchase Cart";
            // 
            // LnklblDeleteSelectedProducts
            // 
            this.LnklblDeleteSelectedProducts.AutoSize = true;
            this.LnklblDeleteSelectedProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnklblDeleteSelectedProducts.ForeColor = System.Drawing.Color.Red;
            this.LnklblDeleteSelectedProducts.LinkColor = System.Drawing.Color.Red;
            this.LnklblDeleteSelectedProducts.Location = new System.Drawing.Point(324, 29);
            this.LnklblDeleteSelectedProducts.Name = "LnklblDeleteSelectedProducts";
            this.LnklblDeleteSelectedProducts.Size = new System.Drawing.Size(152, 13);
            this.LnklblDeleteSelectedProducts.TabIndex = 2;
            this.LnklblDeleteSelectedProducts.TabStop = true;
            this.LnklblDeleteSelectedProducts.Text = "Delete Selected Products";
            this.LnklblDeleteSelectedProducts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnklblDeleteSelectedProducts_LinkClicked);
            // 
            // LnklblEditProducts
            // 
            this.LnklblEditProducts.AutoSize = true;
            this.LnklblEditProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnklblEditProducts.Location = new System.Drawing.Point(178, 29);
            this.LnklblEditProducts.Name = "LnklblEditProducts";
            this.LnklblEditProducts.Size = new System.Drawing.Size(137, 13);
            this.LnklblEditProducts.TabIndex = 2;
            this.LnklblEditProducts.TabStop = true;
            this.LnklblEditProducts.Text = "Edit Selected Products";
            this.LnklblEditProducts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnklblEditProducts_LinkClicked);
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductId,
            this.ColCategoryId,
            this.ColProductName,
            this.ColCategory,
            this.ColQuality,
            this.ColSaleUnitPrice,
            this.ColPQTY,
            this.ColPUnitPrice,
            this.ColItemCost});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCart.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCart.Location = new System.Drawing.Point(34, 48);
            this.dgvCart.MultiSelect = false;
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(459, 527);
            this.dgvCart.TabIndex = 0;
            // 
            // ProductId
            // 
            this.ProductId.HeaderText = "pId";
            this.ProductId.Name = "ProductId";
            this.ProductId.ReadOnly = true;
            // 
            // ColCategoryId
            // 
            this.ColCategoryId.HeaderText = "cId";
            this.ColCategoryId.Name = "ColCategoryId";
            this.ColCategoryId.ReadOnly = true;
            // 
            // ColProductName
            // 
            this.ColProductName.HeaderText = "Product Name";
            this.ColProductName.Name = "ColProductName";
            this.ColProductName.ReadOnly = true;
            // 
            // ColCategory
            // 
            this.ColCategory.HeaderText = "Category";
            this.ColCategory.Name = "ColCategory";
            this.ColCategory.ReadOnly = true;
            // 
            // ColQuality
            // 
            this.ColQuality.HeaderText = "Quality";
            this.ColQuality.Name = "ColQuality";
            this.ColQuality.ReadOnly = true;
            // 
            // ColSaleUnitPrice
            // 
            this.ColSaleUnitPrice.HeaderText = "Sale Unit Price";
            this.ColSaleUnitPrice.Name = "ColSaleUnitPrice";
            this.ColSaleUnitPrice.ReadOnly = true;
            // 
            // ColPQTY
            // 
            this.ColPQTY.HeaderText = "Purchase Quantity";
            this.ColPQTY.Name = "ColPQTY";
            this.ColPQTY.ReadOnly = true;
            // 
            // ColPUnitPrice
            // 
            this.ColPUnitPrice.HeaderText = "Purchase Unit Price";
            this.ColPUnitPrice.Name = "ColPUnitPrice";
            this.ColPUnitPrice.ReadOnly = true;
            // 
            // ColItemCost
            // 
            this.ColItemCost.HeaderText = "Item Cost";
            this.ColItemCost.Name = "ColItemCost";
            this.ColItemCost.ReadOnly = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(245, 586);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(76, 13);
            this.label19.TabIndex = 0;
            this.label19.Text = "Total Amount :";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Red;
            this.lblTotalAmount.Location = new System.Drawing.Point(342, 581);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(151, 23);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "0.0";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPurchaseFinalize
            // 
            this.btnPurchaseFinalize.Enabled = false;
            this.btnPurchaseFinalize.Location = new System.Drawing.Point(827, 640);
            this.btnPurchaseFinalize.Name = "btnPurchaseFinalize";
            this.btnPurchaseFinalize.Size = new System.Drawing.Size(99, 50);
            this.btnPurchaseFinalize.TabIndex = 5;
            this.btnPurchaseFinalize.Text = "Finalize";
            this.btnPurchaseFinalize.UseVisualStyleBackColor = true;
            this.btnPurchaseFinalize.Click += new System.EventHandler(this.btnPurchaseFinalize_Click);
            // 
            // btnPurchaseClear
            // 
            this.btnPurchaseClear.Enabled = false;
            this.btnPurchaseClear.Location = new System.Drawing.Point(980, 640);
            this.btnPurchaseClear.Name = "btnPurchaseClear";
            this.btnPurchaseClear.Size = new System.Drawing.Size(99, 50);
            this.btnPurchaseClear.TabIndex = 5;
            this.btnPurchaseClear.Text = "Clear";
            this.btnPurchaseClear.UseVisualStyleBackColor = true;
            this.btnPurchaseClear.Click += new System.EventHandler(this.btnPurchaseClear_Click);
            // 
            // btnPurchaseCancel
            // 
            this.btnPurchaseCancel.Location = new System.Drawing.Point(1129, 640);
            this.btnPurchaseCancel.Name = "btnPurchaseCancel";
            this.btnPurchaseCancel.Size = new System.Drawing.Size(99, 50);
            this.btnPurchaseCancel.TabIndex = 5;
            this.btnPurchaseCancel.Text = "Cancel";
            this.btnPurchaseCancel.UseVisualStyleBackColor = true;
            this.btnPurchaseCancel.Click += new System.EventHandler(this.btnPurchaseCancel_Click);
            // 
            // frmPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1300, 702);
            this.Controls.Add(this.btnPurchaseCancel);
            this.Controls.Add(this.btnPurchaseClear);
            this.Controls.Add(this.btnPurchaseFinalize);
            this.Controls.Add(this.grpPurchaseCart);
            this.Controls.Add(this.grpSelectProduct);
            this.Controls.Add(this.grpSelectProductDetail);
            this.Controls.Add(this.grpPurchaseInformation);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Purchase";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPurchase_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epPurchase)).EndInit();
            this.grpPurchaseInformation.ResumeLayout(false);
            this.grpPurchaseInformation.PerformLayout();
            this.grpSelectProductDetail.ResumeLayout(false);
            this.grpSelectProductDetail.PerformLayout();
            this.grpSelectProduct.ResumeLayout(false);
            this.grpSelectProduct.PerformLayout();
            this.grpPurchaseCart.ResumeLayout(false);
            this.grpPurchaseCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.TextBox txtSearchSupplier;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ErrorProvider epPurchase;
        private System.Windows.Forms.GroupBox grpPurchaseInformation;
        private System.Windows.Forms.TextBox txtPurchaseDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpPurchaseDate;
        private System.Windows.Forms.GroupBox grpSelectProductDetail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSProductName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblSPUnitPrice;
        private System.Windows.Forms.Label lblSSoldQuantity;
        private System.Windows.Forms.GroupBox grpSelectProduct;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.ComboBox cmbProductList;
        private System.Windows.Forms.TextBox txtPurchaseQuantity;
        private System.Windows.Forms.TextBox txtPurchaseUnitPrice;
        private System.Windows.Forms.TextBox txtSaleUnitPrice;
        private System.Windows.Forms.TextBox txtItemCost;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grpPurchaseCart;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.LinkLabel LnklblEditProducts;
        private System.Windows.Forms.LinkLabel LnklblDeleteSelectedProducts;
        private System.Windows.Forms.Button btnPurchaseFinalize;
        private System.Windows.Forms.Button btnPurchaseCancel;
        private System.Windows.Forms.Button btnPurchaseClear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQuality;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSaleUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPQTY;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemCost;
        private System.Windows.Forms.ComboBox cmbQuality;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblQuality;
    }
}