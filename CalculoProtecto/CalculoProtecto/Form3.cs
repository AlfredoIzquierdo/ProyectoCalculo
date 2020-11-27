using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculoProtecto
{
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        public string funcionVolumen(double ancho, double alto) {
            return "4x^3-" + ((ancho + alto) * 2) + "x^2+" + (ancho*alto)+"x"; 
        }

        public string derivadaVolumen(double ancho, double alto) {
            return "12x^2-" + ((ancho + alto) * 4) + "x+" + (ancho * alto);
        }
    }
}
