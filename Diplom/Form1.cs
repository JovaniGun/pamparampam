using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diplom.Contexts;

namespace Diplom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var clientContext = new ClientContext();
            var clients = clientContext.Clients;
            dataGridView1.DataSource = clients.ToList();
        }
         
    }
}
