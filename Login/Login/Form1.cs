using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Login
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string filepath = @"C:\\Users\\ME\\Documents\\Finalsprog\containerdata.txt";
        ArrayList allusername = new ArrayList();
        Dictionary<string, string> userAndpass = new Dictionary<string, string>();

        public Dictionary<string, string> MyDictionary
        {
            get { return userAndpass; }
            set { userAndpass = value; }
        }
        public void Getuser()
        {
            string[] lines = File.ReadAllLines(filepath);
            string[] values;
            string username = "";
            string password = "";

            for (int i = 0; i < lines.Length; i++)
            {
                values = lines[i].ToString().Split(':');

                if (values[0].Trim().Equals("Username"))
                {
                    username = values[1];
                    allusername.Add(username);
                }
                else if (values[0].Trim().Equals("SignPass"))
                {
                    password = values[1];
                }
                if (username != "" && password != "")
                {
                    userAndpass.Add(username,password);
                    richTextBox1.Text += username + " - " + password;
                    richTextBox1.Text += Environment.NewLine;
                    username = "";
                    password = "";
                }
            }
        }

        private void Signupbtn_Click(object sender, EventArgs e)
        {
            Getuser();
            string Signupuser = TxtbxSuusername.Text;
            string Signuppass = TxtbxSuPass.Text;
            string SignupCompass = TxtbxSuCpass.Text;

            TextWriter write = new StreamWriter(filepath, true);
            write.Write("Username: " + Signupuser);
            write.WriteLine("");
            write.Write("Signpass: " + Signuppass);
            write.WriteLine("");
            write.Write("Confirm Pass: " + SignupCompass);
            write.WriteLine("");

            write.Close();
            MessageBox.Show("Account created");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string loguname = Txtbxloguser.Text;
            string logpassword = Txtbxlogpass.Text;
            bool userExist = false;
            if (loguname.Trim().Equals("") || logpassword.Trim().Equals(""))
            {
                MessageBox.Show("you need to enter the username or Password");
            }
            else
            {
                foreach (var use in userAndpass)
                {
                    if (use.Key.ToString().Trim().Equals(loguname))
                    {
                        if (use.Value.ToString().Trim().Equals(logpassword))
                        {

                            userExist = true;
                            break;
                        }
                    }
                }
                if (userExist)
                {
                    MessageBox.Show("yes");
                }
                else
                {
                    MessageBox.Show("no");
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel1.Show();
        }
    }
}
//reference:https://www.youtube.com/watch?v=1z9OeGAHbfI&t=12s