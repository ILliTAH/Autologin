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
using System.IO;


namespace AutoLog
{
    public partial class Form1 : Form
    {
        public bool remember;


        public string username;
        public string password;
        public string host = "google.com";
        public int timeout = 2000;


        public string usfilrfo = "usinfo.txt";
        public string psfilrfo = "psinfo.txt";

        public Form1()
        {
            string fsfilePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Hcopl");

            string usfilePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Hcopl", "usinfo.txt");
            string psfilePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Hcopl", "psinfo.txt");

            InitializeComponent();
            timer1.Enabled = true;
            this.Text = "FullHouse Auto Login ";

            label5.Visible = false;

            if (!System.IO.Directory.Exists(fsfilePath))
            {
                System.IO.Directory.CreateDirectory(fsfilePath);
            }

           
            if (File.Exists(usfilePath))
            {
                

                StreamReader sr = new StreamReader(usfilePath);
                user.Text = sr.ReadToEnd();
                sr.Dispose();

            }
            else
            {

            }


            if (File.Exists(psfilePath))
            {
                StreamReader sr2 = new StreamReader(psfilePath);
                pass.Text = sr2.ReadToEnd();
                sr2.Dispose();

            }
            else
            {

            }



        }

        private void button_login_Click(object sender, EventArgs e)
        {

            username = user.Text;
            password = pass.Text;


            webBrowser1.Navigate("http://logoutwifi.net/login?username=" + username + "&password=" + password);

            label6.Visible = false;
             label5.Visible = true;
            label5.Text = "Welcome " + user.Text;
            string usfilePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Hcopl",usfilrfo);
            string psfilePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Hcopl",psfilrfo);

           

            if (checkBox2.Checked)
            {
                

                using (StreamWriter sw = new StreamWriter(usfilePath,true))
                {
                    sw.Write(user.Text);
                }
                using (StreamWriter sw2 = new StreamWriter(psfilePath,true))
                {
                    sw2.Write(pass.Text);

                }

            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            notifyIcon1.Text = " Internet || " + label2.Text;
            Ping myping = new Ping();

            byte[] buffer = new byte[32];



            PingOptions pingOption = new PingOptions();
            PingReply reply = myping.Send(host, timeout, buffer, pingOption);
            if (reply.Status == IPStatus.Success)
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
                label2.ForeColor = Color.Red;
                label2.Text = "OFFLINE";



            }


        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.FormBorderStyle = FormBorderStyle.None;
        }


        private bool mousedown;
        private Point lastlocation;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {


            mousedown = true;
            lastlocation = e.Location;




        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                this.Location = new Point(
                    (this.Location.X - lastlocation.X) + e.X, (this.Location.Y - lastlocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {

            mousedown = false;
        }

        private void user_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void pass_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                button_login.PerformClick();



            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
          
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            remember = true;
        }
    }
}