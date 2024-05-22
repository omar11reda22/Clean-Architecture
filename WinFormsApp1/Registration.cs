using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.Data;

namespace WinFormsApp1
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            Password.PasswordChar = '*';
            Confirm.PasswordChar = '*';
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Password.PasswordChar = '*'; 
            //Confirm.PasswordChar = '*'; 

            var username = UserName.Text;
            var mail = Mail.Text;
            var password = Password.Text;
            var confirm = Confirm.Text;
            var address = Address.Text;



            if (Confirm.Text != Password.Text)
            {
                MessageBox.Show("check confirm pawword like your pwn password");
            }

            var url = new Uri("https://localhost:44378/api/SecurityIdentity");
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
            HttpClient client = new HttpClient();

            //var formdata = new FormUrlEncodedContent(new[] {

            //    new KeyValuePair<string, string>("UserName",username),
            //    new KeyValuePair<string, string>("Password",password),
            //    new KeyValuePair<string, string>("Address",address),
            //    new KeyValuePair<string, string>("E_Mail",mail),


            //});
            //var data = new
            //{
            //    UserName = username,
            //    E_mail = mail,
            //    password = password,
            //    address = address

            //};

            RegistrationDTO registrationDTO = new RegistrationDTO() { UserName = username, E_Mail = mail, password = password, Address = address, ConfirmPassword = confirm };


            var json = JsonConvert.SerializeObject(registrationDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");



            var response = await client.PostAsync(url, content);
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("saving Done");
                }
                else
                {
                    MessageBox.Show("ERROR : " + response.ReasonPhrase + "check username (no space) , password(at least character uppercase and have a sign)");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR :" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide(); 
        }
    }
}
