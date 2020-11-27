using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculoProtecto
{
    public partial class Form2 : Form
    {
        
        double contenidoA, contenidoB, contenidoC;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string funcionVolumen(double ancho, double alto) {
            return "4x^3-" + ((ancho + alto) * 2) + "x^2+" + (ancho * alto) + "x";
        }

        public string derivadaVolumen(double ancho, double alto) {
            return "12x^2-" + ((ancho + alto) * 4) + "x+" + (ancho * alto);
        }

        private double[] FormulaGeneral(double a, double b, double c)
        {
            double x1 = 0;
            double x2 = 0;
            double delta = Math.Pow(b, 2) - 4 * a * c;

            x1 = (-b - Math.Sqrt(delta)) / (2 * a);
            x2 = (-b + Math.Sqrt(delta)) / (2 * a);
            
            
            return new double[2] {x1,x2};
        }

        private double[] EncontrarABC(string ecuacion)
        {
            double[] ABC= new double[3];
            string patronA = @"([\ \-\+]+|^)\d*x\^2"; // patron para evaluar si hay un termino numerico junto a el termino cuadratico
            Regex elementoA = new Regex(patronA);           
            string guardarA = elementoA.Match(ecuacion).Value;
            ABC[0] = SacarSignos(guardarA);
            guardarA = sacarNumeros.Match(guardarA).Value;
            ABC[0] *= Double.Parse(guardarA != "" ? guardarA : "1");


            string patronC = @"([\-\+]+|^)\d+([^a-zA-Z0-9]|$)"; // Patron para evaluar el contenido de B y C
            Regex elementoC = new Regex(patronC);
            string guardarC = elementoC.Match(ecuacion).Value;
            ABC[2] = SacarSignos(elementoC.Match(ecuacion).Value);
            guardarC = sacarNumeros.Match(guardarC).Value;
            ABC[2] *= Double.Parse(sacarNumeros.Match(guardarC).Value);


            string patronB = @"([\ \-\+]+|^)+\d*x([^\^]|$)"; // Patron para evaluar el contenido de B y de C
            Regex elementoB = new Regex(patronB);               
            string guardarB = elementoB.Match(ecuacion).Value;
            ABC[1] = SacarSignos(ecuacion);
            guardarB = sacarNumeros.Match(guardarB).Value;
            ABC[1] *= Double.Parse(guardarB != "" ? guardarB : "1");
            return ABC;
        }
        Regex sacarNumeros = new Regex(@"[0-9]+");
        Regex _sacarSignos = new Regex(@"[\+\-\ ]+[\da-z]");

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {

            label5.Text = "La ecuacion del volumen es:" + funcionVolumen((double)numericUpDown1.Value, (double)numericUpDown2.Value);
            label6.Text = "La derivada de la ecuacion es" + derivadaVolumen((double)numericUpDown1.Value, (double)numericUpDown2.Value);
            double[] X = EncontrarABC(derivadaVolumen((double)numericUpDown1.Value, (double)numericUpDown2.Value));
            label7.Text = "A: " + X[0] + " B: " + X[1] + " C: " + X[2];
            double[] valores = FormulaGeneral(X[0], X[1], X[2]);
            label8.Text = "x1: " + valores[0] + " x2: " + valores[1];
            label9.Text = "El resultado es:" + ((valores[0] > 0 && valores[0] < (double)numericUpDown1.Value / 2 && valores[0] < (double)numericUpDown2.Value / 2) ? valores[0] : valores[1]);
        }

        

        
        private int SacarSignos(string valor)
        {
            string signos = _sacarSignos.Match(valor).Value;
            int r = 1;
            for (int i = 0; i < signos.Length; i++)
            {
                if (signos[i] == '-')
                {
                    r *= -1;
                }
            }
            return r;

        }
    }
}
