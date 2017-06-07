using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoLog
{
    public partial class Form1 : Form
    {

        public string username;
        public string password;
        public string host = "google.com";
        public int timeout = 2000;

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            this.Text = "FullHouse Auto Login : HANDDEV";

        }

        private void button_login_Click(object sender, EventArgs e)
        {

            username = user.Text;
            password = pass.Text;


            webBrowser1.Navigate("http://logoutwifi.net/login?username="+username+ "&password="+password);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            Ping myping = new Ping();
            
            byte[] buffer = new byte[32];

            

            PingOptions pingOption = new PingOptions();
            PingReply reply = myping.Send(host, timeout, buffer, pingOption);
            if(reply.Status == IPStatus.Success)
            {
               
                    label2.BackColor = Color.LimeGreen;
                    label2.Text = "ONLINE";
                




            }
            else
            {
                if (checkBox1.Checked)
                {
                    username = user.Text;
                    password = pass.Text;
                    webBrowser1.Navigate("http://logoutwifi.net/login?username=" + username + "&password=" + password);

                }
                label2.BackColor = Color.Red;
                label2.Text = "OFFLINE";
              
                

            }


        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
            {

                Hide();
                notifyIcon1.Visible = true;

            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
    }
}
