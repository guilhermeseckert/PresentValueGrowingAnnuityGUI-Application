using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        decimal p;
        decimal r;
        decimal g;
        int n;
        decimal result;


        public Form1()
        {
            InitializeComponent();
            textBoxP.Validating += new CancelEventHandler(Number_Validating);
            textBoxR.Validating += new CancelEventHandler(Number_Validating);
            textBoxG.Validating += new CancelEventHandler(Number_Validating);
            textBoxN.Validating += new CancelEventHandler(Number_Validating);

            textBoxP.Text= "0";
            textBoxR.Text = "0";
            textBoxG.Text = "0";
            textBoxN.Text = "0";
        }

 
        private void button1_Click(object sender, EventArgs e)
        {

            p = Convert.ToDecimal(textBoxP.Text);
            r = Convert.ToDecimal(textBoxR.Text) / 100;
            g = Convert.ToDecimal(textBoxG.Text) / 100;
            n = Convert.ToInt32(textBoxN.Text);

            try
            {
            
                result = (p / (r - g)) * ((decimal)(1 - Math.Pow((double)((1 + g) / (1 + r)), n)));
                textBoxResult.Text = result.ToString("$0,000.00");

         
            }
            catch (DivideByZeroException)
            {
             MessageBox.Show("Error while calculation \nPresent Value please check your input");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            textBoxP.Clear();
            textBoxR.Clear();
            textBoxG.Clear();
            textBoxN.Clear();
            textBoxResult.Clear();
        }

       

        private void Number_Validating(object sender, CancelEventArgs e)
        {
            decimal val;
            TextBox tb = sender as TextBox;
            if (tb.Text == string.Empty)
            {
           
                return;
            }

            if (!decimal.TryParse(tb.Text, out val))
            {
                MessageBox.Show(tb.Tag + " Must be numeric.");
                tb.Undo();
                e.Cancel = true;
            }
        }

      
    }
}
