using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double num1 = double.Parse(textBox1.Text);
            double num2 = double.Parse(textBox2.Text);
            switch (comboBox1.Text)
            {
                case "+":
                    label5.Text = (num1 + num2).ToString();
                    break;
                case "-":
                    label5.Text = (num1 - num2).ToString();
                    break;
                case "*":
                    label5.Text = (num1 * num2).ToString();
                    break;
                case "/":
                    label5.Text = (num1 / num2).ToString();
                    break;
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
