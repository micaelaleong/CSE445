using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser_Assignment1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void c2fButton_Click(object sender, EventArgs e)
        {
            TempConversion.TempConversionServiceClient c2fService = new TempConversion.TempConversionServiceClient();
            int tempInCelsius = c2fService.c2f(Convert.ToInt32(givenTemp.Text));
            tempResultLabel.Text = tempInCelsius.ToString() + "°C";
        }

        private void f2cButton_Click(object sender, EventArgs e)
        {
            TempConversion.TempConversionServiceClient f2cService = new TempConversion.TempConversionServiceClient();
            int tempInFahrenheit = f2cService.f2c(Convert.ToInt32(givenTemp.Text));
            tempResultLabel.Text = tempInFahrenheit.ToString() + "°F";
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            NumberSorter.NumberSorterServiceClient numberSorter = new NumberSorter.NumberSorterServiceClient();
            string numbers = numberSorter.sort(givenNumbers.Text);
            sortedNumResult.Text = numbers;
        }
    }
}
