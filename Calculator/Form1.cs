using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculate;

namespace Calculator
{
    public partial class MyCalculator : Form
    {
        public MyCalculator()
        {
            InitializeComponent();
            ActionBox.MaxLength = 12;
        }
        Calculate.Calculator calculator = new Calculate.Calculator();
        private void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            ActionBox.Text += button.Text;
            ActionBox.Focus();
            ActionBox.SelectionStart = ActionBox.Text.Length;
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            ActionBox.Text = null;
        }

        private void Equal_Click(object sender, EventArgs e)
        {
           
            if (calculator.Calculate(ActionBox.Text))
            {
                ActionBox.Text = calculator.Result.ToString();
            }
            else 
            {
                Error.Text = "Wrong format";
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string temp = ActionBox.Text;
            ActionBox.Text = "";
            for (int i = 0; i < temp.Length-1; i++)
            {
                ActionBox.Text += temp[i];
            }
        }
        private void ActionBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.KeyChar = '\0';
                Equal_Click(sender, e);
                ActionBox.SelectionStart = ActionBox.Text.Length;
                e.Handled = true;

            }
            else if ((e.KeyChar < (int)'*' || e.KeyChar > (int)'9') && e.KeyChar != '\b')
            {
                e.KeyChar = '\0';
            }

        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ActionBox_TextChanged(object sender, EventArgs e)
        {
            if (Error.Text.Length > 0)
            {
                Error.Text = null;
            }
        }
    }
}
