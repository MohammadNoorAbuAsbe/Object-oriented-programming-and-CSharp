using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HomeWork5
{
    public partial class Form1 : Form
    {
        private ShopSystem shopSystem;
        private List<User> users;

        public Form1()
        {
            InitializeComponent();
            shopSystem = new ShopSystem("Ebay");
            LoadFromFile("sellers_products.txt");
        }

        private void BtnAddUser_Click(object sender, EventArgs e)
        {
            this.UserInfo.Visible = true;
            this.cmbUserType.SelectedItem = "Seller";
            this.panelButtons.Visible = false;
            btnReturnToMain.Visible = true;
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtStreetName.Text = "";
            txtBuildingNumber.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
        }

        private void BtnAddProductToSeller_Click(object sender, EventArgs e)
        {
            if (shopSystem.GetAllSellers().Count == 0)
            {
                DisplayErrorMessage("There is no available Sellers in the system, Please try again later", "Error");
                return;
            }
            InitializeSellerComboBox();
            this.panelButtons.Visible = false;
            btnReturnToMain.Visible = true;
            this.AddProductToSellerGrp.Visible = true;
        }

        private void BtnAddProductToBuyerCart_Click(object sender, EventArgs e)
        {

            if (shopSystem.GetAllBuyers().Count == 0)
            {
                DisplayErrorMessage("There is no available Buyers in the system, Please try again later", "Error");
                return;
            }
            if (shopSystem.GetAllProducts().Count == 0)
            {
                DisplayErrorMessage("There are no available products in the system. Please try again later.", "Error");
                return;
            }
            InitializeBuyerComboBox();
            this.panelButtons.Visible = false;
            btnReturnToMain.Visible = true;
            this.AddProductToBuyerGrp.Visible = true;
        }

        private void Return_Click(object sender, EventArgs e)
        {
            this.panelButtons.Visible = true;
            btnReturnToMain.Visible = false;
            this.UserInfo.Visible = false;
            this.AddProductToSellerGrp.Visible = false;
            this.AddProductToBuyerGrp.Visible = false;
            this.userInfoGrp.Visible = false;
            this.ProductInfo.Visible = false;
            this.SelectAUserToViewGrp.Visible = false;
        }



        private void BtnShowBuyers_Click(object sender, EventArgs e)
        {
            ShowUsers(UserType.Buyer);
        }

        private void BtnShowSellers_Click(object sender, EventArgs e)
        {
            ShowUsers(UserType.Seller);
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            SaveToFile("sellers_products.txt", shopSystem.GetAllSellers());
            this.Close();
        }

        private void SaveToFile(string filePath, List<User> sellers)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Seller seller in sellers)
                    {
                        writer.WriteLine("Seller Details:");
                        writer.WriteLine(seller.Username);
                        writer.WriteLine(seller.Password);
                        writer.WriteLine(seller.Address.StreetName);
                        writer.WriteLine(seller.Address.BuildingNumber);
                        writer.WriteLine(seller.Address.City);
                        writer.WriteLine(seller.Address.Country);
                        writer.WriteLine("Products:");
                        foreach (Product product in seller.Products)
                        {
                            writer.WriteLine("Product Details:");
                            writer.WriteLine(product.SerialNumber);
                            writer.WriteLine(product.Name);
                            writer.WriteLine(product.Category);
                            writer.WriteLine(product.Price);

                            if (product is SpecialPackagingProduct)
                            {
                                writer.WriteLine(((SpecialPackagingProduct)product).SpecialPackagingPrice);
                            }
                            else
                            {
                                writer.WriteLine("0");
                            }
                        }
                    }
                }
                MessageBox.Show($"Sellers saved successfully to file: {filePath}\nLocation: {Path.GetFullPath(filePath)}", "Save Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DisplayErrorMessage($"Error saving data: {ex.Message}", "Save Error");
            }
        }

        private void LoadFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    List<Seller> loadedSellers = new List<Seller>();
                    Seller currentSeller = null;
                    int highestSerialNumber = 0;
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.StartsWith("Seller Details:"))
                            {
                                string username = reader.ReadLine();
                                string password = reader.ReadLine();
                                string streetName = reader.ReadLine();
                                int buildingNumber = int.Parse(reader.ReadLine());
                                string city = reader.ReadLine();
                                string country = reader.ReadLine();

                                currentSeller = new Seller(username, password, new Address(streetName, buildingNumber, city, country));
                                loadedSellers.Add(currentSeller);
                            }
                            else if (line.StartsWith("Product Details:") && currentSeller != null)
                            {
                                int productSerialNumber = int.Parse(reader.ReadLine());
                                if (productSerialNumber > highestSerialNumber)
                                {
                                    highestSerialNumber = productSerialNumber;
                                }
                                string productName = reader.ReadLine();
                                string category = reader.ReadLine();
                                double productPrice = double.Parse(reader.ReadLine());

                                double specialPackagingPrice = double.Parse(reader.ReadLine());

                                if (specialPackagingPrice > 0)
                                {
                                    currentSeller.AddProduct(new SpecialPackagingProduct(productName, productPrice, (ProductCategory)Enum.Parse(typeof(ProductCategory), category), specialPackagingPrice, productSerialNumber, currentSeller));
                                }
                                else
                                {
                                    currentSeller.AddProduct(new Product(productName, productPrice, (ProductCategory)Enum.Parse(typeof(ProductCategory), category), productSerialNumber, currentSeller));
                                }
                            }
                        }
                    }

                    foreach (Seller seller in loadedSellers)
                    {
                        shopSystem += seller;
                    }

                    shopSystem.UpdateProductsSerialNumber(highestSerialNumber + 1);
                    MessageBox.Show($"Sellers loaded successfully from file: {Path.GetFileName(filePath)}\nLocation: {Path.GetFullPath(filePath)}", "Load Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DisplayErrorMessage("Sellers File not found.", "Load Error");
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage($"Error loading Sellers: {ex.Message}", "Load Error");
            }
        }

        private bool ValidateUserInput(string input, string fieldName)
        {
            if (input == null || input == "")
            {
                DisplayErrorMessage($"{fieldName} cannot be empty.", "Error");
                return false;
            }
            return true;
        }
        private void AddUser(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateUserInput(txtUsername.Text, "Username") ||
                    !ValidateUserInput(txtPassword.Text, "Password") ||
                    !ValidateUserInput(txtStreetName.Text, "Street Name") ||
                    !ValidateUserInput(txtCity.Text, "City") ||
                    !ValidateUserInput(txtCountry.Text, "Country"))
                {
                    return;
                }

                int buildingNumber;
                try
                {
                    buildingNumber = int.Parse(txtBuildingNumber.Text);
                }
                catch (FormatException)
                {
                    DisplayErrorMessage("Building Number must be a valid integer.", "Error");
                    return;
                }

                UserType userType;
                try
                {
                    userType = (UserType)Enum.Parse(typeof(UserType), cmbUserType.SelectedItem.ToString());
                }
                catch (ArgumentException)
                {
                    DisplayErrorMessage("Invalid User Type selected.", "Error");
                    return;
                }

                shopSystem.AddUser(txtUsername.Text, txtPassword.Text, txtStreetName.Text, buildingNumber, txtCity.Text, txtCountry.Text, userType);
                MessageBox.Show($"Added {userType}: {txtUsername.Text}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.UserInfo.Visible = false;
                this.panelButtons.Visible = true;
                btnReturnToMain.Visible = false;
            }
            catch (ArgumentNullException ex)
            {
                DisplayErrorMessage($"Error adding user: {ex.Message}", "Error");
            }
            catch (Exception)
            {
                DisplayErrorMessage("User already exists. Please choose a different username.", "Error");
            }
        }

        private void InitializeSellerComboBox()
        {
            cmbSellers.DataSource = shopSystem.GetAllSellers();
            cmbSellers.DisplayMember = "Username";
            cmbProductCategory.DataSource = Enum.GetValues(typeof(ProductCategory));
            txtSpecialPackagingPrice.Text = "";
            txtProductPrice.Text = "";
            txtProductName.Text = "";
        }

        private void AddProductToSeller(object sender, EventArgs e)
        {
            try
            {
                if (cmbSellers.SelectedItem == null)
                {
                    DisplayErrorMessage("Please select a seller.", "Error");
                    return;
                }

                User selectedUser = (User)cmbSellers.SelectedItem;

                string name = txtProductName.Text;
                if (!ValidateUserInput(name, "Product Name"))
                {
                    return;
                }
                double price;
                try
                {
                    price = double.Parse(txtProductPrice.Text);
                    if (price <= 0)
                    {
                        DisplayErrorMessage("Invalid product price. Please enter a valid number greater than 0.", "Error");
                        return;
                    }
                }
                catch (FormatException)
                {
                    DisplayErrorMessage("Invalid product price format. Please enter a valid number.", "Error");
                    return;
                }

                double specialPackagingPrice;

                if (!chkSpecialPackaging.Checked)
                {
                    specialPackagingPrice = 0;
                }
                else
                {
                    try
                    {
                        specialPackagingPrice = double.Parse(txtSpecialPackagingPrice.Text);

                        if (specialPackagingPrice <= 0)
                        {
                            DisplayErrorMessage("Invalid special packaging price. Please enter a valid number greater than 0.", "Error");
                            return;
                        }
                    }
                    catch (FormatException)
                    {
                        DisplayErrorMessage("Invalid special packaging price format. Please enter a valid number.", "Error");
                        return;
                    }
                }


                if (cmbProductCategory.SelectedItem == null || !Enum.IsDefined(typeof(ProductCategory), cmbProductCategory.SelectedItem))
                {
                    DisplayErrorMessage("Please select a valid product category.", "Error");
                    return;
                }

                ProductCategory category = (ProductCategory)cmbProductCategory.SelectedItem;

                shopSystem.AddProductToSeller((Seller)selectedUser, name, price, specialPackagingPrice, category);
                this.panelButtons.Visible = true;
                btnReturnToMain.Visible = false;
                this.AddProductToSellerGrp.Visible = false;

            }
            catch (Exception ex)
            {
                DisplayErrorMessage($"Error adding product to seller: {ex.Message}", "Error");
            }
        }

        private void ChkSpecialPackaging_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpecialPackaging.Checked)
            {
                txtSpecialPackagingPrice.Visible = true;
                lblSpecialPackagingPrice.Visible = true;
            }
            else
            {
                txtSpecialPackagingPrice.Visible = false;
                lblSpecialPackagingPrice.Visible = false;
            }
        }

        private void InitializeBuyerComboBox()
        {

            cmbBuyers.DataSource = shopSystem.GetAllBuyers();
            cmbBuyers.DisplayMember = "Username";
            FillProductList();
        }

        private void FillProductList()
        {
            List<Product> products = shopSystem.GetAllProducts();

            listProductsBuy.Items.Clear();


            foreach (Product product in products)
            {
                listProductsBuy.Items.Add(product.Name);
            }

        }

        private void BtnAddToCart_Click(object sender, EventArgs e)
        {
            if (listProductsBuy.SelectedItem == null)
            {
                DisplayErrorMessage("Please select a product to add to the cart.", "Error");
                return;
            }

            if (cmbBuyers.SelectedItem == null)
            {
                DisplayErrorMessage("Please select a buyer to add the product to.", "Error");
                return;
            }

            Buyer selectedBuyer = (Buyer)cmbBuyers.SelectedItem;


            Product selectedProduct = shopSystem.GetAllProducts()[listProductsBuy.SelectedIndex];

            if (selectedProduct != null)
            {

                shopSystem.AddProductToBuyerCart(selectedBuyer, selectedProduct);


                MessageBox.Show($"Added {selectedProduct.Name} to {selectedBuyer.Username}'s cart.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DisplayErrorMessage("Selected product not found.", "Error");
            }
        }


        private void ShowUsers(UserType userType)
        {
            users = userType == UserType.Buyer ? shopSystem.GetAllBuyers() : shopSystem.GetAllSellers();
            if (users.Count == 0)
            {
                string userTypeMessage = userType == UserType.Buyer ? "Buyers" : "Sellers";
                DisplayErrorMessage($"There are no available {userTypeMessage} in the system. Please try again later", "Error");
                return;
            }

            this.panelButtons.Visible = false;
            btnReturnToMain.Visible = true;
            SelectAUserToViewGrp.Visible = true;
            listBoxUsers.Items.Clear();

            foreach (User user in users)
            {
                listBoxUsers.Items.Add(user.Username);
            }

            if (userType == UserType.Buyer)
            {
                SelectAUserToViewGrp.Text = "Select a Buyer to View";
            }
            else if (userType == UserType.Seller)
            {
                SelectAUserToViewGrp.Text = "Select a Seller to View";
            }
        }

        private void ListBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxUsers.SelectedIndex != -1)
            {

                User selectedUser = users[listBoxUsers.SelectedIndex];

                ShowUserDetails(selectedUser);
            }
        }

        private void ShowUserDetails(User user)
        {
            if (user is Seller)
            {
                userInfoGrp.Text = "Seller Info";
            }
            else if (user is Buyer)
            {
                userInfoGrp.Text = "Buyer Info";
            }
            userInfoGrp.Visible = true;
            lblShowUsername.Text = "Username: ";
            lblShowPassword.Text = "Password: ";
            lblShowStreetName.Text = "Street Name: ";
            lblShowBuildingNumber.Text = "Building Number: ";
            lblShowCity.Text = "City: ";
            lblShowCountry.Text = "Country: ";

            listIProducts.Items.Clear();

            lblShowUsername.Text += user.Username;
            lblShowPassword.Text += user.Password;
            lblShowStreetName.Text += user.Address.StreetName;
            lblShowBuildingNumber.Text += user.Address.BuildingNumber;
            lblShowCity.Text += user.Address.City;
            lblShowCountry.Text += user.Address.Country;

            if (((UserBase)user).Products.Count == 0)
            {
                listIProducts.Visible = false;
                lblUserProducts.Text = "Products: N/A";
            }
            else
            {
                listIProducts.Visible = true;
                lblUserProducts.Text = "Select A Product to View:";
                foreach (var product in ((UserBase)user).Products)
                {
                    listIProducts.Items.Add(product.Name);
                }
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listProductsBuy.SelectedIndex != -1)
            {
                Product product = shopSystem.GetAllProducts()[listProductsBuy.SelectedIndex];
                ShowItemDetails(product);
            }
        }

        private void ListItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listIProducts.SelectedIndex != -1)
            {
                Product product = ((UserBase)users[listBoxUsers.SelectedIndex]).Products[listIProducts.SelectedIndex];
                ShowItemDetails(product);
            }
        }
        private void ShowItemDetails(Product product)
        {
            this.ProductInfo.Visible = true;
            lblShowProductName.Text = "Name: ";
            lblShowProductPrice.Text = "Price: ";
            lblShowProductSerialNumber.Text = "Serial Number: ";
            lblShowProductCategory.Text = "Category: ";
            lblShowProductIsSpecial.Text = "Has a Special Packaging Price: ";
            lblShowProductSpecialPrice.Text = "Special Packaging Price: ";

            double totalPrice = product.Price;

            lblShowProductName.Text += product.Name;
            lblShowProductPrice.Text += product.Price;
            lblShowProductSerialNumber.Text += product.SerialNumber;
            lblShowProductCategory.Text += product.Category.ToString();

            if (product is SpecialPackagingProduct)
            {
                lblShowProductIsSpecial.Text += "Yes";
                double specialPackagingPrice = ((SpecialPackagingProduct)product).SpecialPackagingPrice;
                lblShowProductSpecialPrice.Text += specialPackagingPrice;

                totalPrice += specialPackagingPrice;
            }
            else
            {
                lblShowProductIsSpecial.Text += "No";
                lblShowProductSpecialPrice.Text += "N/A";
            }

            lblShowProductTotalPrice.Text = "Total Price: " + totalPrice;
        }
        private void DisplayErrorMessage(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
