using System;
using System.Linq;
using System.Windows.Forms;
using Diplom.Models;
using Diplom.Contexts;
using System.Data.Entity;
namespace Diplom.Views
{
    public partial class AddClientView : Form
    {
        private DiplomContext context;
        private DbSet<Client> clients;
        private Client client;
        public AddClientView()
        {
            InitializeComponent();
            this.context = new DiplomContext();
            this.clients = context.Clients;
            var genders = context.Genders;
            genderComboBox.DataSource = genders.ToList();
            genderComboBox.ValueMember = "GenderId";
            genderComboBox.DisplayMember = "Gender_name";
            client = new Client();
        }
        private string [] parseFIO(string str)
        {
            string[] FIO = str.Split();

            return FIO;
        }
        public void submit_Click(object sender, EventArgs e)
        {
            try
            {
                string[] FIO = this.parseFIO(FIOtextBox.Text);
                DateTime birthday = birthdayPicker.Value;
                int gender = (int)genderComboBox.SelectedValue;
                string email = EmailBox.Text;
                string phone = phoneBox.Text;
                bool access = agreeCheckBox.Checked;
                client.Family = FIO[0];
                client.Name = FIO[1];
                client.Patronymic = FIO[2];
                client.Birthday = birthday;
                client.GenderId = gender;
                client.Email = email;
                client.Phone = phone;
                client.Consent = access;
                context.Clients.Add(client);
                context.SaveChanges();
                MessageBox.Show("Клиент добавлен!");
                this.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            

        }
    }
}
