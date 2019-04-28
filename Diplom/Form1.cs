using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diplom.Models;
using Diplom.Contexts;
using Diplom.Views;
using Diplom.Helpers;

namespace Diplom
{
    public partial class Form1 : Form
    {
        private DiplomContext context;
        public Form1()
        {
            InitializeComponent();
            context = new DiplomContext();
            var clients = context.Clients;
            dataGridView1.DataSource = context.Purchases.ToList();
        }

        private void добавитьКлиентаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddClientView addClientView = new AddClientView();
            addClientView.ShowDialog();
        }
        
        private void импортироватьПокупкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            string json = System.IO.File.ReadAllText(filename);
            List<Purchase> purchases = JSONParser.getPurcases(json);
            foreach(var purchase in purchases)
            {
                this.context.Purchases.Add(purchase);
            }
            this.context.SaveChanges();
            MessageBox.Show("Импорт покупок завершен");

        }
    }
}
