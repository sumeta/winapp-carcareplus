using CarcarePlus.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarcarePlus
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new CarIn().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Payment().ShowDialog();
        }

        private void menu1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Staff().ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menu1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           var alert =  new Alert();
            alert.development();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Stock().Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new History().ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new Report().Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Package().Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new Password().Show();
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Staff().ShowDialog();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void StoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Store().ShowDialog();
        }

        private void carSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CarSize().ShowDialog();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Customer().ShowDialog();
        }
    }
}
