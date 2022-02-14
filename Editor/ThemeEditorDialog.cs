using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SText.Editor
{
    public partial class ThemeEditorDialog : Form
    {
        public ThemeEditorDialog()
        {
            InitializeComponent();
        }
        ColorDialog cd = new ColorDialog();
        public Color[] ctext=new Color[3];
        public Color[] cback=new Color[3];
        public bool status;
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = ctext[0];
            pictureBox2.BackColor = cback[0];
            pictureBox3.BackColor = ctext[1];
            pictureBox4.BackColor = cback[1];
            pictureBox5.BackColor = ctext[2];
            pictureBox6.BackColor = cback[2];
            status = false;
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cd.Color = pictureBox1.BackColor;
            cd.ShowDialog();
            pictureBox1.BackColor = cd.Color;
            label1.ForeColor = cd.Color;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cd.Color = pictureBox2.BackColor;
            cd.ShowDialog();
            pictureBox2.BackColor = cd.Color;
            label1.BackColor = cd.Color;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            cd.Color = pictureBox3.BackColor;
            cd.ShowDialog();
            pictureBox3.BackColor = cd.Color;
            label2.ForeColor = cd.Color;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            cd.Color = pictureBox4.BackColor;
            cd.ShowDialog();
            pictureBox4.BackColor = cd.Color;
            label2.BackColor = cd.Color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            status = true;
            Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            cd.Color = pictureBox5.BackColor;
            cd.ShowDialog();
            pictureBox5.BackColor = cd.Color;
            label6.ForeColor = cd.Color;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            cd.Color = pictureBox6.BackColor;
            cd.ShowDialog();
            pictureBox6.BackColor = cd.Color;
            label6.BackColor = cd.Color;
        }

        private void ustheme_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = ctext[0];
            pictureBox2.BackColor = cback[0];
            pictureBox3.BackColor = ctext[1];
            pictureBox4.BackColor = cback[1];
            pictureBox5.BackColor = ctext[2];
            pictureBox6.BackColor = cback[2];
            label1.BackColor = cback[0];
            label1.ForeColor = ctext[0];
            label2.BackColor = cback[1];
            label2.ForeColor = ctext[1];
            label6.BackColor = cback[2];
            label6.ForeColor = ctext[2];
        }
    }
}
