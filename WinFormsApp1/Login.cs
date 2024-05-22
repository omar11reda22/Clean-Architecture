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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Password.PasswordChar = '*'; 
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var username = UserName.Text; 
            var password = Password.Text; 

            HttpClient client = new HttpClient();

            var url = new Uri("https://localhost:44378/api/SecurityIdentity/login");

            LoginDTO loginDTO = new LoginDTO() { 
            
            UserName = username, 
            Password = password, 
            
            };


            var json = JsonConvert.SerializeObject(loginDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            try
            {
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Login Done");
                }
                else
                {
                    MessageBox.Show("ERROR : " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR :" + ex.Message);
            }

        }
    }
}
