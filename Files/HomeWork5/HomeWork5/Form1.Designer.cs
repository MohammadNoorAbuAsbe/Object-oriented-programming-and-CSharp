using System.Drawing;
namespace HomeWork5
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnAddProductToSeller;
        private System.Windows.Forms.Button btnAddProductToBuyerCart;
        private System.Windows.Forms.Button btnShowBuyers;
        private System.Windows.Forms.Button btnShowSellers;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtStreetName;
        private System.Windows.Forms.TextBox txtBuildingNumber;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.GroupBox UserInfo;
        private System.Windows.Forms.Label lblUserType;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnAddProductToSeller = new System.Windows.Forms.Button();
            this.btnAddProductToBuyerCart = new System.Windows.Forms.Button();
            this.btnShowBuyers = new System.Windows.Forms.Button();
            this.btnShowSellers = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtStreetName = new System.Windows.Forms.TextBox();
            this.txtBuildingNumber = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.UserInfo = new System.Windows.Forms.GroupBox();
            this.lblUserType = new System.Windows.Forms.Label();
            this.cmbUserType = new System.Windows.Forms.ComboBox();
            this.addUserButton = new System.Windows.Forms.Button();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblBuilding = new System.Windows.Forms.Label();
            this.lblStreet = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.AddProductToSellerGrp = new System.Windows.Forms.GroupBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblSelectSeller = new System.Windows.Forms.Label();
            this.chkSpecialPackaging = new System.Windows.Forms.CheckBox();
            this.cmbProductCategory = new System.Windows.Forms.ComboBox();
            this.BtnAddProduct = new System.Windows.Forms.Button();
            this.cmbSellers = new System.Windows.Forms.ComboBox();
            this.lblSpecialPackagingPrice = new System.Windows.Forms.Label();
            this.lblProductPrice = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtSpecialPackagingPrice = new System.Windows.Forms.TextBox();
            this.txtProductPrice = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.userInfoGrp = new System.Windows.Forms.GroupBox();
            this.listIProducts = new System.Windows.Forms.ListBox();
            this.lblShowCountry = new System.Windows.Forms.Label();
            this.lblShowCity = new System.Windows.Forms.Label();
            this.lblShowBuildingNumber = new System.Windows.Forms.Label();
            this.lblShowStreetName = new System.Windows.Forms.Label();
            this.lblShowPassword = new System.Windows.Forms.Label();
            this.lblUserProducts = new System.Windows.Forms.Label();
            this.lblShowAddress = new System.Windows.Forms.Label();
            this.lblShowUsername = new System.Windows.Forms.Label();
            this.ProductInfo = new System.Windows.Forms.GroupBox();
            this.lblShowProductTotalPrice = new System.Windows.Forms.Label();
            this.lblShowProductSpecialPrice = new System.Windows.Forms.Label();
            this.lblShowProductIsSpecial = new System.Windows.Forms.Label();
            this.lblShowProductCategory = new System.Windows.Forms.Label();
            this.lblShowProductSerialNumber = new System.Windows.Forms.Label();
            this.lblShowProductPrice = new System.Windows.Forms.Label();
            this.lblShowProductName = new System.Windows.Forms.Label();
            this.AddProductToBuyerGrp = new System.Windows.Forms.GroupBox();
            this.lblSelectProduct = new System.Windows.Forms.Label();
            this.lblSelectBuyer = new System.Windows.Forms.Label();
            this.cmbBuyers = new System.Windows.Forms.ComboBox();
            this.listProductsBuy = new System.Windows.Forms.ListBox();
            this.btnBuyProduct = new System.Windows.Forms.Button();
            this.btnReturnToMain = new System.Windows.Forms.Button();
            this.SelectAUserToViewGrp = new System.Windows.Forms.GroupBox();
            this.panelButtons.SuspendLayout();
            this.UserInfo.SuspendLayout();
            this.AddProductToSellerGrp.SuspendLayout();
            this.userInfoGrp.SuspendLayout();
            this.ProductInfo.SuspendLayout();
            this.AddProductToBuyerGrp.SuspendLayout();
            this.SelectAUserToViewGrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAddUser.FlatAppearance.BorderSize = 0;
            this.btnAddUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Location = new System.Drawing.Point(11, 13);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(180, 40);
            this.btnAddUser.TabIndex = 0;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.BtnAddUser_Click);
            // 
            // btnAddProductToSeller
            // 
            this.btnAddProductToSeller.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAddProductToSeller.FlatAppearance.BorderSize = 0;
            this.btnAddProductToSeller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProductToSeller.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddProductToSeller.ForeColor = System.Drawing.Color.White;
            this.btnAddProductToSeller.Location = new System.Drawing.Point(197, 13);
            this.btnAddProductToSeller.Name = "btnAddProductToSeller";
            this.btnAddProductToSeller.Size = new System.Drawing.Size(180, 40);
            this.btnAddProductToSeller.TabIndex = 2;
            this.btnAddProductToSeller.Text = "Add Product to Seller";
            this.btnAddProductToSeller.UseVisualStyleBackColor = true;
            this.btnAddProductToSeller.Click += new System.EventHandler(this.BtnAddProductToSeller_Click);
            // 
            // btnAddProductToBuyerCart
            // 
            this.btnAddProductToBuyerCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnAddProductToBuyerCart.FlatAppearance.BorderSize = 0;
            this.btnAddProductToBuyerCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProductToBuyerCart.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddProductToBuyerCart.ForeColor = System.Drawing.Color.White;
            this.btnAddProductToBuyerCart.Location = new System.Drawing.Point(197, 59);
            this.btnAddProductToBuyerCart.Name = "btnAddProductToBuyerCart";
            this.btnAddProductToBuyerCart.Size = new System.Drawing.Size(180, 40);
            this.btnAddProductToBuyerCart.TabIndex = 3;
            this.btnAddProductToBuyerCart.Text = "Add Product to Buyer Cart";
            this.btnAddProductToBuyerCart.UseVisualStyleBackColor = true;
            this.btnAddProductToBuyerCart.Click += new System.EventHandler(this.BtnAddProductToBuyerCart_Click);
            // 
            // btnShowBuyers
            // 
            this.btnShowBuyers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnShowBuyers.FlatAppearance.BorderSize = 0;
            this.btnShowBuyers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowBuyers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnShowBuyers.ForeColor = System.Drawing.Color.White;
            this.btnShowBuyers.Location = new System.Drawing.Point(384, 58);
            this.btnShowBuyers.Name = "btnShowBuyers";
            this.btnShowBuyers.Size = new System.Drawing.Size(180, 40);
            this.btnShowBuyers.TabIndex = 4;
            this.btnShowBuyers.Text = "Show Buyers";
            this.btnShowBuyers.UseVisualStyleBackColor = true;
            this.btnShowBuyers.Click += new System.EventHandler(this.BtnShowBuyers_Click);
            // 
            // btnShowSellers
            // 
            this.btnShowSellers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnShowSellers.FlatAppearance.BorderSize = 0;
            this.btnShowSellers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowSellers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnShowSellers.ForeColor = System.Drawing.Color.White;
            this.btnShowSellers.Location = new System.Drawing.Point(383, 12);
            this.btnShowSellers.Name = "btnShowSellers";
            this.btnShowSellers.Size = new System.Drawing.Size(180, 40);
            this.btnShowSellers.TabIndex = 5;
            this.btnShowSellers.Text = "Show Sellers";
            this.btnShowSellers.UseVisualStyleBackColor = true;
            this.btnShowSellers.Click += new System.EventHandler(this.BtnShowSellers_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(10, 58);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(180, 40);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.LightGray;
            this.panelButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButtons.Controls.Add(this.btnAddUser);
            this.panelButtons.Controls.Add(this.btnAddProductToSeller);
            this.panelButtons.Controls.Add(this.btnAddProductToBuyerCart);
            this.panelButtons.Controls.Add(this.btnShowBuyers);
            this.panelButtons.Controls.Add(this.btnShowSellers);
            this.panelButtons.Controls.Add(this.btnExit);
            this.panelButtons.Location = new System.Drawing.Point(443, 12);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Padding = new System.Windows.Forms.Padding(10);
            this.panelButtons.Size = new System.Drawing.Size(579, 121);
            this.panelButtons.TabIndex = 1;
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(18, 29);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(318, 147);
            this.listBoxUsers.TabIndex = 0;
            this.listBoxUsers.SelectedIndexChanged += new System.EventHandler(this.ListBoxUsers_SelectedIndexChanged);
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Location = new System.Drawing.Point(237, 31);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(151, 20);
            this.txtUsername.TabIndex = 6;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Arial", 10F);
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.Location = new System.Drawing.Point(237, 60);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(150, 23);
            this.txtPassword.TabIndex = 0;
            // 
            // txtStreetName
            // 
            this.txtStreetName.BackColor = System.Drawing.Color.White;
            this.txtStreetName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStreetName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtStreetName.ForeColor = System.Drawing.Color.Black;
            this.txtStreetName.Location = new System.Drawing.Point(237, 89);
            this.txtStreetName.Name = "txtStreetName";
            this.txtStreetName.Size = new System.Drawing.Size(150, 23);
            this.txtStreetName.TabIndex = 0;
            // 
            // txtBuildingNumber
            // 
            this.txtBuildingNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuildingNumber.Font = new System.Drawing.Font("Arial", 10F);
            this.txtBuildingNumber.ForeColor = System.Drawing.Color.Black;
            this.txtBuildingNumber.Location = new System.Drawing.Point(237, 118);
            this.txtBuildingNumber.Name = "txtBuildingNumber";
            this.txtBuildingNumber.Size = new System.Drawing.Size(150, 23);
            this.txtBuildingNumber.TabIndex = 0;
            // 
            // txtCity
            // 
            this.txtCity.BackColor = System.Drawing.Color.White;
            this.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCity.Font = new System.Drawing.Font("Arial", 10F);
            this.txtCity.ForeColor = System.Drawing.Color.Black;
            this.txtCity.Location = new System.Drawing.Point(237, 149);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(150, 23);
            this.txtCity.TabIndex = 0;
            // 
            // txtCountry
            // 
            this.txtCountry.BackColor = System.Drawing.Color.White;
            this.txtCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCountry.Font = new System.Drawing.Font("Arial", 10F);
            this.txtCountry.ForeColor = System.Drawing.Color.Black;
            this.txtCountry.Location = new System.Drawing.Point(237, 178);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(150, 23);
            this.txtCountry.TabIndex = 0;
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(24, 31);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 23);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "User name:";
            // 
            // UserInfo
            // 
            this.UserInfo.Controls.Add(this.lblUserType);
            this.UserInfo.Controls.Add(this.cmbUserType);
            this.UserInfo.Controls.Add(this.addUserButton);
            this.UserInfo.Controls.Add(this.lblCountry);
            this.UserInfo.Controls.Add(this.lblCity);
            this.UserInfo.Controls.Add(this.lblBuilding);
            this.UserInfo.Controls.Add(this.lblStreet);
            this.UserInfo.Controls.Add(this.lblPassword);
            this.UserInfo.Controls.Add(this.txtUsername);
            this.UserInfo.Controls.Add(this.lblUsername);
            this.UserInfo.Controls.Add(this.txtPassword);
            this.UserInfo.Controls.Add(this.txtStreetName);
            this.UserInfo.Controls.Add(this.txtBuildingNumber);
            this.UserInfo.Controls.Add(this.txtCity);
            this.UserInfo.Controls.Add(this.txtCountry);
            this.UserInfo.Location = new System.Drawing.Point(12, 95);
            this.UserInfo.Name = "UserInfo";
            this.UserInfo.Size = new System.Drawing.Size(425, 270);
            this.UserInfo.TabIndex = 7;
            this.UserInfo.TabStop = false;
            this.UserInfo.Text = "Please Enter The User Info";
            this.UserInfo.Visible = false;
            // 
            // lblUserType
            // 
            this.lblUserType.Location = new System.Drawing.Point(24, 205);
            this.lblUserType.Name = "lblUserType";
            this.lblUserType.Size = new System.Drawing.Size(100, 23);
            this.lblUserType.TabIndex = 13;
            this.lblUserType.Text = "User Type:";
            // 
            // cmbUserType
            // 
            this.cmbUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserType.FormattingEnabled = true;
            this.cmbUserType.Items.AddRange(new object[] {
            "Buyer",
            "Seller"});
            this.cmbUserType.Location = new System.Drawing.Point(237, 207);
            this.cmbUserType.Name = "cmbUserType";
            this.cmbUserType.Size = new System.Drawing.Size(151, 21);
            this.cmbUserType.TabIndex = 13;
            // 
            // addUserButton
            // 
            this.addUserButton.Location = new System.Drawing.Point(150, 228);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(75, 23);
            this.addUserButton.TabIndex = 12;
            this.addUserButton.Text = "Add";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.AddUser);
            // 
            // lblCountry
            // 
            this.lblCountry.Location = new System.Drawing.Point(24, 178);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(100, 23);
            this.lblCountry.TabIndex = 11;
            this.lblCountry.Text = "Country:";
            // 
            // lblCity
            // 
            this.lblCity.Location = new System.Drawing.Point(24, 149);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(100, 23);
            this.lblCity.TabIndex = 10;
            this.lblCity.Text = "City:";
            // 
            // lblBuilding
            // 
            this.lblBuilding.Location = new System.Drawing.Point(24, 118);
            this.lblBuilding.Name = "lblBuilding";
            this.lblBuilding.Size = new System.Drawing.Size(100, 23);
            this.lblBuilding.TabIndex = 9;
            this.lblBuilding.Text = "Building number:";
            // 
            // lblStreet
            // 
            this.lblStreet.Location = new System.Drawing.Point(24, 89);
            this.lblStreet.Name = "lblStreet";
            this.lblStreet.Size = new System.Drawing.Size(100, 23);
            this.lblStreet.TabIndex = 8;
            this.lblStreet.Text = "Street name:";
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(24, 60);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(100, 23);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Password:";
            // 
            // AddProductToSellerGrp
            // 
            this.AddProductToSellerGrp.Controls.Add(this.lblCategory);
            this.AddProductToSellerGrp.Controls.Add(this.lblSelectSeller);
            this.AddProductToSellerGrp.Controls.Add(this.chkSpecialPackaging);
            this.AddProductToSellerGrp.Controls.Add(this.cmbProductCategory);
            this.AddProductToSellerGrp.Controls.Add(this.BtnAddProduct);
            this.AddProductToSellerGrp.Controls.Add(this.cmbSellers);
            this.AddProductToSellerGrp.Controls.Add(this.lblSpecialPackagingPrice);
            this.AddProductToSellerGrp.Controls.Add(this.lblProductPrice);
            this.AddProductToSellerGrp.Controls.Add(this.lblProductName);
            this.AddProductToSellerGrp.Controls.Add(this.txtSpecialPackagingPrice);
            this.AddProductToSellerGrp.Controls.Add(this.txtProductPrice);
            this.AddProductToSellerGrp.Controls.Add(this.txtProductName);
            this.AddProductToSellerGrp.Location = new System.Drawing.Point(12, 371);
            this.AddProductToSellerGrp.Name = "AddProductToSellerGrp";
            this.AddProductToSellerGrp.Size = new System.Drawing.Size(425, 270);
            this.AddProductToSellerGrp.TabIndex = 8;
            this.AddProductToSellerGrp.TabStop = false;
            this.AddProductToSellerGrp.Text = "Please Enter The Product Info";
            this.AddProductToSellerGrp.Visible = false;
            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(24, 89);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(5);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(100, 25);
            this.lblCategory.TabIndex = 22;
            this.lblCategory.Text = "Category:";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSelectSeller
            // 
            this.lblSelectSeller.Location = new System.Drawing.Point(24, 30);
            this.lblSelectSeller.Margin = new System.Windows.Forms.Padding(5);
            this.lblSelectSeller.Name = "lblSelectSeller";
            this.lblSelectSeller.Size = new System.Drawing.Size(100, 25);
            this.lblSelectSeller.TabIndex = 21;
            this.lblSelectSeller.Text = "Select A Seller:";
            this.lblSelectSeller.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkSpecialPackaging
            // 
            this.chkSpecialPackaging.AutoSize = true;
            this.chkSpecialPackaging.Location = new System.Drawing.Point(27, 154);
            this.chkSpecialPackaging.Margin = new System.Windows.Forms.Padding(5);
            this.chkSpecialPackaging.Name = "chkSpecialPackaging";
            this.chkSpecialPackaging.Size = new System.Drawing.Size(164, 17);
            this.chkSpecialPackaging.TabIndex = 20;
            this.chkSpecialPackaging.Text = "Has Special Packaging Price";
            this.chkSpecialPackaging.UseVisualStyleBackColor = true;
            this.chkSpecialPackaging.CheckedChanged += new System.EventHandler(this.ChkSpecialPackaging_CheckedChanged);
            // 
            // cmbProductCategory
            // 
            this.cmbProductCategory.FormattingEnabled = true;
            this.cmbProductCategory.Location = new System.Drawing.Point(237, 89);
            this.cmbProductCategory.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProductCategory.Name = "cmbProductCategory";
            this.cmbProductCategory.Size = new System.Drawing.Size(125, 21);
            this.cmbProductCategory.TabIndex = 19;
            // 
            // BtnAddProduct
            // 
            this.BtnAddProduct.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnAddProduct.Location = new System.Drawing.Point(94, 214);
            this.BtnAddProduct.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAddProduct.Name = "BtnAddProduct";
            this.BtnAddProduct.Size = new System.Drawing.Size(177, 36);
            this.BtnAddProduct.TabIndex = 18;
            this.BtnAddProduct.Text = "Add Product";
            this.BtnAddProduct.UseVisualStyleBackColor = true;
            this.BtnAddProduct.Click += new System.EventHandler(this.AddProductToSeller);
            // 
            // cmbSellers
            // 
            this.cmbSellers.FormattingEnabled = true;
            this.cmbSellers.Location = new System.Drawing.Point(237, 30);
            this.cmbSellers.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSellers.Name = "cmbSellers";
            this.cmbSellers.Size = new System.Drawing.Size(125, 21);
            this.cmbSellers.TabIndex = 17;
            // 
            // lblSpecialPackagingPrice
            // 
            this.lblSpecialPackagingPrice.Location = new System.Drawing.Point(24, 181);
            this.lblSpecialPackagingPrice.Margin = new System.Windows.Forms.Padding(5);
            this.lblSpecialPackagingPrice.Name = "lblSpecialPackagingPrice";
            this.lblSpecialPackagingPrice.Size = new System.Drawing.Size(150, 25);
            this.lblSpecialPackagingPrice.TabIndex = 16;
            this.lblSpecialPackagingPrice.Text = "Special packaging price:";
            this.lblSpecialPackagingPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSpecialPackagingPrice.Visible = false;
            // 
            // lblProductPrice
            // 
            this.lblProductPrice.Location = new System.Drawing.Point(24, 119);
            this.lblProductPrice.Margin = new System.Windows.Forms.Padding(5);
            this.lblProductPrice.Name = "lblProductPrice";
            this.lblProductPrice.Size = new System.Drawing.Size(100, 25);
            this.lblProductPrice.TabIndex = 15;
            this.lblProductPrice.Text = "Product price:";
            this.lblProductPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProductName
            // 
            this.lblProductName.Location = new System.Drawing.Point(24, 60);
            this.lblProductName.Margin = new System.Windows.Forms.Padding(5);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(100, 25);
            this.lblProductName.TabIndex = 14;
            this.lblProductName.Text = "Product name:";
            this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSpecialPackagingPrice
            // 
            this.txtSpecialPackagingPrice.Location = new System.Drawing.Point(237, 186);
            this.txtSpecialPackagingPrice.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.txtSpecialPackagingPrice.Name = "txtSpecialPackagingPrice";
            this.txtSpecialPackagingPrice.Size = new System.Drawing.Size(125, 20);
            this.txtSpecialPackagingPrice.TabIndex = 2;
            this.txtSpecialPackagingPrice.Visible = false;
            // 
            // txtProductPrice
            // 
            this.txtProductPrice.Location = new System.Drawing.Point(237, 119);
            this.txtProductPrice.Margin = new System.Windows.Forms.Padding(5);
            this.txtProductPrice.Name = "txtProductPrice";
            this.txtProductPrice.Size = new System.Drawing.Size(125, 20);
            this.txtProductPrice.TabIndex = 1;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(237, 60);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(5);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(125, 20);
            this.txtProductName.TabIndex = 0;
            // 
            // userInfoGrp
            // 
            this.userInfoGrp.Controls.Add(this.listIProducts);
            this.userInfoGrp.Controls.Add(this.lblShowCountry);
            this.userInfoGrp.Controls.Add(this.lblShowCity);
            this.userInfoGrp.Controls.Add(this.lblShowBuildingNumber);
            this.userInfoGrp.Controls.Add(this.lblShowStreetName);
            this.userInfoGrp.Controls.Add(this.lblShowPassword);
            this.userInfoGrp.Controls.Add(this.lblUserProducts);
            this.userInfoGrp.Controls.Add(this.lblShowAddress);
            this.userInfoGrp.Controls.Add(this.lblShowUsername);
            this.userInfoGrp.Location = new System.Drawing.Point(820, 165);
            this.userInfoGrp.Name = "userInfoGrp";
            this.userInfoGrp.Size = new System.Drawing.Size(494, 200);
            this.userInfoGrp.TabIndex = 9;
            this.userInfoGrp.TabStop = false;
            this.userInfoGrp.Text = "User Info";
            this.userInfoGrp.Visible = false;
            // 
            // listIProducts
            // 
            this.listIProducts.FormattingEnabled = true;
            this.listIProducts.Location = new System.Drawing.Point(210, 51);
            this.listIProducts.Name = "listIProducts";
            this.listIProducts.Size = new System.Drawing.Size(272, 134);
            this.listIProducts.TabIndex = 13;
            this.listIProducts.SelectedIndexChanged += new System.EventHandler(this.ListItems_SelectedIndexChanged);
            // 
            // lblShowCountry
            // 
            this.lblShowCountry.Location = new System.Drawing.Point(17, 168);
            this.lblShowCountry.Name = "lblShowCountry";
            this.lblShowCountry.Size = new System.Drawing.Size(100, 23);
            this.lblShowCountry.TabIndex = 12;
            this.lblShowCountry.Text = "Country:";
            // 
            // lblShowCity
            // 
            this.lblShowCity.Location = new System.Drawing.Point(17, 145);
            this.lblShowCity.Name = "lblShowCity";
            this.lblShowCity.Size = new System.Drawing.Size(100, 23);
            this.lblShowCity.TabIndex = 11;
            this.lblShowCity.Text = "City:";
            // 
            // lblShowBuildingNumber
            // 
            this.lblShowBuildingNumber.Location = new System.Drawing.Point(17, 122);
            this.lblShowBuildingNumber.Name = "lblShowBuildingNumber";
            this.lblShowBuildingNumber.Size = new System.Drawing.Size(100, 23);
            this.lblShowBuildingNumber.TabIndex = 10;
            this.lblShowBuildingNumber.Text = "Building number:";
            // 
            // lblShowStreetName
            // 
            this.lblShowStreetName.Location = new System.Drawing.Point(17, 99);
            this.lblShowStreetName.Name = "lblShowStreetName";
            this.lblShowStreetName.Size = new System.Drawing.Size(100, 23);
            this.lblShowStreetName.TabIndex = 9;
            this.lblShowStreetName.Text = "Street name:";
            // 
            // lblShowPassword
            // 
            this.lblShowPassword.Location = new System.Drawing.Point(17, 48);
            this.lblShowPassword.Name = "lblShowPassword";
            this.lblShowPassword.Size = new System.Drawing.Size(100, 23);
            this.lblShowPassword.TabIndex = 8;
            this.lblShowPassword.Text = "Password:";
            // 
            // lblUserProducts
            // 
            this.lblUserProducts.Location = new System.Drawing.Point(268, 25);
            this.lblUserProducts.Name = "lblUserProducts";
            this.lblUserProducts.Size = new System.Drawing.Size(151, 23);
            this.lblUserProducts.TabIndex = 4;
            this.lblUserProducts.Text = "Products:";
            this.lblUserProducts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShowAddress
            // 
            this.lblShowAddress.Location = new System.Drawing.Point(17, 76);
            this.lblShowAddress.Name = "lblShowAddress";
            this.lblShowAddress.Size = new System.Drawing.Size(100, 23);
            this.lblShowAddress.TabIndex = 3;
            this.lblShowAddress.Text = "Address:";
            // 
            // lblShowUsername
            // 
            this.lblShowUsername.Location = new System.Drawing.Point(17, 25);
            this.lblShowUsername.Name = "lblShowUsername";
            this.lblShowUsername.Size = new System.Drawing.Size(100, 23);
            this.lblShowUsername.TabIndex = 1;
            this.lblShowUsername.Text = "User name:";
            // 
            // ProductInfo
            // 
            this.ProductInfo.Controls.Add(this.lblShowProductTotalPrice);
            this.ProductInfo.Controls.Add(this.lblShowProductSpecialPrice);
            this.ProductInfo.Controls.Add(this.lblShowProductIsSpecial);
            this.ProductInfo.Controls.Add(this.lblShowProductCategory);
            this.ProductInfo.Controls.Add(this.lblShowProductSerialNumber);
            this.ProductInfo.Controls.Add(this.lblShowProductPrice);
            this.ProductInfo.Controls.Add(this.lblShowProductName);
            this.ProductInfo.Location = new System.Drawing.Point(960, 371);
            this.ProductInfo.Name = "ProductInfo";
            this.ProductInfo.Size = new System.Drawing.Size(354, 270);
            this.ProductInfo.TabIndex = 10;
            this.ProductInfo.TabStop = false;
            this.ProductInfo.Text = "Product Info";
            this.ProductInfo.Visible = false;
            // 
            // lblShowProductTotalPrice
            // 
            this.lblShowProductTotalPrice.Location = new System.Drawing.Point(17, 176);
            this.lblShowProductTotalPrice.Name = "lblShowProductTotalPrice";
            this.lblShowProductTotalPrice.Size = new System.Drawing.Size(165, 23);
            this.lblShowProductTotalPrice.TabIndex = 12;
            this.lblShowProductTotalPrice.Text = "Total Price: ";
            // 
            // lblShowProductSpecialPrice
            // 
            this.lblShowProductSpecialPrice.Location = new System.Drawing.Point(17, 149);
            this.lblShowProductSpecialPrice.Name = "lblShowProductSpecialPrice";
            this.lblShowProductSpecialPrice.Size = new System.Drawing.Size(165, 23);
            this.lblShowProductSpecialPrice.TabIndex = 11;
            this.lblShowProductSpecialPrice.Text = "Special Packaging Price: ";
            // 
            // lblShowProductIsSpecial
            // 
            this.lblShowProductIsSpecial.Location = new System.Drawing.Point(17, 122);
            this.lblShowProductIsSpecial.Name = "lblShowProductIsSpecial";
            this.lblShowProductIsSpecial.Size = new System.Drawing.Size(195, 23);
            this.lblShowProductIsSpecial.TabIndex = 10;
            this.lblShowProductIsSpecial.Text = "Has a Special Packaging Price: ";
            // 
            // lblShowProductCategory
            // 
            this.lblShowProductCategory.Location = new System.Drawing.Point(17, 99);
            this.lblShowProductCategory.Name = "lblShowProductCategory";
            this.lblShowProductCategory.Size = new System.Drawing.Size(100, 23);
            this.lblShowProductCategory.TabIndex = 9;
            this.lblShowProductCategory.Text = "Category: ";
            // 
            // lblShowProductSerialNumber
            // 
            this.lblShowProductSerialNumber.Location = new System.Drawing.Point(17, 48);
            this.lblShowProductSerialNumber.Name = "lblShowProductSerialNumber";
            this.lblShowProductSerialNumber.Size = new System.Drawing.Size(100, 23);
            this.lblShowProductSerialNumber.TabIndex = 8;
            this.lblShowProductSerialNumber.Text = "Serial Number: ";
            // 
            // lblShowProductPrice
            // 
            this.lblShowProductPrice.Location = new System.Drawing.Point(17, 76);
            this.lblShowProductPrice.Name = "lblShowProductPrice";
            this.lblShowProductPrice.Size = new System.Drawing.Size(100, 23);
            this.lblShowProductPrice.TabIndex = 3;
            this.lblShowProductPrice.Text = "Price: ";
            // 
            // lblShowProductName
            // 
            this.lblShowProductName.Location = new System.Drawing.Point(17, 25);
            this.lblShowProductName.Name = "lblShowProductName";
            this.lblShowProductName.Size = new System.Drawing.Size(100, 23);
            this.lblShowProductName.TabIndex = 1;
            this.lblShowProductName.Text = "Name: ";
            // 
            // AddProductToBuyerGrp
            // 
            this.AddProductToBuyerGrp.Controls.Add(this.lblSelectProduct);
            this.AddProductToBuyerGrp.Controls.Add(this.lblSelectBuyer);
            this.AddProductToBuyerGrp.Controls.Add(this.cmbBuyers);
            this.AddProductToBuyerGrp.Controls.Add(this.listProductsBuy);
            this.AddProductToBuyerGrp.Controls.Add(this.btnBuyProduct);
            this.AddProductToBuyerGrp.Location = new System.Drawing.Point(443, 371);
            this.AddProductToBuyerGrp.Name = "AddProductToBuyerGrp";
            this.AddProductToBuyerGrp.Size = new System.Drawing.Size(511, 270);
            this.AddProductToBuyerGrp.TabIndex = 11;
            this.AddProductToBuyerGrp.TabStop = false;
            this.AddProductToBuyerGrp.Text = "Add a Product to the Cart";
            this.AddProductToBuyerGrp.Visible = false;
            // 
            // lblSelectProduct
            // 
            this.lblSelectProduct.Location = new System.Drawing.Point(218, 24);
            this.lblSelectProduct.Name = "lblSelectProduct";
            this.lblSelectProduct.Size = new System.Drawing.Size(100, 23);
            this.lblSelectProduct.TabIndex = 23;
            this.lblSelectProduct.Text = "Select A Product:";
            // 
            // lblSelectBuyer
            // 
            this.lblSelectBuyer.Location = new System.Drawing.Point(8, 27);
            this.lblSelectBuyer.Margin = new System.Windows.Forms.Padding(5);
            this.lblSelectBuyer.Name = "lblSelectBuyer";
            this.lblSelectBuyer.Size = new System.Drawing.Size(100, 25);
            this.lblSelectBuyer.TabIndex = 22;
            this.lblSelectBuyer.Text = "Select A Buyer:";
            this.lblSelectBuyer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbBuyers
            // 
            this.cmbBuyers.FormattingEnabled = true;
            this.cmbBuyers.Location = new System.Drawing.Point(11, 61);
            this.cmbBuyers.Name = "cmbBuyers";
            this.cmbBuyers.Size = new System.Drawing.Size(92, 21);
            this.cmbBuyers.TabIndex = 21;
            // 
            // listProductsBuy
            // 
            this.listProductsBuy.FormattingEnabled = true;
            this.listProductsBuy.Location = new System.Drawing.Point(221, 59);
            this.listProductsBuy.Name = "listProductsBuy";
            this.listProductsBuy.Size = new System.Drawing.Size(272, 147);
            this.listProductsBuy.TabIndex = 20;
            this.listProductsBuy.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // btnBuyProduct
            // 
            this.btnBuyProduct.Location = new System.Drawing.Point(11, 178);
            this.btnBuyProduct.Name = "btnBuyProduct";
            this.btnBuyProduct.Size = new System.Drawing.Size(189, 36);
            this.btnBuyProduct.TabIndex = 19;
            this.btnBuyProduct.Text = "Add Product";
            this.btnBuyProduct.UseVisualStyleBackColor = true;
            this.btnBuyProduct.Click += new System.EventHandler(this.BtnAddToCart_Click);
            // 
            // btnReturnToMain
            // 
            this.btnReturnToMain.Location = new System.Drawing.Point(12, 25);
            this.btnReturnToMain.Name = "btnReturnToMain";
            this.btnReturnToMain.Size = new System.Drawing.Size(77, 33);
            this.btnReturnToMain.TabIndex = 12;
            this.btnReturnToMain.Text = "Return";
            this.btnReturnToMain.UseVisualStyleBackColor = true;
            this.btnReturnToMain.Visible = false;
            this.btnReturnToMain.Click += new System.EventHandler(this.Return_Click);
            // 
            // SelectAUserToViewGrp
            // 
            this.SelectAUserToViewGrp.Controls.Add(this.listBoxUsers);
            this.SelectAUserToViewGrp.Location = new System.Drawing.Point(443, 165);
            this.SelectAUserToViewGrp.Name = "SelectAUserToViewGrp";
            this.SelectAUserToViewGrp.Size = new System.Drawing.Size(371, 200);
            this.SelectAUserToViewGrp.TabIndex = 13;
            this.SelectAUserToViewGrp.TabStop = false;
            this.SelectAUserToViewGrp.Text = "Select A User To View";
            this.SelectAUserToViewGrp.Visible = false;
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1325, 653);
            this.Controls.Add(this.SelectAUserToViewGrp);
            this.Controls.Add(this.btnReturnToMain);
            this.Controls.Add(this.AddProductToBuyerGrp);
            this.Controls.Add(this.ProductInfo);
            this.Controls.Add(this.userInfoGrp);
            this.Controls.Add(this.AddProductToSellerGrp);
            this.Controls.Add(this.UserInfo);
            this.Controls.Add(this.panelButtons);
            this.Name = "Form1";
            this.Text = "Ebay";
            this.panelButtons.ResumeLayout(false);
            this.UserInfo.ResumeLayout(false);
            this.UserInfo.PerformLayout();
            this.AddProductToSellerGrp.ResumeLayout(false);
            this.AddProductToSellerGrp.PerformLayout();
            this.userInfoGrp.ResumeLayout(false);
            this.ProductInfo.ResumeLayout(false);
            this.AddProductToBuyerGrp.ResumeLayout(false);
            this.SelectAUserToViewGrp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblBuilding;
        private System.Windows.Forms.Label lblStreet;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button addUserButton;
        private System.Windows.Forms.ComboBox cmbUserType;
        private System.Windows.Forms.GroupBox AddProductToSellerGrp;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtSpecialPackagingPrice;
        private System.Windows.Forms.TextBox txtProductPrice;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblSpecialPackagingPrice;
        private System.Windows.Forms.Label lblProductPrice;
        private System.Windows.Forms.ComboBox cmbSellers;
        private System.Windows.Forms.Button BtnAddProduct;
        private System.Windows.Forms.ComboBox cmbProductCategory;
        private System.Windows.Forms.CheckBox chkSpecialPackaging;
        private System.Windows.Forms.GroupBox userInfoGrp;
        private System.Windows.Forms.Label lblShowCountry;
        private System.Windows.Forms.Label lblShowCity;
        private System.Windows.Forms.Label lblShowBuildingNumber;
        private System.Windows.Forms.Label lblShowStreetName;
        private System.Windows.Forms.Label lblShowPassword;
        private System.Windows.Forms.Label lblUserProducts;
        private System.Windows.Forms.Label lblShowAddress;
        private System.Windows.Forms.Label lblShowUsername;
        private System.Windows.Forms.ListBox listIProducts;
        private System.Windows.Forms.GroupBox ProductInfo;
        private System.Windows.Forms.Label lblShowProductCategory;
        private System.Windows.Forms.Label lblShowProductSerialNumber;
        private System.Windows.Forms.Label lblShowProductPrice;
        private System.Windows.Forms.Label lblShowProductName;
        private System.Windows.Forms.Label lblShowProductSpecialPrice;
        private System.Windows.Forms.Label lblShowProductIsSpecial;
        private System.Windows.Forms.Label lblShowProductTotalPrice;
        private System.Windows.Forms.GroupBox AddProductToBuyerGrp;
        private System.Windows.Forms.ListBox listProductsBuy;
        private System.Windows.Forms.Button btnBuyProduct;
        private System.Windows.Forms.ComboBox cmbBuyers;
        private System.Windows.Forms.Button btnReturnToMain;
        private System.Windows.Forms.Label lblSelectSeller;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblSelectBuyer;
        private System.Windows.Forms.Label lblSelectProduct;
        private System.Windows.Forms.GroupBox SelectAUserToViewGrp;
    }
}