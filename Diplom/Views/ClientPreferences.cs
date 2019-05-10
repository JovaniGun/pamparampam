using Diplom.Contexts;
using Diplom.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom.Views
{

    public partial class ClientPreferences : Form
    {
        private DiplomContext   context;
        private List<Client>   clients;
        private List<Product> products;
        private List<ProductCategory> categories;
        private List<Manufacturer> manufacturers;
        private Dictionary<int, List<Dictionary<string, object>>> clientPreferences = new Dictionary<int, List<Dictionary<string, object>>>();
        private double          threshold = 3;
        private string saveBy = "products";
        public ClientPreferences()
        {
            InitializeComponent();
            this.context        = new DiplomContext();
            this.clients        = this.context.Clients.ToList();
            this.products       = this.context.Products.ToList();
            this.categories     = this.context.ProductCategories.ToList();
            this.manufacturers  = this.context.Manufacturers.ToList();

            this.getClientPreferences();
        }
        private DateTime getLastBuyByProduct(int clientId, int productId)
        {
            var purchases = this.context.Purchases.Where(purchase => purchase.ClientId == clientId && purchase.ProductId == productId).ToList();
            var lastBuy = (from purchase in purchases orderby purchase.Date_purchase descending select purchase).ToList().First();

            return lastBuy.Date_purchase;

        }
        private DateTime getLastBuyByCategory(List<Purchase> purchases, int categoryId)
        {
            List<DateTime> dates = new List<DateTime>();
            foreach(var item in purchases)
            {

                var product = this.products.Where(p => p.ProductId == item.ProductId).First();
                if (product.getCategory().CategoryId == categoryId)
                    dates.Add(item.Date_purchase);
            }
            var lastBuy = (from date in dates orderby date descending select date).ToList().First();

            return lastBuy;

        }
        private DateTime getLastBuyByManufacturer(List<Purchase> purchases, int manufacturerId)
        {
            List<DateTime> dates = new List<DateTime>();
            foreach (var item in purchases)
            {

                var product = this.products.Where(p => p.ProductId == item.ProductId).First();
                if (product.getManufacturer().ManufacturerId == manufacturerId)
                    dates.Add(item.Date_purchase);
            }
            var lastBuy = (from date in dates orderby date descending select date).ToList().First();

            return lastBuy;

        }
        private void viewPreferences(string by = "products")
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            string dgvName = "";
            string dgvHeaderText = "";
            string dgvCellName = "";
            switch (by)
            {
                case "products":
                    dgvName = "dgvProduct";
                    dgvHeaderText = "Продукт";
                    dgvCellName = "productName";
                    break;
                case "categories":
                    dgvName = "dgvCategory";
                    dgvHeaderText = "Категория";
                    dgvCellName = "categoryName";
                    break;
                case "manufacturers":
                    dgvName = "dgvManufacturer";
                    dgvHeaderText = "Производитель";
                    dgvCellName = "manufacturerName";
                    break;
            }
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = dgvName, HeaderText =dgvHeaderText , Width = 100 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "dgvClient", HeaderText = "Клиент", Width = 180 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "dgvCount", HeaderText = "Количество продукции", Width = 80 });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn() { Name = "dgvLastBuy", HeaderText = "Дата последней покупки", Width = 120 });
            if (clientPreferences.Count > 0)
            {
                var clientIds = clientPreferences.Keys;
                foreach (int id in clientIds)
                {
                    foreach (var product in clientPreferences[id])
                    {
                        int i = dataGridView1.Rows.Add();           
                        dataGridView1.Rows[i].Cells[0].Value = product[dgvCellName].ToString();  
                        dataGridView1.Rows[i].Cells[1].Value = product["clientName"].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = product["count"].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = (DateTime)product["dateLastBuy"];

                    }

                }
                this.context.SaveChanges();
            }
        }
        
        private string getClientName(Client client)
        {
            string client_name = client.Family + " " + client.Name + " " + client.Patronymic;
            return client_name;
        }
        private List<Dictionary<string, object>> getClientPreferencesByProduct(Client client)
        {
                var productsIds = client.getPurchases().GroupBy(p => p.ProductId).ToList();
                this.saveBy = "products";
                List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                foreach (var items in productsIds)
                {
                    Dictionary<string, object> product = new Dictionary<string, object>();
                    product.Add("productId", items.Key);
                    Product productModel = this.context.Products.ToList().Where(p => p.ProductId == items.Key).First();
                    product.Add("productName", productModel.ProductName);
                    product.Add("dateLastBuy", this.getLastBuyByProduct(client.ClientId, productModel.ProductId));
                    product.Add("clientName", this.getClientName(client));
                    double count = 0;
                    foreach (var item in items)
                        count += item.Count_product;
                    product.Add("count", count);

                    list.Add(product);
                }
            return list;
        }
        private List<Dictionary<string, object>> getClientPreferencesByCategory(Client client)
        {
            this.saveBy = "categories";
            var productsIds = client.getPurchases().GroupBy(p => p.ProductId).ToList();
            HashSet<int> categoryIds = new HashSet<int>();
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (var items in productsIds)
            {
               categoryIds.Add(this.products.Where(p => p.ProductId == items.First().ProductId).ToList().First().CategoryId);
            }
            foreach(var categoryId in categoryIds)
            {
                Dictionary<string, object> category = new Dictionary<string, object>();
                double count = 0;
                string categoryName = this.categories.Where(p => p.CategoryId == categoryId).ToList().First().CategoryName;
                foreach (var items in productsIds)
                {
                    int id = this.products.Where(p => p.ProductId == items.First().ProductId).ToList().First().CategoryId;
                    if(id == categoryId)
                    {
                        foreach (var item in items)
                            count += item.Count_product;
                    }
                }
                category.Add("categoryId", categoryId);
                category.Add("categoryName", categoryName);
                category.Add("dateLastBuy", this.getLastBuyByCategory(client.getPurchases(), categoryId));
                category.Add("clientName", this.getClientName(client));
                category.Add("count", count);

                list.Add(category);
            }
               
            return list;
        }
        private List<Dictionary<string, object>> getClientPreferencesByManufacturer(Client client)
        {
            this.saveBy = "manufacturers";
            var productsIds = client.getPurchases().GroupBy(p => p.ProductId).ToList();
            HashSet<int> manufacturersIds = new HashSet<int>();
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            foreach (var items in productsIds)
            {
                manufacturersIds.Add(this.products.Where(p => p.ProductId == items.First().ProductId).ToList().First().ManufacturerId);
            }
            foreach (var manufacturerId in manufacturersIds)
            {
                Dictionary<string, object> category = new Dictionary<string, object>();
                double count = 0;
                string manufacturerName = this.manufacturers.Where(m => m.ManufacturerId == manufacturerId).ToList().First().ManufacturerName;
                foreach (var items in productsIds)
                {
                    int id = this.products.Where(p => p.ProductId == items.First().ProductId).ToList().First().ManufacturerId;
                    if (id == manufacturerId)
                    {
                        foreach (var item in items)
                            count += item.Count_product;
                    }
                }
                category.Add("manufacturerId", manufacturerId);
                category.Add("manufacturerName", manufacturerName);
                category.Add("dateLastBuy", this.getLastBuyByManufacturer(client.getPurchases(), manufacturerId));
                category.Add("clientName", this.getClientName(client));
                category.Add("count", count);

                list.Add(category);
            }
            return list;
        }
        private void getClientPreferences(string preferencesBy = "products")
        {
            clientPreferences.Clear();
            List<Dictionary<string, object>> list = null;
            foreach (Client client in this.clients)
            {
                switch(preferencesBy)
                {
                    case "products":
                        list = this.getClientPreferencesByProduct(client);
                        this.viewPreferences();
                        break;
                    case "categories":
                        list = this.getClientPreferencesByCategory(client);
                        this.viewPreferences(preferencesBy);
                        break;
                    case "manufacturers":
                        list = this.getClientPreferencesByManufacturer(client);
                        this.viewPreferences(preferencesBy);
                        break;
                }
                if(list.Count >0)
                {
                    var sortedPurchases = from p in list orderby p["count"] descending select p;
                    var a = sortedPurchases.Where(p => (double)p["count"] > this.threshold).ToList();
                    if (a.Count > 0)
                        clientPreferences.Add(client.ClientId, a);
                }   

            }
            
        }
        private void saveByProduct(List<Dictionary<string, object>> productList, int clientId)
        {
            foreach (var product in productList)
            {
                ClientPreferenceByProduct preferenceByProduct = new ClientPreferenceByProduct();
                preferenceByProduct.ClientId = clientId;
                preferenceByProduct.ProductId = (int)product["productId"];
                preferenceByProduct.DateLastBuy = (DateTime)product["dateLastBuy"];
                this.context.ClientPreferencesByProduct.Add(preferenceByProduct);
            }
        }
        private void saveByCategory(List<Dictionary<string, object>> productList, int clientId)
        {
            foreach (var product in productList)
            {
                ClientPreferenceByCategory preferenceByCategory = new ClientPreferenceByCategory();
                preferenceByCategory.ClientId = clientId;
                preferenceByCategory.CategoryId = (int)product["categoryId"];
                preferenceByCategory.DateLastBuy = (DateTime)product["dateLastBuy"];
                this.context.ClientPreferencesByCategory.Add(preferenceByCategory);
            }
        }
        private void saveByManufacturer(List<Dictionary<string, object>> productList, int clientId)
        {
            foreach (var product in productList)
            {
                ClientPreferenceByManufacturer preferenceByManufacturer = new ClientPreferenceByManufacturer();
                preferenceByManufacturer.ClientId = clientId;
                preferenceByManufacturer.ManufacturerId = (int)product["manufacturerId"];
                preferenceByManufacturer.DateLastBuy = (DateTime)product["dateLastBuy"];
                this.context.ClientPreferencesByManufacturer.Add(preferenceByManufacturer);
            }
        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(clientPreferences.Count>0)
            {
                var clientIds = clientPreferences.Keys;
                foreach (int id in clientIds)
                {
                    switch (this.saveBy)
                    {
                        case "products":
                            this.saveByProduct(clientPreferences[id], id);
                            break;
                        case "categories":
                            this.saveByCategory(clientPreferences[id], id);
                            break;
                        case "manufacturers":
                            this.saveByManufacturer(clientPreferences[id], id);
                            break;
                    }

                }
                this.context.SaveChanges();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.getClientPreferences();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.getClientPreferences("categories");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.getClientPreferences("manufacturers");
        }
    }
    
}
