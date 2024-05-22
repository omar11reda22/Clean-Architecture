namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login lg = new Login(); 
            this.Hide();
            lg.Show(); 
        }
    }
}
