using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarcarePlus
{
    public partial class Store : Form
    {
        public Store()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void Store_Load(object sender, EventArgs e)
        {
            string registry = ConfigurationManager.AppSettings["registry"];
            RegistryKey key = Registry.CurrentUser.OpenSubKey(registry);
            if (key.GetValue("TIN") != null)
            {
                textBox1.Text = key.GetValue("TIN").ToString();
            }
            if (key.GetValue("NameTH") != null)
            {
                textBox2.Text = key.GetValue("NameTH").ToString();
            }
            if (key.GetValue("NameEN") != null)
            {
                textBox3.Text = key.GetValue("NameEN").ToString();
            }
            if (key.GetValue("Tel") != null)
            {
                textBox4.Text = key.GetValue("Tel").ToString();
            }
            if (key.GetValue("Address") != null)
            {
                richTextBox1.Text = key.GetValue("Address").ToString();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string registry = ConfigurationManager.AppSettings["registry"];
            RegistryKey key = Registry.CurrentUser.CreateSubKey(registry);
            key.SetValue("TIN", textBox1.Text.ToString());
            key.SetValue("NameTH", textBox2.Text.ToString());
            key.SetValue("NameEN", textBox3.Text.ToString());
            key.SetValue("Tel", textBox4.Text.ToString());
            key.SetValue("Address", richTextBox1.Text.ToString());
            key.Close();

            Close();
        }

    }
}
