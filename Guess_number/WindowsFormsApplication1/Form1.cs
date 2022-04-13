using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Random r;
        int computer_number;
        int count = 0;

        public Form1()
        {
            InitializeComponent();
            r = new Random();
            computer_number = r.Next(0, 100);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int user_number = Convert.ToInt32(textBox1.Text);

            if(user_number == computer_number)
            {
                label1.Text = "آفرین، درسته";
                count++;
            }
            else if (user_number > computer_number)
            {
                label1.Text = "برو پایین";
                count++;
            }
            else if (user_number < computer_number)
            {
                label1.Text = "برو بالا";
                count++;
            }

            label2.Text = Convert.ToString(count);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label2.Text = "0";
            label1.Text = "حدس بزن زووود باش";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
